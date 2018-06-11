using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication.Models;

namespace WebApplication.Controllers
{
    public class RestaurantMenuController : Controller
    {
        public class ItemMenuV
        {
            public int _Id;
            public string _category;
            public string _name;
            public System.Nullable<bool> _novelty;
            public System.Nullable<bool> _hit;
            public string _picture;
            public string _information;
            public string _price;
            public bool _availability;

            public int Id
            {
                get {return this._Id;}
                set{this._Id = value;}
            }
            public string category
            {
                get { return this._category; }
                set { this._category = value; }
            }
            public string name
            {
                get { return this._name; }
                set { this._name = value; }
            }
            public System.Nullable<bool> novelty
            {
                get { return this._novelty; }
                set { this._novelty = value; }
            }
            public System.Nullable<bool> hit
            {
                get { return this._hit; }
                set { this._hit = value; }
            }
            public string picture
            {
                get { return this._picture; }
                set { this._picture = value; }
            }
            public string information
            {
                get { return this._information; }
                set { this._information = value; }
            }
            public string price
            {
                get { return this._price; }
                set { this._price = value; }
            }
            public bool availability
            {
                get { return this._availability; }
                set { this._availability = value; }
            }
        }

        #region
        /// <summary>
        /// Datastore access context
        /// </summary>
        private DatabaseDataClassesDataContext db { get; set; }

        /// <summary>
        /// Handles initializing shared properties
        /// </summary>
        public RestaurantMenuController()
        {
            // initalize our access to th database
            db = new DatabaseDataClassesDataContext();
        }

