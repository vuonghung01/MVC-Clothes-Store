﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace HungManhProject.Models
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
    using System.ComponentModel.DataAnnotations;

    [global::System.Data.Linq.Mapping.DatabaseAttribute(Name="BadnotgoodStore")]
	public partial class dbBNGDataContext : System.Data.Linq.DataContext
	{
		
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
		
    #region Extensibility Method Definitions
    partial void OnCreated();
    partial void InsertCategory(Category instance);
    partial void UpdateCategory(Category instance);
    partial void DeleteCategory(Category instance);
    partial void InsertOrder(Order instance);
    partial void UpdateOrder(Order instance);
    partial void DeleteOrder(Order instance);
    partial void InsertOrder_detail(Order_detail instance);
    partial void UpdateOrder_detail(Order_detail instance);
    partial void DeleteOrder_detail(Order_detail instance);
    partial void InsertProduct(Product instance);
    partial void UpdateProduct(Product instance);
    partial void DeleteProduct(Product instance);
    partial void Insertuser(user instance);
    partial void Updateuser(user instance);
    partial void Deleteuser(user instance);
    #endregion
		
		public dbBNGDataContext() : 
				base(global::System.Configuration.ConfigurationManager.ConnectionStrings["BadnotgoodStoreConnectionString"].ConnectionString, mappingSource)
		{
			OnCreated();
		}
		
		public dbBNGDataContext(string connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public dbBNGDataContext(System.Data.IDbConnection connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public dbBNGDataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public dbBNGDataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public System.Data.Linq.Table<Category> Categories
		{
			get
			{
				return this.GetTable<Category>();
			}
		}
		
		public System.Data.Linq.Table<Order> Orders
		{
			get
			{
				return this.GetTable<Order>();
			}
		}
		
		public System.Data.Linq.Table<Order_detail> Order_details
		{
			get
			{
				return this.GetTable<Order_detail>();
			}
		}
		
		public System.Data.Linq.Table<Product> Products
		{
			get
			{
				return this.GetTable<Product>();
			}
		}
		
		public System.Data.Linq.Table<Product_variant> Product_variants
		{
			get
			{
				return this.GetTable<Product_variant>();
			}
		}
		
		public System.Data.Linq.Table<user> users
		{
			get
			{
				return this.GetTable<user>();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.Category")]
	public partial class Category : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _category_id;
		
		private string _category_name;
		
		private EntitySet<Product> _Products;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void Oncategory_idChanging(int value);
    partial void Oncategory_idChanged();
    partial void Oncategory_nameChanging(string value);
    partial void Oncategory_nameChanged();
    #endregion
		
		public Category()
		{
			this._Products = new EntitySet<Product>(new Action<Product>(this.attach_Products), new Action<Product>(this.detach_Products));
			OnCreated();
		}
		[Display(Name = "Mã loại")]
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_category_id", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int category_id
		{
			get
			{
				return this._category_id;
			}
			set
			{
				if ((this._category_id != value))
				{
					this.Oncategory_idChanging(value);
					this.SendPropertyChanging();
					this._category_id = value;
					this.SendPropertyChanged("category_id");
					this.Oncategory_idChanged();
				}
			}
		}
		[Display(Name = "Tên loại")]
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_category_name", DbType="NVarChar(255)")]
		public string category_name
		{
			get
			{
				return this._category_name;
			}
			set
			{
				if ((this._category_name != value))
				{
					this.Oncategory_nameChanging(value);
					this.SendPropertyChanging();
					this._category_name = value;
					this.SendPropertyChanged("category_name");
					this.Oncategory_nameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Category_Product", Storage="_Products", ThisKey="category_id", OtherKey="category_id")]
		public EntitySet<Product> Products
		{
			get
			{
				return this._Products;
			}
			set
			{
				this._Products.Assign(value);
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
		
		private void attach_Products(Product entity)
		{
			this.SendPropertyChanging();
			entity.Category = this;
		}
		
		private void detach_Products(Product entity)
		{
			this.SendPropertyChanging();
			entity.Category = null;
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.[Order]")]
	public partial class Order : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _order_id;
		
		private System.Nullable<int> _user_id;
		
		private string _email;
		
		private string _phone;
		
		private string _address;
		
		private System.Nullable<int> _discount;
		
		private System.Nullable<bool> _thanhtoan;
		
		private System.Nullable<bool> _giaohang;
		
		private System.Nullable<System.DateTime> _ngaydat;
		
		private System.Nullable<System.DateTime> _ngaygiao;
		
		private EntitySet<Order_detail> _Order_details;
		
		private EntityRef<user> _user;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void Onorder_idChanging(int value);
    partial void Onorder_idChanged();
    partial void Onuser_idChanging(System.Nullable<int> value);
    partial void Onuser_idChanged();
    partial void OnemailChanging(string value);
    partial void OnemailChanged();
    partial void OnphoneChanging(string value);
    partial void OnphoneChanged();
    partial void OnaddressChanging(string value);
    partial void OnaddressChanged();
    partial void OndiscountChanging(System.Nullable<int> value);
    partial void OndiscountChanged();
    partial void OnthanhtoanChanging(System.Nullable<bool> value);
    partial void OnthanhtoanChanged();
    partial void OngiaohangChanging(System.Nullable<bool> value);
    partial void OngiaohangChanged();
    partial void OnngaydatChanging(System.Nullable<System.DateTime> value);
    partial void OnngaydatChanged();
    partial void OnngaygiaoChanging(System.Nullable<System.DateTime> value);
    partial void OnngaygiaoChanged();
    #endregion
		
		public Order()
		{
			this._Order_details = new EntitySet<Order_detail>(new Action<Order_detail>(this.attach_Order_details), new Action<Order_detail>(this.detach_Order_details));
			this._user = default(EntityRef<user>);
			OnCreated();
		}
		[Display(Name = "Mã đặt hàng")]
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_order_id", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int order_id
		{
			get
			{
				return this._order_id;
			}
			set
			{
				if ((this._order_id != value))
				{
					this.Onorder_idChanging(value);
					this.SendPropertyChanging();
					this._order_id = value;
					this.SendPropertyChanged("order_id");
					this.Onorder_idChanged();
				}
			}
		}
		[Display(Name = "Mã khách hàng")]
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_user_id", DbType="Int")]
		public System.Nullable<int> user_id
		{
			get
			{
				return this._user_id;
			}
			set
			{
				if ((this._user_id != value))
				{
					if (this._user.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.Onuser_idChanging(value);
					this.SendPropertyChanging();
					this._user_id = value;
					this.SendPropertyChanged("user_id");
					this.Onuser_idChanged();
				}
			}
		}
		[Display(Name = "Email")]
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_email", DbType="NVarChar(50)")]
		public string email
		{
			get
			{
				return this._email;
			}
			set
			{
				if ((this._email != value))
				{
					this.OnemailChanging(value);
					this.SendPropertyChanging();
					this._email = value;
					this.SendPropertyChanged("email");
					this.OnemailChanged();
				}
			}
		}
		[Display(Name = "SĐT")]
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_phone", DbType="VarChar(15)")]
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
		[Display(Name = "Địa chỉ")]
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_address", DbType="NVarChar(100)")]
		public string address
		{
			get
			{
				return this._address;
			}
			set
			{
				if ((this._address != value))
				{
					this.OnaddressChanging(value);
					this.SendPropertyChanging();
					this._address = value;
					this.SendPropertyChanged("address");
					this.OnaddressChanged();
				}
			}
		}
		[Display(Name = "Khuyến mãi")]
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_discount", DbType="Int")]
		public System.Nullable<int> discount
		{
			get
			{
				return this._discount;
			}
			set
			{
				if ((this._discount != value))
				{
					this.OndiscountChanging(value);
					this.SendPropertyChanging();
					this._discount = value;
					this.SendPropertyChanged("discount");
					this.OndiscountChanged();
				}
			}
		}
		[Display(Name = "Thanh toán")]
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_thanhtoan", DbType="Bit")]
		public System.Nullable<bool> thanhtoan
		{
			get
			{
				return this._thanhtoan;
			}
			set
			{
				if ((this._thanhtoan != value))
				{
					this.OnthanhtoanChanging(value);
					this.SendPropertyChanging();
					this._thanhtoan = value;
					this.SendPropertyChanged("thanhtoan");
					this.OnthanhtoanChanged();
				}
			}
		}
		[Display(Name = "Giao hàng")]
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_giaohang", DbType="Bit")]
		public System.Nullable<bool> giaohang
		{
			get
			{
				return this._giaohang;
			}
			set
			{
				if ((this._giaohang != value))
				{
					this.OngiaohangChanging(value);
					this.SendPropertyChanging();
					this._giaohang = value;
					this.SendPropertyChanged("giaohang");
					this.OngiaohangChanged();
				}
			}
		}
		[Display(Name = "Ngày đặt")]
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ngaydat", DbType="Date")]
		public System.Nullable<System.DateTime> ngaydat
		{
			get
			{
				return this._ngaydat;
			}
			set
			{
				if ((this._ngaydat != value))
				{
					this.OnngaydatChanging(value);
					this.SendPropertyChanging();
					this._ngaydat = value;
					this.SendPropertyChanged("ngaydat");
					this.OnngaydatChanged();
				}
			}
		}
		[Display(Name = "Ngày giao")]
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ngaygiao", DbType="Date")]
		public System.Nullable<System.DateTime> ngaygiao
		{
			get
			{
				return this._ngaygiao;
			}
			set
			{
				if ((this._ngaygiao != value))
				{
					this.OnngaygiaoChanging(value);
					this.SendPropertyChanging();
					this._ngaygiao = value;
					this.SendPropertyChanged("ngaygiao");
					this.OnngaygiaoChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Order_Order_detail", Storage="_Order_details", ThisKey="order_id", OtherKey="order_id")]
		public EntitySet<Order_detail> Order_details
		{
			get
			{
				return this._Order_details;
			}
			set
			{
				this._Order_details.Assign(value);
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="user_Order", Storage="_user", ThisKey="user_id", OtherKey="user_id", IsForeignKey=true)]
		public user user
		{
			get
			{
				return this._user.Entity;
			}
			set
			{
				user previousValue = this._user.Entity;
				if (((previousValue != value) 
							|| (this._user.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._user.Entity = null;
						previousValue.Orders.Remove(this);
					}
					this._user.Entity = value;
					if ((value != null))
					{
						value.Orders.Add(this);
						this._user_id = value.user_id;
					}
					else
					{
						this._user_id = default(Nullable<int>);
					}
					this.SendPropertyChanged("user");
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
		
		private void attach_Order_details(Order_detail entity)
		{
			this.SendPropertyChanging();
			entity.Order = this;
		}
		
		private void detach_Order_details(Order_detail entity)
		{
			this.SendPropertyChanging();
			entity.Order = null;
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.Order_detail")]
	public partial class Order_detail : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _order_id;
		
		private int _product_id;
		
		private System.Nullable<int> _quantity;
		
		private string _size;
		
		private string _color;
		
		private System.Nullable<decimal> _price;
		
		private EntityRef<Order> _Order;
		
		private EntityRef<Product> _Product;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void Onorder_idChanging(int value);
    partial void Onorder_idChanged();
    partial void Onproduct_idChanging(int value);
    partial void Onproduct_idChanged();
    partial void OnquantityChanging(System.Nullable<int> value);
    partial void OnquantityChanged();
    partial void OnsizeChanging(string value);
    partial void OnsizeChanged();
    partial void OncolorChanging(string value);
    partial void OncolorChanged();
    partial void OnpriceChanging(System.Nullable<decimal> value);
    partial void OnpriceChanged();
    #endregion
		
		public Order_detail()
		{
			this._Order = default(EntityRef<Order>);
			this._Product = default(EntityRef<Product>);
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_order_id", DbType="Int NOT NULL", IsPrimaryKey=true)]
		public int order_id
		{
			get
			{
				return this._order_id;
			}
			set
			{
				if ((this._order_id != value))
				{
					if (this._Order.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.Onorder_idChanging(value);
					this.SendPropertyChanging();
					this._order_id = value;
					this.SendPropertyChanged("order_id");
					this.Onorder_idChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_product_id", DbType="Int NOT NULL", IsPrimaryKey=true)]
		public int product_id
		{
			get
			{
				return this._product_id;
			}
			set
			{
				if ((this._product_id != value))
				{
					if (this._Product.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.Onproduct_idChanging(value);
					this.SendPropertyChanging();
					this._product_id = value;
					this.SendPropertyChanged("product_id");
					this.Onproduct_idChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_quantity", DbType="Int")]
		public System.Nullable<int> quantity
		{
			get
			{
				return this._quantity;
			}
			set
			{
				if ((this._quantity != value))
				{
					this.OnquantityChanging(value);
					this.SendPropertyChanging();
					this._quantity = value;
					this.SendPropertyChanged("quantity");
					this.OnquantityChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_size", DbType="NVarChar(45)")]
		public string size
		{
			get
			{
				return this._size;
			}
			set
			{
				if ((this._size != value))
				{
					this.OnsizeChanging(value);
					this.SendPropertyChanging();
					this._size = value;
					this.SendPropertyChanged("size");
					this.OnsizeChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_color", DbType="NVarChar(45)")]
		public string color
		{
			get
			{
				return this._color;
			}
			set
			{
				if ((this._color != value))
				{
					this.OncolorChanging(value);
					this.SendPropertyChanging();
					this._color = value;
					this.SendPropertyChanged("color");
					this.OncolorChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_price", DbType="Decimal(18,0)")]
		public System.Nullable<decimal> price
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
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Order_Order_detail", Storage="_Order", ThisKey="order_id", OtherKey="order_id", IsForeignKey=true)]
		public Order Order
		{
			get
			{
				return this._Order.Entity;
			}
			set
			{
				Order previousValue = this._Order.Entity;
				if (((previousValue != value) 
							|| (this._Order.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._Order.Entity = null;
						previousValue.Order_details.Remove(this);
					}
					this._Order.Entity = value;
					if ((value != null))
					{
						value.Order_details.Add(this);
						this._order_id = value.order_id;
					}
					else
					{
						this._order_id = default(int);
					}
					this.SendPropertyChanged("Order");
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Product_Order_detail", Storage="_Product", ThisKey="product_id", OtherKey="product_id", IsForeignKey=true)]
		public Product Product
		{
			get
			{
				return this._Product.Entity;
			}
			set
			{
				Product previousValue = this._Product.Entity;
				if (((previousValue != value) 
							|| (this._Product.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._Product.Entity = null;
						previousValue.Order_details.Remove(this);
					}
					this._Product.Entity = value;
					if ((value != null))
					{
						value.Order_details.Add(this);
						this._product_id = value.product_id;
					}
					else
					{
						this._product_id = default(int);
					}
					this.SendPropertyChanged("Product");
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
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.Product")]
	public partial class Product : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _product_id;
		
		private System.Nullable<int> _category_id;
		
		private string _title;
		
		private string _description;
		
		private string _chatlieu;
		
		private string _kithuat;
		
		private string _size;
		
		private System.Nullable<decimal> _unit_price;
		
		private System.Nullable<decimal> _sale_price;
		
		private string _img;
		
		private string _img2;
		
		private string _img_loop;
		
		private System.Nullable<System.DateTime> _ngaycapnhat;
		
		private EntitySet<Order_detail> _Order_details;
		
		private EntityRef<Category> _Category;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void Onproduct_idChanging(int value);
    partial void Onproduct_idChanged();
    partial void Oncategory_idChanging(System.Nullable<int> value);
    partial void Oncategory_idChanged();
    partial void OntitleChanging(string value);
    partial void OntitleChanged();
    partial void OndescriptionChanging(string value);
    partial void OndescriptionChanged();
    partial void OnchatlieuChanging(string value);
    partial void OnchatlieuChanged();
    partial void OnkithuatChanging(string value);
    partial void OnkithuatChanged();
    partial void OnsizeChanging(string value);
    partial void OnsizeChanged();
    partial void Onunit_priceChanging(System.Nullable<decimal> value);
    partial void Onunit_priceChanged();
    partial void Onsale_priceChanging(System.Nullable<decimal> value);
    partial void Onsale_priceChanged();
    partial void OnimgChanging(string value);
    partial void OnimgChanged();
    partial void Onimg2Changing(string value);
    partial void Onimg2Changed();
    partial void Onimg_loopChanging(string value);
    partial void Onimg_loopChanged();
    partial void OnngaycapnhatChanging(System.Nullable<System.DateTime> value);
    partial void OnngaycapnhatChanged();
    #endregion
		
		public Product()
		{
			this._Order_details = new EntitySet<Order_detail>(new Action<Order_detail>(this.attach_Order_details), new Action<Order_detail>(this.detach_Order_details));
			this._Category = default(EntityRef<Category>);
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_product_id", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int product_id
		{
			get
			{
				return this._product_id;
			}
			set
			{
				if ((this._product_id != value))
				{
					this.Onproduct_idChanging(value);
					this.SendPropertyChanging();
					this._product_id = value;
					this.SendPropertyChanged("product_id");
					this.Onproduct_idChanged();
				}
			}
		}
		[Display(Name = "Mã loại")]
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_category_id", DbType="Int")]
		public System.Nullable<int> category_id
		{
			get
			{
				return this._category_id;
			}
			set
			{
				if ((this._category_id != value))
				{
					if (this._Category.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.Oncategory_idChanging(value);
					this.SendPropertyChanging();
					this._category_id = value;
					this.SendPropertyChanged("category_id");
					this.Oncategory_idChanged();
				}
			}
		}
		[Display(Name = "Tên")]
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_title", DbType="NVarChar(255) NOT NULL", CanBeNull=false)]
		public string title
		{
			get
			{
				return this._title;
			}
			set
			{
				if ((this._title != value))
				{
					this.OntitleChanging(value);
					this.SendPropertyChanging();
					this._title = value;
					this.SendPropertyChanged("title");
					this.OntitleChanged();
				}
			}
		}
		[Display(Name = "Mô tả")]
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_description", DbType="NVarChar(MAX)")]
		public string description
		{
			get
			{
				return this._description;
			}
			set
			{
				if ((this._description != value))
				{
					this.OndescriptionChanging(value);
					this.SendPropertyChanging();
					this._description = value;
					this.SendPropertyChanged("description");
					this.OndescriptionChanged();
				}
			}
		}
		[Display(Name = "Chất liệu")]
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_chatlieu", DbType="NVarChar(255)")]
		public string chatlieu
		{
			get
			{
				return this._chatlieu;
			}
			set
			{
				if ((this._chatlieu != value))
				{
					this.OnchatlieuChanging(value);
					this.SendPropertyChanging();
					this._chatlieu = value;
					this.SendPropertyChanged("chatlieu");
					this.OnchatlieuChanged();
				}
			}
		}
		[Display(Name = "Kĩ thuật")]
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_kithuat", DbType="NVarChar(255)")]
		public string kithuat
		{
			get
			{
				return this._kithuat;
			}
			set
			{
				if ((this._kithuat != value))
				{
					this.OnkithuatChanging(value);
					this.SendPropertyChanging();
					this._kithuat = value;
					this.SendPropertyChanged("kithuat");
					this.OnkithuatChanged();
				}
			}
		}
		[Display(Name = "Size")]
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_size", DbType="NVarChar(45)")]
		public string size
		{
			get
			{
				return this._size;
			}
			set
			{
				if ((this._size != value))
				{
					this.OnsizeChanging(value);
					this.SendPropertyChanging();
					this._size = value;
					this.SendPropertyChanged("size");
					this.OnsizeChanged();
				}
			}
		}
		[Display(Name = "Giá")]
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_unit_price", DbType="Decimal(18,0)")]
		public System.Nullable<decimal> unit_price
		{
			get
			{
				return this._unit_price;
			}
			set
			{
				if ((this._unit_price != value))
				{
					this.Onunit_priceChanging(value);
					this.SendPropertyChanging();
					this._unit_price = value;
					this.SendPropertyChanged("unit_price");
					this.Onunit_priceChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_sale_price", DbType="Decimal(18,0)")]
		public System.Nullable<decimal> sale_price
		{
			get
			{
				return this._sale_price;
			}
			set
			{
				if ((this._sale_price != value))
				{
					this.Onsale_priceChanging(value);
					this.SendPropertyChanging();
					this._sale_price = value;
					this.SendPropertyChanged("sale_price");
					this.Onsale_priceChanged();
				}
			}
		}
		[Display(Name = "Ảnh")]
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_img", DbType="NVarChar(150)")]
		public string img
		{
			get
			{
				return this._img;
			}
			set
			{
				if ((this._img != value))
				{
					this.OnimgChanging(value);
					this.SendPropertyChanging();
					this._img = value;
					this.SendPropertyChanged("img");
					this.OnimgChanged();
				}
			}
		}
		[Display(Name = "Ảnh2")]
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_img2", DbType="NVarChar(150)")]
		public string img2
		{
			get
			{
				return this._img2;
			}
			set
			{
				if ((this._img2 != value))
				{
					this.Onimg2Changing(value);
					this.SendPropertyChanging();
					this._img2 = value;
					this.SendPropertyChanged("img2");
					this.Onimg2Changed();
				}
			}
		}
		[Display(Name = "Ảnh3")]
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_img_loop", DbType="NVarChar(150)")]
		public string img_loop
		{
			get
			{
				return this._img_loop;
			}
			set
			{
				if ((this._img_loop != value))
				{
					this.Onimg_loopChanging(value);
					this.SendPropertyChanging();
					this._img_loop = value;
					this.SendPropertyChanged("img_loop");
					this.Onimg_loopChanged();
				}
			}
		}
		[Display(Name = "Ngày cập nhật")]
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ngaycapnhat", DbType="DateTime")]
		public System.Nullable<System.DateTime> ngaycapnhat
		{
			get
			{
				return this._ngaycapnhat;
			}
			set
			{
				if ((this._ngaycapnhat != value))
				{
					this.OnngaycapnhatChanging(value);
					this.SendPropertyChanging();
					this._ngaycapnhat = value;
					this.SendPropertyChanged("ngaycapnhat");
					this.OnngaycapnhatChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Product_Order_detail", Storage="_Order_details", ThisKey="product_id", OtherKey="product_id")]
		public EntitySet<Order_detail> Order_details
		{
			get
			{
				return this._Order_details;
			}
			set
			{
				this._Order_details.Assign(value);
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Category_Product", Storage="_Category", ThisKey="category_id", OtherKey="category_id", IsForeignKey=true)]
		public Category Category
		{
			get
			{
				return this._Category.Entity;
			}
			set
			{
				Category previousValue = this._Category.Entity;
				if (((previousValue != value) 
							|| (this._Category.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._Category.Entity = null;
						previousValue.Products.Remove(this);
					}
					this._Category.Entity = value;
					if ((value != null))
					{
						value.Products.Add(this);
						this._category_id = value.category_id;
					}
					else
					{
						this._category_id = default(Nullable<int>);
					}
					this.SendPropertyChanged("Category");
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
		
		private void attach_Order_details(Order_detail entity)
		{
			this.SendPropertyChanging();
			entity.Product = this;
		}
		
		private void detach_Order_details(Order_detail entity)
		{
			this.SendPropertyChanging();
			entity.Product = null;
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.Product_variant")]
	public partial class Product_variant
	{
		
		private System.Nullable<int> _product_id;
		
		private string _size;
		
		private string _color;
		
		private System.Nullable<int> _quantity;
		
		public Product_variant()
		{
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_product_id", DbType="Int")]
		public System.Nullable<int> product_id
		{
			get
			{
				return this._product_id;
			}
			set
			{
				if ((this._product_id != value))
				{
					this._product_id = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_size", DbType="NVarChar(45)")]
		public string size
		{
			get
			{
				return this._size;
			}
			set
			{
				if ((this._size != value))
				{
					this._size = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_color", DbType="NVarChar(45)")]
		public string color
		{
			get
			{
				return this._color;
			}
			set
			{
				if ((this._color != value))
				{
					this._color = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_quantity", DbType="Int")]
		public System.Nullable<int> quantity
		{
			get
			{
				return this._quantity;
			}
			set
			{
				if ((this._quantity != value))
				{
					this._quantity = value;
				}
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.[user]")]
	public partial class user : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _user_id;
		
		private string _name;
		
		private string _username;
		
		private string _password;
		
		private string _email;
		
		private string _address;
		
		private string _phone;
		
		private System.Nullable<System.DateTime> _birthdate;
		
		private EntitySet<Order> _Orders;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void Onuser_idChanging(int value);
    partial void Onuser_idChanged();
    partial void OnnameChanging(string value);
    partial void OnnameChanged();
    partial void OnusernameChanging(string value);
    partial void OnusernameChanged();
    partial void OnpasswordChanging(string value);
    partial void OnpasswordChanged();
    partial void OnemailChanging(string value);
    partial void OnemailChanged();
    partial void OnaddressChanging(string value);
    partial void OnaddressChanged();
    partial void OnphoneChanging(string value);
    partial void OnphoneChanged();
    partial void OnbirthdateChanging(System.Nullable<System.DateTime> value);
    partial void OnbirthdateChanged();
    #endregion
		
		public user()
		{
			this._Orders = new EntitySet<Order>(new Action<Order>(this.attach_Orders), new Action<Order>(this.detach_Orders));
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_user_id", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int user_id
		{
			get
			{
				return this._user_id;
			}
			set
			{
				if ((this._user_id != value))
				{
					this.Onuser_idChanging(value);
					this.SendPropertyChanging();
					this._user_id = value;
					this.SendPropertyChanged("user_id");
					this.Onuser_idChanged();
				}
			}
		}
		[Display(Name = "Họ tên")]
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_name", DbType="NVarChar(50)")]
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
		[Display(Name = "Tên đăng nhập")]
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_username", DbType="NVarChar(20)")]
		public string username
		{
			get
			{
				return this._username;
			}
			set
			{
				if ((this._username != value))
				{
					this.OnusernameChanging(value);
					this.SendPropertyChanging();
					this._username = value;
					this.SendPropertyChanged("username");
					this.OnusernameChanged();
				}
			}
		}
		[Display(Name = "Mật khẩu")]
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_password", DbType="NVarChar(10)")]
		public string password
		{
			get
			{
				return this._password;
			}
			set
			{
				if ((this._password != value))
				{
					this.OnpasswordChanging(value);
					this.SendPropertyChanging();
					this._password = value;
					this.SendPropertyChanged("password");
					this.OnpasswordChanged();
				}
			}
		}
		[Display(Name = "Email")]
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_email", DbType="NVarChar(50)")]
		public string email
		{
			get
			{
				return this._email;
			}
			set
			{
				if ((this._email != value))
				{
					this.OnemailChanging(value);
					this.SendPropertyChanging();
					this._email = value;
					this.SendPropertyChanged("email");
					this.OnemailChanged();
				}
			}
		}
		[Display(Name = "Địa chỉ")]
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_address", DbType="NVarChar(100)")]
		public string address
		{
			get
			{
				return this._address;
			}
			set
			{
				if ((this._address != value))
				{
					this.OnaddressChanging(value);
					this.SendPropertyChanging();
					this._address = value;
					this.SendPropertyChanged("address");
					this.OnaddressChanged();
				}
			}
		}
		[Display(Name = "SĐT")]
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_phone", DbType="VarChar(15)")]
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
		[Display(Name = "Ngày sinh")]
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_birthdate", DbType="Date")]
		public System.Nullable<System.DateTime> birthdate
		{
			get
			{
				return this._birthdate;
			}
			set
			{
				if ((this._birthdate != value))
				{
					this.OnbirthdateChanging(value);
					this.SendPropertyChanging();
					this._birthdate = value;
					this.SendPropertyChanged("birthdate");
					this.OnbirthdateChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="user_Order", Storage="_Orders", ThisKey="user_id", OtherKey="user_id")]
		public EntitySet<Order> Orders
		{
			get
			{
				return this._Orders;
			}
			set
			{
				this._Orders.Assign(value);
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
		
		private void attach_Orders(Order entity)
		{
			this.SendPropertyChanging();
			entity.user = this;
		}
		
		private void detach_Orders(Order entity)
		{
			this.SendPropertyChanging();
			entity.user = null;
		}
	}
}
#pragma warning restore 1591
