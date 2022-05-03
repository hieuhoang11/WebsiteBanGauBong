create database QLBanThuBong
use QLBanThuBong

create table Category
(
	CategoryId bigint IDENTITY(1,1) primary key  not null,
	Name nvarchar(250),
	soThuTu int 
)
Insert into Category(name,soThuTu) 
Values (N'Gấu Teddy',1)
Insert into Category(name,soThuTu) 
Values (N'Thú Bông',2)
Insert into Category(name,soThuTu) 
Values (N'Gấu Bông Hoạt Hình',3)
Insert into Category(name,soThuTu) 
Values (N'Gối Ôm',4)

create table ProductCategory
(
	ProductCategoryId bigint IDENTITY(1,1) primary key not null,
	Name nvarchar(250),	
	CategoryId bigint ,
	CONSTRAINT fk_ProductCategory_Category
	FOREIGN KEY(CategoryId)
	REFERENCES Category(CategoryId)
	ON DELETE CASCADE
	ON UPDATE CASCADE
)
Insert into ProductCategory(name,CategoryId) 
Values (N'GẤU BÔNG SIZE LỚN',1)
Insert into ProductCategory(name,CategoryId) 
Values (N'GẤU BÔNG SIZE NHỎ',1)
Insert into ProductCategory(name,CategoryId) 
Values (N'GẤU BÔNG TỐT NGHIỆP',1)
Insert into ProductCategory(name,CategoryId) 
Values (N'GẤU BÔNG TO',1)
Insert into ProductCategory(name,CategoryId) 
Values (N'GẤU BÔNG ÁO LEN',1)
Insert into ProductCategory(name,CategoryId) 
Values (N'CHÓ BÔNG',2)
Insert into ProductCategory(name,CategoryId) 
Values (N'GÀ BÔNG',2)
Insert into ProductCategory(name,CategoryId) 
Values (N'MÈO BÔNG',2)
Insert into ProductCategory(name,CategoryId) 
Values (N'CÁ BÔNG',2)
Insert into ProductCategory(name,CategoryId) 
Values (N'HEO BÔNG',2)
Insert into ProductCategory(name,CategoryId) 
Values (N'NGỰA BÔNG',2)
Insert into ProductCategory(name,CategoryId) 
Values (N'NHÍM BÔNG',2)
Insert into ProductCategory(name,CategoryId) 
Values (N'KHỈ BÔNG',2)
Insert into ProductCategory(name,CategoryId) 
Values (N'HÀ MÃ BÔNG',2)
Insert into ProductCategory(name,CategoryId) 
Values (N'SÂU BÔNG',2)
Insert into ProductCategory(name,CategoryId) 
Values (N'GẤU BÔNG TOTORO',3)
Insert into ProductCategory(name,CategoryId) 
Values (N'GẤU BÔNG STITCH',3)
Insert into ProductCategory(name,CategoryId) 
Values (N'GẤU BÔNG RILAKKUMA',3)
Insert into ProductCategory(name,CategoryId) 
Values (N'CHUỘT MICKEY',3)
Insert into ProductCategory(name,CategoryId) 
Values (N'GẤU BÔNG DOREMON',3)
Insert into ProductCategory(name,CategoryId) 
Values (N'GẤU BÔNG HELLO KITTY',3)
Insert into ProductCategory(name,CategoryId) 
Values (N'CHÓ HUSKY',3)
Insert into ProductCategory(name,CategoryId) 
Values (N'GẤU BÔNG TONTON',3)
Insert into ProductCategory(name,CategoryId) 
Values (N'GẤU BÔNG KAKAO TALK',3)
Insert into ProductCategory(name,CategoryId) 
Values (N'GẤU POOHKHỈ YOYO & CICIN',3)
Insert into ProductCategory(name,CategoryId) 
Values (N'GỰA PONYPIKACHU',3)
Insert into ProductCategory(name,CategoryId) 
Values (N'SHIN – CẬU BÉ BÚT CHÌ',3)
Insert into ProductCategory(name,CategoryId) 
Values (N'GỐI CHỮ U',4)
Insert into ProductCategory(name,CategoryId) 
Values (N'GỐI MỀN',4)
Insert into ProductCategory(name,CategoryId) 
Values (N'GỐI ÔM ĐÚT TAY',4)
Insert into ProductCategory(name,CategoryId) 
Values (N'GỐI TỰA LƯNG',4)



create table Product
(
	ProductId bigint IDENTITY(1,1) primary key not null,
	Name nvarchar(250),
	Code varchar(50),
	Images nvarchar(250),		
	Price int,
	PromotionPrice int,
	Amounts int  ,
	Detail ntext,--Mô tả--

	ProductCategoryID bigint ,
	CONSTRAINT fk_Product_ProductCategory
	FOREIGN KEY(ProductCategoryID)
	REFERENCES ProductCategory(ProductCategoryId)
	ON DELETE CASCADE
	ON UPDATE CASCADE	
)