        /// <summary>
        /// Releases managed and unmanaged resources based on parameters
        /// </summary>
        /// <param name="disposing">
        /// True: release managed and unamaged resources,
        /// False: release only unmanaged resources
        /// </param>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                // Dispose of our datastore access context
                db.Dispose();
            }
            base.Dispose(disposing);
        }
        #endregion

        public JsonResult GetMenuItems(string sort = null, int numberPage = 1, bool statusSort = false, string search = null)
        {
            // Create a list of view models which we will return
            var menuItemView = new List<ItemMenuV>();
            // Change each region into a view model and insert it into the list 
            IQueryable<RestaurantMenu> menuItems = db.RestaurantMenu;
            //switch (sort)
            //{
            //    default:
            //        {
            //            clients = statusSort ? clients.OrderByDescending(k => k.Id) : clients.OrderBy(k => k.Id);
            //        }
            //        break;
            //    case "surname":
            //        {
            //            clients = statusSort ? clients.OrderByDescending(k => k.surname) : clients.OrderBy(k => k.surname);
            //        }
            //        break;
            //    case "name":
            //        {
            //            clients = statusSort ? clients.OrderByDescending(k => k.name) : clients.OrderBy(k => k.name);
            //        }
            //        break;
            //    case "patronymic":
            //        {
            //            clients = statusSort ? clients.OrderByDescending(k => k.patronymic) : clients.OrderBy(k => k.patronymic);
            //        }
            //        break;
            //    case "phone":
            //        {
            //            clients = statusSort ? clients.OrderByDescending(k => k.phone) : clients.OrderBy(k => k.phone);
            //        }
            //        break;
            //    case "table_number":
            //        {
            //            clients = statusSort ? clients.OrderByDescending(k => k.table_number) : clients.OrderBy(k => k.table_number);
            //        }
            //        break;
            //    case "time":
            //        {
            //            clients = statusSort ? clients.OrderByDescending(k => k.time) : clients.OrderBy(k => k.time);
            //        }
            //        break;
            //    case "hours":
            //        {
            //            clients = statusSort ? clients.OrderByDescending(k => k.hours) : clients.OrderBy(k => k.hours);
            //        }
            //        break;
            //    case "date_time_reg":
            //        {
            //            clients = statusSort ? clients.OrderByDescending(k => k.date_time_reg) : clients.OrderBy(k => k.date_time_reg);
            //        }
            //        break;
            //    case "comment_text":
            //        {
            //            clients = statusSort ? clients.OrderByDescending(k => k.comment_text) : clients.OrderBy(k => k.comment_text);
            //        }
            //        break;
            //}
            if (!string.IsNullOrEmpty(search))
            {
                search = search.ToLower();
                int num;
                if (int.TryParse(search, out num))
                {
                    menuItems = menuItems.Where(s => s.Category1.Id == Convert.ToInt32(search));
                }
                if (!int.TryParse(search, out num))
                {
                    menuItems = menuItems.Where(s => s.Category1.name.ToLower().Contains(search) || s.name.ToLower().Contains(search));
                }
            }
            int pageSize = 15;
            int startIndex = (numberPage - 1) * pageSize;
            menuItems = menuItems.Skip(startIndex).Take(pageSize);
            foreach (RestaurantMenu m in menuItems)
            {
                menuItemView.Add(new ItemMenuV
                {
                    _Id = m.Id,
                    _availability = m.availability,
                    _category = m.Category1.name,
                    _name = m.name,
                    _novelty = m.novelty,
                    _hit = m.hit,
                    _information = m.information,
                    _price = m.price,
                    _picture = m.picture
                });
            }
            // Return HTTP 200 with the view model list as body payload
            return Json(menuItemView, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetMenuItemByNo(string id)
        {
            int no = Convert.ToInt32(id);
            var menuItemList = db.RestaurantMenu.Where(w => w.Id == no);
            return RedirectToAction("RestaurantMenu", "Admin", menuItemList);
        }

        public ActionResult GetTotalItems(string search = null)
        {
            int count = 1;
            if (!string.IsNullOrEmpty(search))
            {
                search = search.ToLower();
                count = db.RestaurantMenu.Where(w => w.name.ToLower().Contains(search)).Count();
            }
            else
            {
                count = db.RestaurantMenu.Count();
            }
            return RedirectToAction("RestaurantMenu", "Admin", count);
        }

        public JsonResult AddMenuItem(ItemMenuV item)
        {
            if (item != null)
            {
                var menuItemView = new RestaurantMenu()
                {
                    Id = item._Id,
                    availability = true,
                    category = Convert.ToInt32(item._category),
                    name = item._name,
                    information = item._information,
                    price = item._price,
                    picture = "..\\images\\" + item._picture,
                    novelty = true,
                    hit = false

                };
                db.RestaurantMenu.InsertOnSubmit(menuItemView);
                db.SubmitChanges();
                return Json("MenuItem ADD OK");
            }
            else
            {
                return Json("Invalid Item");
            }
        }

        public JsonResult UpdateMenuItem(ItemMenuV item)
        {
            if (item != null)
            {
                int no = Convert.ToInt32(item._Id);
                var menuItemList = db.RestaurantMenu.Where(x => x.Id == no).FirstOrDefault();
                menuItemList.category = db.Category.Where(w => w.Id == Convert.ToInt32(item._category)).FirstOrDefault().Id;
                menuItemList.name = item._name;
                menuItemList.information = item._information;
                menuItemList.price = item._price;
                menuItemList.picture = "..\\images\\" + item._picture;
                db.SubmitChanges();
                return Json("MenuItem Updated");
            }
            else
            {
                return Json("Invalid MenuItem");
            }
        }

        public string DelMenuItem(ItemMenuV item)
        {
            if (item != null)
            {
                int no = Convert.ToInt32(item._Id);
                var MenuItemList = db.RestaurantMenu.Where(x => x.Id == no).FirstOrDefault();
                db.RestaurantMenu.DeleteOnSubmit(MenuItemList);
                db.SubmitChanges();
                return "MenuItem Deleted"; ;
            }
            else
            {
                return "Invalid MenuItemList";
            }
        }

        public JsonResult CheckCheng(ItemMenuV item)
        {
            if (item != null)
            {
                int no = Convert.ToInt32(item._Id);
                var menuItemList = db.RestaurantMenu.Where(x => x.Id == no).FirstOrDefault();
                menuItemList.availability = item._availability;
                menuItemList.novelty = item._novelty;
                menuItemList.hit = item._hit;
                db.SubmitChanges();
                return Json("MenuItem Updated");
            }
            else
            {
                return Json("Invalid MenuItem");
            }
        }
    }
}