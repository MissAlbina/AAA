﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebApplication.Models
{
	using System.Data.Linq;
	using System.Data.Linq.Mapping;
	using System.Data;
	using System.Collections.Generic;
	using System.Reflection;
	using System.Linq;
	using System.Linq.Expressions;
	using System.ComponentModel;
	using System;
	
	
	[global::System.Data.Linq.Mapping.DatabaseAttribute(Name="Database")]
	public partial class DatabaseDataClassesDataContext : System.Data.Linq.DataContext
	{
		
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
		
    #region Определения метода расширяемости
    partial void OnCreated();
    partial void InsertBookingTables(BookingTables instance);
    partial void UpdateBookingTables(BookingTables instance);
    partial void DeleteBookingTables(BookingTables instance);
    partial void InsertCategory(Category instance);
    partial void UpdateCategory(Category instance);
    partial void DeleteCategory(Category instance);
    partial void InsertRestaurantMenu(RestaurantMenu instance);
    partial void UpdateRestaurantMenu(RestaurantMenu instance);
    partial void DeleteRestaurantMenu(RestaurantMenu instance);
    #endregion
		
		public DatabaseDataClassesDataContext() : 
				base(global::System.Configuration.ConfigurationManager.ConnectionStrings["DatabaseConnectionString"].ConnectionString, mappingSource)
		{
			OnCreated();
		}
		
		public DatabaseDataClassesDataContext(string connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public DatabaseDataClassesDataContext(System.Data.IDbConnection connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public DatabaseDataClassesDataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public DatabaseDataClassesDataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public System.Data.Linq.Table<BookingTables> BookingTables
		{
			get
			{
				return this.GetTable<BookingTables>();
			}
		}
		
		public System.Data.Linq.Table<Category> Category
		{
			get
			{
				return this.GetTable<Category>();
			}
		}
		
		public System.Data.Linq.Table<RestaurantMenu> RestaurantMenu
		{
			get
			{
				return this.GetTable<RestaurantMenu>();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.BookingTables")]
	public partial class BookingTables : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _Id;
		
		private string _surname;
		
		private string _name;
		
		private string _patronymic;
		
		private string _phone;
		
		private string _table_number;
		
		private string _time;
		
		private string _hours;
		
		private string _date_time_reg;
		
		private string _comment_text;
		
    #region Определения метода расширяемости
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnIdChanging(int value);
    partial void OnIdChanged();
    partial void OnsurnameChanging(string value);
    partial void OnsurnameChanged();
    partial void OnnameChanging(string value);
    partial void OnnameChanged();
    partial void OnpatronymicChanging(string value);
    partial void OnpatronymicChanged();
    partial void OnphoneChanging(string value);
    partial void OnphoneChanged();
    partial void Ontable_numberChanging(string value);
    partial void Ontable_numberChanged();
    partial void OntimeChanging(string value);
    partial void OntimeChanged();
    partial void OnhoursChanging(string value);
    partial void OnhoursChanged();
    partial void Ondate_time_regChanging(string value);
    partial void Ondate_time_regChanged();
    partial void Oncomment_textChanging(string value);
    partial void Oncomment_textChanged();
    #endregion
		
		public BookingTables()
		{
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Id", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int Id
		{
			get
			{
				return this._Id;
			}
			set
			{
				if ((this._Id != value))
				{
					this.OnIdChanging(value);
					this.SendPropertyChanging();
					this._Id = value;
					this.SendPropertyChanged("Id");
					this.OnIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_surname", DbType="NVarChar(50) NOT NULL", CanBeNull=false)]
		public string surname
		{
			get
			{
				return this._surname;
			}
			set
			{
				if ((this._surname != value))
				{
					this.OnsurnameChanging(value);
					this.SendPropertyChanging();
					this._surname = value;
					this.SendPropertyChanged("surname");
					this.OnsurnameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_name", DbType="NVarChar(50) NOT NULL", CanBeNull=false)]
		public string name
		{
			get
			{
				return this._name;
			}
			set
			{
				if ((this._name != value))
				{
					this.OnnameChanging(value);
					this.SendPropertyChanging();
					this._name = value;
					this.SendPropertyChanged("name");
					this.OnnameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_patronymic", DbType="NVarChar(50)")]
		public string patronymic
		{
			get
			{
				return this._patronymic;
			}
			set
			{
				if ((this._patronymic != value))
				{
					this.OnpatronymicChanging(value);
					this.SendPropertyChanging();
					this._patronymic = value;
					this.SendPropertyChanged("patronymic");
					this.OnpatronymicChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_phone", DbType="NVarChar(50) NOT NULL", CanBeNull=false)]
		public string phone
		{
			get
			{
				return this._phone;
			}
			set
			{
				if ((this._phone != value))
				{
					this.OnphoneChanging(value);
					this.SendPropertyChanging();
					this._phone = value;
					this.SendPropertyChanged("phone");
					this.OnphoneChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_table_number", DbType="NVarChar(50)")]
		public string table_number
		{
			get
			{
				return this._table_number;
			}
			set
			{
				if ((this._table_number != value))
				{
					this.Ontable_numberChanging(value);
					this.SendPropertyChanging();
					this._table_number = value;
					this.SendPropertyChanged("table_number");
					this.Ontable_numberChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_time", DbType="NVarChar(50)")]
		public string time
		{
			get
			{
				return this._time;
			}
			set
			{
				if ((this._time != value))
				{
					this.OntimeChanging(value);
					this.SendPropertyChanging();
					this._time = value;
					this.SendPropertyChanged("time");
					this.OntimeChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_hours", DbType="NVarChar(50)")]
		public string hours
		{
			get
			{
				return this._hours;
			}
			set
			{
				if ((this._hours != value))
				{
					this.OnhoursChanging(value);
					this.SendPropertyChanging();
					this._hours = value;
					this.SendPropertyChanged("hours");
					this.OnhoursChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_date_time_reg", DbType="NVarChar(50) NOT NULL", CanBeNull=false)]
		public string date_time_reg
		{
			get
			{
				return this._date_time_reg;
			}
			set
			{
				if ((this._date_time_reg != value))
				{
					this.Ondate_time_regChanging(value);
					this.SendPropertyChanging();
					this._date_time_reg = value;
					this.SendPropertyChanged("date_time_reg");
					this.Ondate_time_regChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_comment_text", DbType="NVarChar(MAX)")]
		public string comment_text
		{
			get
			{
				return this._comment_text;
			}
			set
			{
				if ((this._comment_text != value))
				{
					this.Oncomment_textChanging(value);
					this.SendPropertyChanging();
					this._comment_text = value;
					this.SendPropertyChanged("comment_text");
					this.Oncomment_textChanged();
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.Category")]
	public partial class Category : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _Id;
		
		private string _name;
		
		private EntitySet<RestaurantMenu> _RestaurantMenu;
		
    #region Определения метода расширяемости
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnIdChanging(int value);
    partial void OnIdChanged();
    partial void OnnameChanging(string value);
    partial void OnnameChanged();
    #endregion
		
		public Category()
		{
			this._RestaurantMenu = new EntitySet<RestaurantMenu>(new Action<RestaurantMenu>(this.attach_RestaurantMenu), new Action<RestaurantMenu>(this.detach_RestaurantMenu));
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Id", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int Id
		{
			get
			{
				return this._Id;
			}
			set
			{
				if ((this._Id != value))
				{
					this.OnIdChanging(value);
					this.SendPropertyChanging();
					this._Id = value;
					this.SendPropertyChanged("Id");
					this.OnIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_name", DbType="NVarChar(50) NOT NULL", CanBeNull=false)]
		public string name
		{
			get
			{
				return this._name;
			}
			set
			{
				if ((this._name != value))
				{
					this.OnnameChanging(value);
					this.SendPropertyChanging();
					this._name = value;
					this.SendPropertyChanged("name");
					this.OnnameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Category_RestaurantMenu", Storage="_RestaurantMenu", ThisKey="Id", OtherKey="category")]
		public EntitySet<RestaurantMenu> RestaurantMenu
		{
			get
			{
				return this._RestaurantMenu;
			}
			set
			{
				this._RestaurantMenu.Assign(value);
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
		
		private void attach_RestaurantMenu(RestaurantMenu entity)
		{
			this.SendPropertyChanging();
			entity.Category1 = this;
		}
		
		private void detach_RestaurantMenu(RestaurantMenu entity)
		{
			this.SendPropertyChanging();
			entity.Category1 = null;
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.RestaurantMenu")]
	public partial class RestaurantMenu : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _Id;
		
		private int _category;
		
		private string _name;
		
		private System.Nullable<bool> _novelty;
		
		private System.Nullable<bool> _hit;
		
		private string _information;
		
		private string _price;
		
		private bool _availability;
		
		private string _picture;
		
		private EntityRef<Category> _Category1;
		
    #region Определения метода расширяемости
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnIdChanging(int value);
    partial void OnIdChanged();
    partial void OncategoryChanging(int value);
    partial void OncategoryChanged();
    partial void OnnameChanging(string value);
    partial void OnnameChanged();
    partial void OnnoveltyChanging(System.Nullable<bool> value);
    partial void OnnoveltyChanged();
    partial void OnhitChanging(System.Nullable<bool> value);
    partial void OnhitChanged();
    partial void OninformationChanging(string value);
    partial void OninformationChanged();
    partial void OnpriceChanging(string value);
    partial void OnpriceChanged();
    partial void OnavailabilityChanging(bool value);
    partial void OnavailabilityChanged();
    partial void OnpictureChanging(string value);
    partial void OnpictureChanged();
    #endregion
		
		public RestaurantMenu()
		{
			this._Category1 = default(EntityRef<Category>);
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Id", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int Id
		{
			get
			{
				return this._Id;
			}
			set
			{
				if ((this._Id != value))
				{
					this.OnIdChanging(value);
					this.SendPropertyChanging();
					this._Id = value;
					this.SendPropertyChanged("Id");
					this.OnIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_category", DbType="Int NOT NULL")]
		public int category
		{
			get
			{
				return this._category;
			}
			set
			{
				if ((this._category != value))
				{
					if (this._Category1.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OncategoryChanging(value);
					this.SendPropertyChanging();
					this._category = value;
					this.SendPropertyChanged("category");
					this.OncategoryChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_name", DbType="NVarChar(50) NOT NULL", CanBeNull=false)]
		public string name
		{
			get
			{
				return this._name;
			}
			set
			{
				if ((this._name != value))
				{
					this.OnnameChanging(value);
					this.SendPropertyChanging();
					this._name = value;
					this.SendPropertyChanged("name");
					this.OnnameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_novelty", DbType="Bit")]
		public System.Nullable<bool> novelty
		{
			get
			{
				return this._novelty;
			}
			set
			{
				if ((this._novelty != value))
				{
					this.OnnoveltyChanging(value);
					this.SendPropertyChanging();
					this._novelty = value;
					this.SendPropertyChanged("novelty");
					this.OnnoveltyChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_hit", DbType="Bit")]
		public System.Nullable<bool> hit
		{
			get
			{
				return this._hit;
			}
			set
			{
				if ((this._hit != value))
				{
					this.OnhitChanging(value);
					this.SendPropertyChanging();
					this._hit = value;
					this.SendPropertyChanged("hit");
					this.OnhitChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_information", DbType="NVarChar(MAX)")]
		public string information
		{
			get
			{
				return this._information;
			}
			set
			{
				if ((this._information != value))
				{
					this.OninformationChanging(value);
					this.SendPropertyChanging();
					this._information = value;
					this.SendPropertyChanged("information");
					this.OninformationChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_price", DbType="NVarChar(50)")]
		public string price
		{
			get
			{
				return this._price;
			}
			set
			{
				if ((this._price != value))
				{
					this.OnpriceChanging(value);
					this.SendPropertyChanging();
					this._price = value;
					this.SendPropertyChanged("price");
					this.OnpriceChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_availability", DbType="Bit NOT NULL")]
		public bool availability
		{
			get
			{
				return this._availability;
			}
			set
			{
				if ((this._availability != value))
				{
					this.OnavailabilityChanging(value);
					this.SendPropertyChanging();
					this._availability = value;
					this.SendPropertyChanged("availability");
					this.OnavailabilityChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_picture", DbType="NVarChar(MAX)")]
		public string picture
		{
			get
			{
				return this._picture;
			}
			set
			{
				if ((this._picture != value))
				{
					this.OnpictureChanging(value);
					this.SendPropertyChanging();
					this._picture = value;
					this.SendPropertyChanged("picture");
					this.OnpictureChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Category_RestaurantMenu", Storage="_Category1", ThisKey="category", OtherKey="Id", IsForeignKey=true)]
		public Category Category1
		{
			get
			{
				return this._Category1.Entity;
			}
			set
			{
				Category previousValue = this._Category1.Entity;
				if (((previousValue != value) 
							|| (this._Category1.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._Category1.Entity = null;
						previousValue.RestaurantMenu.Remove(this);
					}
					this._Category1.Entity = value;
					if ((value != null))
					{
						value.RestaurantMenu.Add(this);
						this._category = value.Id;
					}
					else
					{
						this._category = default(int);
					}
					this.SendPropertyChanged("Category1");
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
}
#pragma warning restore 1591