Insert into Product(name,Images,Price,PromotionPrice,Amounts,Detail,ProductCategoryID) 
Values (N'GẤU Teddy áo len chân gấu','gau.jpg',490,0,10,N'Gấu Bông TonTon Friends, Nhân vật TonTon quen thuộc với các bạn qua các Sticker dễ thương trên facebook chat, giờ đây đã có phiên bản gấu bông rất dễ thương, Nhân vật Tobi là 1 trong bộ sưu tập Gấu Bông TonTon',1)
Insert into Product(name,Images,Price,PromotionPrice,Amounts,ProductCategoryID) 
Values (N'GẤU Teddy smooth tím đeo nơ','gau-angel-tim-400x400.jpg',290,9,0,1)
Insert into Product(name,Images,Price,PromotionPrice,Amounts,ProductCategoryID) 
Values (N'GẤU Teddy sleep choàng khăn đỏ','gau-deo-tim-400x400.jpg',510,11,0,1)
Insert into Product(name,Images,Price,PromotionPrice,Amounts,ProductCategoryID) 
Values (N'GẤU Teddy áo len Choco','gau-love-400x400.jpg',470,20,10,1)
Insert into Product(name,Images,Price,PromotionPrice,Amounts,ProductCategoryID) 
Values (N'GẤU Teddy áo len cafe sữa','gau-no-love-400x400.jpg',11,470,10,1)

Insert into Product(name,Images,Price,PromotionPrice,Amounts,ProductCategoryID) 
Values (N'GẤU Teddy Angel - Màu Hồng','gau-smooth-ao-len-mat-gau-400x400.jpg',10,420,0,1)




Insert into Product(name,Images,Price,PromotionPrice,Amounts,ProductCategoryID) 
Values (N'Heo Bông Màu Hồng','heo-bong-livheart-3size-400x400.jpg',10,0,10,10)
Insert into Product(name,Images,Price,PromotionPrice,Amounts,ProductCategoryID) 
Values (N'Heo Bông Choàng Khăn','heo-bong-mat-long-lanh-gau-bong-400x400.jpg',220,0,10,10)




Insert into Product(name,Images,Price,PromotionPrice,Amounts,ProductCategoryID) 
Values (N'Heo Bông Màu Hồng','gau-bong-tonton-yuta-400x400.jpg',325,20,10,23)
Insert into Product(name,Images,Price,PromotionPrice,Amounts,ProductCategoryID) 
Values (N'Heo Bông Choàng Khăn','gau-bong-tonton-winne-400x400.jpg',325,20,10,23)
Insert into Product(name,Images,Price,PromotionPrice,Amounts,ProductCategoryID) 
Values (N'Heo Bông Choàng Khăn','gau-bong-tonton-tobi-400x400.jpg',260,20,10,23)



Insert into Product(name,Images,Price,PromotionPrice,Amounts,ProductCategoryID) 
Values (N'Heo Bông Màu Hồng','heo-bong-livheart-3size-400x400.jpg',10,0,10,10)
Insert into Product(name,Images,Price,PromotionPrice,Amounts,ProductCategoryID) 
Values (N'Heo Bông Choàng Khăn','heo-bong-mat-long-lanh-gau-bong-400x400.jpg',220,0,10,10)




Insert into Product(name,Images,Price,PromotionPrice,Amounts,ProductCategoryID) 
Values (N'Heo Bông Màu Hồng','gau-bong-tonton-yuta-400x400.jpg',325,20,10,30)
Insert into Product(name,Images,Price,PromotionPrice,Amounts,ProductCategoryID) 
Values (N'Heo Bông Choàng Khăn','gau-bong-tonton-winne-400x400.jpg',325,20,10,30)
Insert into Product(name,Images,Price,PromotionPrice,Amounts,ProductCategoryID) 
Values (N'Heo Bông Choàng Khăn','gau-bong-tonton-tobi-400x400.jpg',260,20,10,30)
create table HoaDon
(
	MaHoaDon bigint IDENTITY(1,1) primary key not null,
	TenKhach nvarchar(50) ,
	SoDT  varchar(15) ,
	MaHang bigint,
	ghiChu ntext ,
	NgayLap datetime ,
	SoLuong int ,
	XuLy bit ,
	CONSTRAINT fk_HoaDon_HH
	FOREIGN KEY(MaHang)
	REFERENCES Product(ProductId)
	ON DELETE CASCADE
	ON UPDATE CASCADE	
)

create table TaiKhoan
(
	MaTK bigint IDENTITY(1,1) primary key not null,
	UserName varchar(50) ,
	Pass varchar(50)
)

--CSDL tạm 3 bang nay con Khach , SizeSP , HoaDon ... 








