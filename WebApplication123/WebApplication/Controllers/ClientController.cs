using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using WebApplication.Models;

namespace WebApplication.Controllers
{
    public class ClientController : Controller
    {
        #region
        /// <summary>
        /// Datastore access context
        /// </summary>
        private DatabaseDataClassesDataContext db { get; set; }

        /// <summary>
        /// Handles initializing shared properties
        /// </summary>
        public ClientController()
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
        public JsonResult AddClient(BookingTables client)
        {
            client.date_time_reg = DateTime.Now.ToString();
            if (client != null)
            {
                db.BookingTables.InsertOnSubmit(client);
                db.SubmitChanges();
                return Json("Ok");
            }
            else
            {
                return Json("Error");
            }
            
        }

        public JsonResult GetClients(string sort = null, int numberPage = 1, bool statusSort = false, string search = null)
        {
            // Create a list of view models which we will return
            var clientView = new List<BookingTables>();
            // Change each region into a view model and insert it into the list 
            IQueryable<BookingTables> clients = db.BookingTables;
            switch (sort)
            {
                default:
                    {
                        clients = statusSort ? clients.OrderByDescending(k => k.Id) : clients.OrderBy(k => k.Id);
                    }
                    break;
                case "surname":
                    {
                        clients = statusSort ? clients.OrderByDescending(k => k.surname) : clients.OrderBy(k => k.surname);
                    }
                    break;
                case "name":
                    {
                        clients = statusSort ? clients.OrderByDescending(k => k.name) : clients.OrderBy(k => k.name);
                    }
                    break;
                case "patronymic":
                    {
                        clients = statusSort ? clients.OrderByDescending(k => k.patronymic) : clients.OrderBy(k => k.patronymic);
                    }
                    break;
                case "phone":
                    {
                        clients = statusSort ? clients.OrderByDescending(k => k.phone) : clients.OrderBy(k => k.phone);
                    }
                    break;
                case "table_number":
                    {
                        clients = statusSort ? clients.OrderByDescending(k => k.table_number) : clients.OrderBy(k => k.table_number);
                    }
                    break;
                case "time":
                    {
                        clients = statusSort ? clients.OrderByDescending(k => k.time) : clients.OrderBy(k => k.time);
                    }
                    break;
                case "hours":
                    {
                        clients = statusSort ? clients.OrderByDescending(k => k.hours) : clients.OrderBy(k => k.hours);
                    }
                    break;
                case "date_time_reg":
                    {
                        clients = statusSort ? clients.OrderByDescending(k => k.date_time_reg) : clients.OrderBy(k => k.date_time_reg);
                    }
                    break;
                case "comment_text":
                    {
                        clients = statusSort ? clients.OrderByDescending(k => k.comment_text) : clients.OrderBy(k => k.comment_text);
                    }
                    break;
            }
            if (!string.IsNullOrEmpty(search))
            {
                search = search.ToLower();
                clients = clients.Where(s => s.surname.ToLower().Contains(search) || s.name.ToLower().Contains(search) || s.patronymic.ToLower().Contains(search) || s.phone.ToLower().Contains(search));
            }
            int pageSize = 5;
            int startIndex = (numberPage - 1) * pageSize;
            clients = clients.Skip(startIndex).Take(pageSize);
            foreach (BookingTables c in clients)
            {
                clientView.Add(new BookingTables
                {
                    Id = c.Id,
                    surname = c.surname,
                    name = c.name,
                    patronymic = c.patronymic,
                    phone = c.phone,
                    table_number = c.table_number,
                    time = c.time,
                    hours = c.hours,
                    date_time_reg = c.date_time_reg,
                    comment_text = c.comment_text
                });
            }
            // Return HTTP 200 with the view model list as body payload
            return Json(clientView, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetClientByNo(string id)
        {
            int no = Convert.ToInt32(id);
            var clientList = db.BookingTables.Where(w => w.Id == no);
            return RedirectToAction("Index", "Admin", clientList);
        }

        public ActionResult GetTotalItems(string search = null)
        {
            int count = 1;
            if (!string.IsNullOrEmpty(search))
            {
                search = search.ToLower();
                count = db.BookingTables.Where(w => w.surname.ToLower().Contains(search) ||
                                               w.name.ToLower().Contains(search) ||
                                               w.patronymic.ToLower().Contains(search) ||
                                               w.phone.ToLower().Contains(search)).Count();
            }
            else
            {
                count = db.BookingTables.Count();
            }
            return RedirectToAction("Index", "Admin", count);
        }

        public string DeleteClient(BookingTables client)
        {
            if (client != null)
            {
                int no = Convert.ToInt32(client.Id);
                var shipList = db.BookingTables.Where(x => x.Id == no).FirstOrDefault();
                db.BookingTables.DeleteOnSubmit(shipList);
                db.SubmitChanges();
                return "Client Deleted"; ;
            }
            else
            {
                return "Invalid ship";
            }
        }

        public JsonResult UpdateClient(BookingTables client)
        {
            if (client != null)
            {
                int no = Convert.ToInt32(client.Id);
                var clientList = db.BookingTables.Where(x => x.Id == no).FirstOrDefault();
                clientList.surname = client.surname;
                clientList.name = client.name;
                clientList.patronymic = client.patronymic;
                clientList.phone = client.phone;
                clientList.table_number = client.table_number;
                clientList.time = client.time;
                clientList.hours = client.hours;
                clientList.date_time_reg = client.date_time_reg;
                clientList.comment_text = client.comment_text;
                db.SubmitChanges();
                return Json("Client Updated");
            }
            else
            {
                return Json("Invalid client");
            }
        }

    }
}