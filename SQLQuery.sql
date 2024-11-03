create database BadnotgoodStore
go
use BadnotgoodStore
go
create table Category(
category_id int identity primary key,
category_name nvarchar(255))
go
create table Product(
product_id int identity(1,1) primary key,
category_id int references Category(category_id),
title nvarchar(255) not null,
description nvarchar(max),
chatlieu nvarchar(255),
kithuat nvarchar(255),
size nvarchar(45),
unit_price decimal(18,0),
sale_price decimal(18,0),
img nvarchar(150),
img2 nvarchar(150),
img_loop varchar(50),
ngaycapnhat datetime)
go
create table Product_variant(
product_id int references Product(product_id),
size nvarchar(45),
color nvarchar(45),
quantity int)
go
create table [user](
user_id int identity(1,1) primary key,
name nvarchar(50),
username nvarchar(20),
password nvarchar(10),
email nvarchar(50),
address nvarchar(100),
phone varchar(15),
birthdate date)
go
create table [Order](
order_id int identity(1,1) primary key,
user_id int references [User](user_id),
email nvarchar(50),
phone varchar(15),
address nvarchar(100),
discount int,
thanhtoan bit,
giaohang bit,
ngaydat date,
ngaygiao date)
go
create table [Order_detail](
order_id int references [Order](order_id),
product_id int references Product(product_id),
quantity int,
size nvarchar(45),
color nvarchar(45),
price decimal(18,0),
primary key(order_id,product_id))
go

select * from Category
select * from Product
select * from [User]
select * from [Order]
select * from Order_detail
select * from Product_variant