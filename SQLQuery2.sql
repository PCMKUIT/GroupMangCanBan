create database hotelmanager
/*----- TẠO CÁC BẢNG---- */
drop database hotelmanager
use hotelmanager
create table Bill (
         IDbill char(10) PRIMARY KEY ,
	     IDReceiveRoom char(10),
	     StaffSetUp nvarchar(100) ,
	     DateOfCreate smalldatetime ,
	     RoomPrice int ,
	     ServicePrice int ,
	     TotalPrice int ,
	     Discount int ,
	     IDStatusBill int,
	     Surcharge int,
)

CREATE TABLE BillDetails(
	IDbill char(10) ,
	IDService char(10) ,
	soluong int ,
	TotalPrice int ,
	constraint PK_BillDetails  primary key (IDbill,IDService)
)

CREATE TABLE BookRoom(
	IDBookRoom char(10)PRIMARY KEY,
	IDCustomer char(10) ,
	IDRoomType char(10) ,
	DateBookRoom smalldatetime ,
	DateCheckIn date ,
	DateCheckOut date 
)

CREATE TABLE Customer(
	IDCustomer char(10) PRIMARY KEY ,
	IDCard nvarchar(100) ,
	IDCustomerType char(10) ,
	Name nvarchar(100) ,
	DateOfBirth date ,
	Diachi nvarchar(200) ,
	PhoneNumber int ,
	Sex nvarchar(100) ,
	Nationality nvarchar(100) 
)

CREATE TABLE CustomerType(
	IDCustomerType char(10) PRIMARY KEY  ,
	NameCustomerType nvarchar(100) 
)
 CREATE TABLE ReceiveRoom (
	IDReceiveRoom char(10) PRIMARY KEY ,
	IDBookRoom char(10) ,
	IDRoom char(10) 
)

CREATE TABLE Room(
	IDRoom char(10) PRIMARY KEY  ,
	NameRoom nvarchar(100) ,
	IDRoomType char(10) ,
	IDStatusRoom int
)
CREATE TABLE RoomType (
	IDRoomType char(10) PRIMARY KEY ,
	NameRoomType nvarchar(100) ,
	Price int ,
	LimitPerson int 
)
  
CREATE TABLE    [Service] (
	IDService char(10) PRIMARY KEY ,
	NameService nvarchar(200) ,
	IDServiceType char(10) ,
	PriceService int 
) 

CREATE TABLE ServiceType (
	IDServiceType char(10) PRIMARY KEY ,
	NameServiceType nvarchar(100) 
)
--drop table staff
CREATE TABLE Staff (
    IDStaff char(10) PRIMARY KEY ,
	UserName nvarchar(100) ,
	DisplayName nvarchar(100) ,
	[PassWord] nvarchar(100) ,
	IDCardStaff nvarchar(100),
	DateOfBirthStaff date ,
	SexStaff nvarchar(100) ,
	AddressStaff nvarchar(200) ,
	PhoneNumberStaff int ,
	StartDay date ,
	StatusLogin nvarchar(20)
)

CREATE TABLE StatusBill (
	IDStatusBill char(10) PRIMARY KEY,
	NameStatusBill nvarchar(100) 
)

CREATE TABLE StatusRoom(
	IDStatusRoom int PRIMARY KEY ,
	NameStatusRoom nvarchar(100) 
)

CREATE TABLE ChatMessages(
    IDmes INT PRIMARY KEY IDENTITY,
    Message NVARCHAR(4000) NOT NULL,
    Sender NVARCHAR(255) NOT NULL DEFAULT '',
    Timestamp DATETIME NOT NULL DEFAULT GETDATE()
)

/*------ INSERT THÔNG TIN GIẢ VÀO DATABASE-----*/

/* chèn dữ liệu vào bảng customer Type */ select*from CustomerType
INSERT [dbo].[CustomerType] ([IDCustomerType], [NameCustomerType]) VALUES (N'LK001     ', N'Khách du lịch')
INSERT [dbo].[CustomerType] ([IDCustomerType], [NameCustomerType]) VALUES (N'LK002     ', N'Khách địa phương')
INSERT [dbo].[CustomerType] ([IDCustomerType], [NameCustomerType]) VALUES (N'LK003     ', N'Khách vãng lai')
INSERT [dbo].[CustomerType] ([IDCustomerType], [NameCustomerType]) VALUES (N'LK004     ', N'Khách từ bên thứ 3')
/*chèn dữ liệu vào status room */ select*from StatusRoom
INSERT [dbo].[StatusRoom] ([IDStatusRoom], [NameStatusRoom]) VALUES (1, N'Trống')
INSERT [dbo].[StatusRoom] ([IDStatusRoom], [NameStatusRoom]) VALUES (2, N'Có người')
/* chèn dữ liệu vào Status bill */
INSERT [dbo].[StatusBill] ([IDStatusBill], [NameStatusBill]) VALUES (1, N'Chưa thanh toán')
INSERT [dbo].[StatusBill] ([IDStatusBill], [NameStatusBill]) VALUES (2, N'Đã thanh toán')
/* chèn dữ liệu vào service type */
INSERT [dbo].[ServiceType] ([IDServiceType], [NameServiceType]) VALUES (N'LV001     ', N'Thức ăn')
INSERT [dbo].[ServiceType] ([IDServiceType], [NameServiceType]) VALUES (N'LV002     ', N'Giải trí')
INSERT [dbo].[ServiceType] ([IDServiceType], [NameServiceType]) VALUES (N'LV003     ', N'Tiện ích')
INSERT [dbo].[ServiceType] ([IDServiceType], [NameServiceType]) VALUES (N'LV004     ', N'Đồ uống')
/* chèn dữ liệu vào Staff*/ 
-- select*from Staff
-- delete from Staff /*Xóa dữ liệu*/
Select * from staff /*Xuất thông tin*/
INSERT [dbo].[Staff] ([IDStaff],[UserName], [DisplayName], [PassWord],[IDCardStaff], [DateOfBirthStaff], [SexStaff], [AddressStaff], [PhoneNumberStaff], [StartDay], [StatusLogin]) VALUES (N'NV01',N'kietnguyen', N'Nguyen Tuan Kiet', N'0722',  N'079204037544', CAST(N'2004-09-15' AS Date), N'Nam', N'TP HCM', N'0567147852', CAST(N'2024-01-23' AS Date), N'Offline')
INSERT [dbo].[Staff] ([IDStaff],[UserName], [DisplayName], [PassWord],[IDCardStaff], [DateOfBirthStaff], [SexStaff], [AddressStaff], [PhoneNumberStaff], [StartDay], [StatusLogin]) VALUES (N'NV02',N'kienpham', N'Pham Cao Minh Kien', N'0708',  N'079204006599', CAST(N'2004-07-30' AS Date), N'Nam', N'TP HCM', N'0982630623', CAST(N'2024-01-16' AS Date), N'Offline')
INSERT [dbo].[Staff] ([IDStaff],[UserName], [DisplayName], [PassWord],[IDCardStaff], [DateOfBirthStaff], [SexStaff], [AddressStaff], [PhoneNumberStaff], [StartDay], [StatusLogin]) VALUES (N'NV03',N'khoatran', N'Tran Mach Dang Khoa', N'0690', N'079204037566', CAST(N'2004-06-30' AS Date), N'Nam', N'TPHCM',  N'0982873872', CAST(N'2024-01-22' AS Date), N'Offline')
INSERT [dbo].[Staff] ([IDStaff],[UserName], [DisplayName], [PassWord],[IDCardStaff], [DateOfBirthStaff], [SexStaff], [AddressStaff], [PhoneNumberStaff], [StartDay], [StatusLogin]) VALUES (N'NV04',N'khanguyen', N'Nguyen Hoang Duy Kha', N'0597', N'079204037555', CAST(N'2004-06-23' AS Date), N'Nam', N'TPHCM',N'0982873604', CAST(N'2024-01-25' AS Date), N'Offline')
INSERT [dbo].[Staff] ([IDStaff],[UserName], [DisplayName], [PassWord],[IDCardStaff], [DateOfBirthStaff], [SexStaff], [AddressStaff], [PhoneNumberStaff], [StartDay], [StatusLogin]) VALUES (N'NV05',N'admin', N'Administrator', N'admin', N'079204037566', CAST(N'2004-06-30' AS Date), N'Nam', N'TPHCM', N'0982873501', CAST(N'2024-01-20' AS Date), N'Offline')
INSERT [dbo].[Staff] ([IDStaff],[UserName], [DisplayName], [PassWord],[IDCardStaff], [DateOfBirthStaff], [SexStaff], [AddressStaff], [PhoneNumberStaff], [StartDay], [StatusLogin]) VALUES (N'NV06',N'q', N'*', N'q', N'079204037500', CAST(N'2004-06-09' AS Date), N'Nam', N'TPHCM', N'0982876060', CAST(N'2024-01-20' AS Date), N'Offline')
-- /* chèn dữ liệu vào RoomType*/ select* from RoomType
INSERT [dbo].[RoomType] ([IDRoomType], [NameRoomType], [Price], [LimitPerson]) VALUES (N'LP001     ', N'Phòng tổng thống', 15000000, 6)
INSERT [dbo].[RoomType] ([IDRoomType], [NameRoomType], [Price], [LimitPerson]) VALUES (N'LP002     ', N'Phòng đôi', 6500000, 4)
INSERT [dbo].[RoomType] ([IDRoomType], [NameRoomType], [Price], [LimitPerson]) VALUES (N'LP003     ', N'Phòng tiện ích', 2500000, 3)
INSERT [dbo].[RoomType] ([IDRoomType], [NameRoomType], [Price], [LimitPerson]) VALUES (N'LP004     ', N'Phòng tiêu chuẩn', 950000, 2)
/* chèn dữ liệu vào room */
INSERT [dbo].[Room] ([IDRoom], [NameRoom], [IDRoomType], [IDStatusRoom]) VALUES (N'PH001     ', N'Phòng 101', N'LP001     ', 2)
INSERT [dbo].[Room] ([IDRoom], [NameRoom], [IDRoomType], [IDStatusRoom]) VALUES (N'PH002     ', N'Phòng 102', N'LP002     ', 2)
INSERT [dbo].[Room] ([IDRoom], [NameRoom], [IDRoomType], [IDStatusRoom]) VALUES (N'PH003     ', N'Phòng 103', N'LP003     ', 2)
INSERT [dbo].[Room] ([IDRoom], [NameRoom], [IDRoomType], [IDStatusRoom]) VALUES (N'PH004     ', N'Phòng 104', N'LP004     ', 2)
INSERT [dbo].[Room] ([IDRoom], [NameRoom], [IDRoomType], [IDStatusRoom]) VALUES (N'PH005     ', N'Phòng 105', N'LP001     ', 1)
INSERT [dbo].[Room] ([IDRoom], [NameRoom], [IDRoomType], [IDStatusRoom]) VALUES (N'PH006     ', N'Phòng 106', N'LP004     ', 2)
INSERT [dbo].[Room] ([IDRoom], [NameRoom], [IDRoomType], [IDStatusRoom]) VALUES (N'PH007     ', N'Phòng 107', N'LP004     ', 1)
INSERT [dbo].[Room] ([IDRoom], [NameRoom], [IDRoomType], [IDStatusRoom]) VALUES (N'PH008     ', N'Phòng 108', N'LP004     ', 2)
INSERT [dbo].[Room] ([IDRoom], [NameRoom], [IDRoomType], [IDStatusRoom]) VALUES (N'PH009     ', N'Phòng 109', N'LP003     ', 2)
INSERT [dbo].[Room] ([IDRoom], [NameRoom], [IDRoomType], [IDStatusRoom]) VALUES (N'PH010     ', N'Phòng 201', N'LP003     ', 2)
INSERT [dbo].[Room] ([IDRoom], [NameRoom], [IDRoomType], [IDStatusRoom]) VALUES (N'PH011     ', N'Phòng 202', N'LP003     ', 2)
INSERT [dbo].[Room] ([IDRoom], [NameRoom], [IDRoomType], [IDStatusRoom]) VALUES (N'PH012     ', N'Phòng 203', N'LP002     ', 2)
INSERT [dbo].[Room] ([IDRoom], [NameRoom], [IDRoomType], [IDStatusRoom]) VALUES (N'PH013     ', N'Phòng 204', N'LP002     ', 1)
INSERT [dbo].[Room] ([IDRoom], [NameRoom], [IDRoomType], [IDStatusRoom]) VALUES (N'PH014     ', N'Phòng 205', N'LP004     ', 2)
INSERT [dbo].[Room] ([IDRoom], [NameRoom], [IDRoomType], [IDStatusRoom]) VALUES (N'PH015     ', N'Phòng 206', N'LP003     ', 1)
INSERT [dbo].[Room] ([IDRoom], [NameRoom], [IDRoomType], [IDStatusRoom]) VALUES (N'PH016     ', N'Phòng 207', N'LP002     ', 1)
INSERT [dbo].[Room] ([IDRoom], [NameRoom], [IDRoomType], [IDStatusRoom]) VALUES (N'PH017     ', N'Phòng 208', N'LP004     ', 2)
INSERT [dbo].[Room] ([IDRoom], [NameRoom], [IDRoomType], [IDStatusRoom]) VALUES (N'PH018     ', N'Phòng 209', N'LP002     ', 1)
INSERT [dbo].[Room] ([IDRoom], [NameRoom], [IDRoomType], [IDStatusRoom]) VALUES (N'PH019     ', N'Phòng 210', N'LP004     ', 1)
INSERT [dbo].[Room] ([IDRoom], [NameRoom], [IDRoomType], [IDStatusRoom]) VALUES (N'PH020     ', N'Phòng 211', N'LP004     ', 1)
INSERT [dbo].[Room] ([IDRoom], [NameRoom], [IDRoomType], [IDStatusRoom]) VALUES (N'PH021     ', N'Phòng 212', N'LP003     ', 1)

/* chèn dữ liệu vào service */ select*from [Service]
INSERT [dbo].[Service] ([IDService], [NameService], [IDServiceType], [PriceService]) VALUES (N'DV001     ', N'Chăm sóc da', N'LV002     ', 1200000)
INSERT [dbo].[Service] ([IDService], [NameService], [IDServiceType], [PriceService]) VALUES (N'DV002     ', N'Tập thể hình', N'LV002     ', 100000)
INSERT [dbo].[Service] ([IDService], [NameService], [IDServiceType], [PriceService]) VALUES (N'DV003     ', N'Bò Xào Trứng hành', N'LV001     ', 200000)
INSERT [dbo].[Service] ([IDService], [NameService], [IDServiceType], [PriceService]) VALUES (N'DV004     ', N'Karaoke', N'LV002     ', 1000000)
INSERT [dbo].[Service] ([IDService], [NameService], [IDServiceType], [PriceService]) VALUES (N'DV005     ', N'Giặt ủi quần áo', N'LV003     ', 150000)
INSERT [dbo].[Service] ([IDService], [NameService], [IDServiceType], [PriceService]) VALUES (N'DV006     ', N'Dịch vụ xe đưa đón sân bay', N'LV003     ', 200000)
INSERT [dbo].[Service] ([IDService], [NameService], [IDServiceType], [PriceService]) VALUES (N'DV007     ', N'Dịch vụ cho thuê xe', N'LV003     ', 500000)
INSERT [dbo].[Service] ([IDService], [NameService], [IDServiceType], [PriceService]) VALUES (N'DV008     ', N'Dịch vụ giữ trẻ ', N'LV003     ', 800000)
INSERT [dbo].[Service] ([IDService], [NameService], [IDServiceType], [PriceService]) VALUES (N'DV009     ', N'Dịch vụ thuê hồ bơi', N'LV002     ', 1000000)
INSERT [dbo].[Service] ([IDService], [NameService], [IDServiceType], [PriceService]) VALUES (N'DV010     ', N'Dịch vụ thuê sân tennis', N'LV002     ', 500000)
INSERT [dbo].[Service] ([IDService], [NameService], [IDServiceType], [PriceService]) VALUES (N'DV011     ', N'Lẩu hải sản cao cấp 1 không 2', N'LV001     ', 500000)
INSERT [dbo].[Service] ([IDService], [NameService], [IDServiceType], [PriceService]) VALUES (N'DV012     ', N'Súp cua bào ngư', N'LV001     ', 200000)
INSERT [dbo].[Service] ([IDService], [NameService], [IDServiceType], [PriceService]) VALUES (N'DV013     ', N'Cua hoàng đế', N'LV001     ', 2000000)
INSERT [dbo].[Service] ([IDService], [NameService], [IDServiceType], [PriceService]) VALUES (N'DV014     ', N'chè dưỡng nhan', N'LV001     ', 50000)
INSERT [dbo].[Service] ([IDService], [NameService], [IDServiceType], [PriceService]) VALUES (N'DV015     ', N'Cơm chiên hoàng gia', N'LV001     ', 500000)
INSERT [dbo].[Service] ([IDService], [NameService], [IDServiceType], [PriceService]) VALUES (N'DV016     ', N'Súp cua trứng bách thảo lớn', N'LV001     ', 150000)
INSERT [dbo].[Service] ([IDService], [NameService], [IDServiceType], [PriceService]) VALUES (N'DV017     ', N'Cơm chiên dương châu', N'LV001     ', 75000)
INSERT [dbo].[Service] ([IDService], [NameService], [IDServiceType], [PriceService]) VALUES (N'DV018     ', N'Bánh kem dâu tây', N'LV001     ', 50000)
INSERT [dbo].[Service] ([IDService], [NameService], [IDServiceType], [PriceService]) VALUES (N'DV019     ', N'Combo gia đình 10 người ăn', N'LV001     ', 1800000)
INSERT [dbo].[Service] ([IDService], [NameService], [IDServiceType], [PriceService]) VALUES (N'DV020     ', N'Rược đế', N'LV004     ', 500000)
INSERT [dbo].[Service] ([IDService], [NameService], [IDServiceType], [PriceService]) VALUES (N'DV021     ', N'Combo gia đình 4 người ăn', N'LV001     ', 1200000)
INSERT [dbo].[Service] ([IDService], [NameService], [IDServiceType], [PriceService]) VALUES (N'DV022     ', N'nước ngọt các loại', N'LV004     ', 15000)
INSERT [dbo].[Service] ([IDService], [NameService], [IDServiceType], [PriceService]) VALUES (N'DV023     ', N'Cam vắt', N'LV004     ', 30000)
INSERT [dbo].[Service] ([IDService], [NameService], [IDServiceType], [PriceService]) VALUES (N'DV024     ', N'cà phê đen phin', N'LV004     ', 30000)
INSERT [dbo].[Service] ([IDService], [NameService], [IDServiceType], [PriceService]) VALUES (N'DV025     ', N'cà phê sữa ', N'LV004     ', 30000)
INSERT [dbo].[Service] ([IDService], [NameService], [IDServiceType], [PriceService]) VALUES (N'DV026     ', N'Lẩu dê', N'LV001     ', 100000)
INSERT [dbo].[Service] ([IDService], [NameService], [IDServiceType], [PriceService]) VALUES (N'DV027     ', N'Combo dimsum cao cấo', N'LV001     ', 1000000)
INSERT [dbo].[Service] ([IDService], [NameService], [IDServiceType], [PriceService]) VALUES (N'DV028     ', N'Cháo gà', N'LV001     ', 100000)
INSERT [dbo].[Service] ([IDService], [NameService], [IDServiceType], [PriceService]) VALUES (N'DV029     ', N'Cháo vịt', N'LV001     ', 200000)
INSERT [dbo].[Service] ([IDService], [NameService], [IDServiceType], [PriceService]) VALUES (N'DV030     ', N'Trà chanh', N'LV004     ', 25000)

/* chèn thông tin customer */ select*from Customer
INSERT [dbo].[Customer] ([IDCustomer], [IDCard], [IDCustomerType], [Name], [DateOfBirth], [Diachi], [PhoneNumber], [Sex], [Nationality]) VALUES (N'KH001     ', N'16520147', N'LK002     ', N'Phạm Cao Minh Kiên', CAST(N'2004-04-06' AS Date), N'Quận Gò vấp TPHCM', 0935786534, N'Nam', N'Việt Nam')
INSERT [dbo].[Customer] ([IDCustomer], [IDCard], [IDCustomerType], [Name], [DateOfBirth], [Diachi], [PhoneNumber], [Sex], [Nationality]) VALUES (N'KH002     ', N'206117926', N'LK003     ', N'Nguyễn Thị Trà My', CAST(N'2000-04-06' AS Date), N'Nha Trang', 1648222347, N'Nữ', N'Việt Nam')
INSERT [dbo].[Customer] ([IDCustomer], [IDCard], [IDCustomerType], [Name], [DateOfBirth], [Diachi], [PhoneNumber], [Sex], [Nationality]) VALUES (N'KH003     ', N'123456', N'LK002     ', N'Mai Thanh Thảo', CAST(N'1995-04-06' AS Date), N'Khánh Hòa', 1648222347, N'Nữ', N'Việt Nam')
INSERT [dbo].[Customer] ([IDCustomer], [IDCard], [IDCustomerType], [Name], [DateOfBirth], [Diachi], [PhoneNumber], [Sex], [Nationality]) VALUES (N'KH004     ', N'12782389', N'LK001     ', N'Bùi Tường Vân', CAST(N'1997-04-06' AS Date), N'Hà Nội', 12782389, N'Nữ', N'Việt Nam')
INSERT [dbo].[Customer] ([IDCustomer], [IDCard], [IDCustomerType], [Name], [DateOfBirth], [Diachi], [PhoneNumber], [Sex], [Nationality]) VALUES (N'KH005     ', N'2563', N'LK001     ', N'Lê Minh Triết', CAST(N'2004-04-06' AS Date), N'Nghệ An', 147852, N'Nam', N'Việt Nam')
INSERT [dbo].[Customer] ([IDCustomer], [IDCard], [IDCustomerType], [Name], [DateOfBirth], [Diachi], [PhoneNumber], [Sex], [Nationality]) VALUES (N'KH006     ', N'123456788', N'LK001     ', N'Nguyễn Văn Thịnh', CAST(N'2004-04-06' AS Date), N'TP HCM', 123456789, N'Nam', N'Việt Nam')
INSERT [dbo].[Customer] ([IDCustomer], [IDCard], [IDCustomerType], [Name], [DateOfBirth], [Diachi], [PhoneNumber], [Sex], [Nationality]) VALUES (N'KH007     ', N'123456787', N'LK001     ', N'Nguyễn Trần Duy Cương', CAST(N'2004-04-06' AS Date), N'Tam Kỳ', 123456785, N'Nam', N'Hoa Kỳ')
INSERT [dbo].[Customer] ([IDCustomer], [IDCard], [IDCustomerType], [Name], [DateOfBirth], [Diachi], [PhoneNumber], [Sex], [Nationality]) VALUES (N'KH008     ', N'27263950', N'LK001     ', N'Nguyễn Thị Lan Cẩm Tú', CAST(N'2004-04-06' AS Date), N'Nha Trang', 966144938, N'Nữ', N'Trung Quốc')
INSERT [dbo].[Customer] ([IDCustomer], [IDCard], [IDCustomerType], [Name], [DateOfBirth], [Diachi], [PhoneNumber], [Sex], [Nationality]) VALUES (N'KH009     ', N'145236', N'LK001     ', N'Phạm Băng Băng', CAST(N'2004-04-06' AS Date), N'Nha Trang', 1655201124, N'Nữ', N'Việt Nam')
INSERT [dbo].[Customer] ([IDCustomer], [IDCard], [IDCustomerType], [Name], [DateOfBirth], [Diachi], [PhoneNumber], [Sex], [Nationality]) VALUES (N'KH010     ', N'96852361', N'LK001     ', N'Phạm Lửa Lửa', CAST(N'2004-04-06' AS Date), N'Nha Trang', 145230, N'Nữ', N'Việt Nam')
INSERT [dbo].[Customer] ([IDCustomer], [IDCard], [IDCustomerType], [Name], [DateOfBirth], [Diachi], [PhoneNumber], [Sex], [Nationality]) VALUES (N'KH011     ', N'123458523', N'LK001     ', N'Nguyễn Văn Anh', CAST(N'2004-04-06' AS Date), N'TP HCM', 123452367, N'Nam', N'Việt Nam')
INSERT [dbo].[Customer] ([IDCustomer], [IDCard], [IDCustomerType], [Name], [DateOfBirth], [Diachi], [PhoneNumber], [Sex], [Nationality]) VALUES (N'KH012     ', N'963587', N'LK003     ', N'Trấn Thành', CAST(N'2004-04-06' AS Date), N'Hà Nội', 164853564, N'Nam', N'Việt Nam')
INSERT [dbo].[Customer] ([IDCustomer], [IDCard], [IDCustomerType], [Name], [DateOfBirth], [Diachi], [PhoneNumber], [Sex], [Nationality]) VALUES (N'KH013     ', N'191911727', N'LK002     ', N'Hồ Ngọc Hà', CAST(N'2004-04-06' AS Date), N'Huế', 912472758, N'Nữ', N'Việt Nam')
INSERT [dbo].[Customer] ([IDCustomer], [IDCard], [IDCustomerType], [Name], [DateOfBirth], [Diachi], [PhoneNumber], [Sex], [Nationality]) VALUES (N'KH014     ', N'191911111', N'LK003     ', N'Nguyễn Văn An', CAST(N'2004-04-06' AS Date), N'Đà Nẵng', 888888888, N'Nam', N'Việt Nam')
INSERT [dbo].[Customer] ([IDCustomer], [IDCard], [IDCustomerType], [Name], [DateOfBirth], [Diachi], [PhoneNumber], [Sex], [Nationality]) VALUES (N'KH015     ', N'191911777', N'LK004     ', N'Trần Diệu Hiền', CAST(N'2004-04-06' AS Date), N'Đà Nẵng', 999999999, N'Nữ', N'Việt Nam')
INSERT [dbo].[Customer] ([IDCustomer], [IDCard], [IDCustomerType], [Name], [DateOfBirth], [Diachi], [PhoneNumber], [Sex], [Nationality]) VALUES (N'KH016     ', N'1919191919', N'LK001     ', N'Hoàng Việt Trinh', CAST(N'2004-04-06' AS Date), N'Đà Nẵng', 777777777, N'Nữ', N'Việt Nam')
INSERT [dbo].[Customer] ([IDCustomer], [IDCard], [IDCustomerType], [Name], [DateOfBirth], [Diachi], [PhoneNumber], [Sex], [Nationality]) VALUES (N'KH017     ', N'191900000', N'LK002     ', N'Lê Thủy', CAST(N'2004-04-06' AS Date), N'TP HCM', 982981832, N'Nữ', N'Việt Nam')
INSERT [dbo].[Customer] ([IDCustomer], [IDCard], [IDCustomerType], [Name], [DateOfBirth], [Diachi], [PhoneNumber], [Sex], [Nationality]) VALUES (N'KH018     ', N'191922222', N'LK004     ', N'Trần Minh Anh', CAST(N'2004-04-06' AS Date), N'TP HCM', 912873843, N'Nữ', N'Việt Nam')
INSERT [dbo].[Customer] ([IDCustomer], [IDCard], [IDCustomerType], [Name], [DateOfBirth], [Diachi], [PhoneNumber], [Sex], [Nationality]) VALUES (N'KH019     ', N'191900011', N'LK001     ', N'Hoàng Thu Hải', CAST(N'2004-04-06' AS Date), N'TP HCM', 987236232, N'Nữ', N'Việt Nam')
INSERT [dbo].[Customer] ([IDCustomer], [IDCard], [IDCustomerType], [Name], [DateOfBirth], [Diachi], [PhoneNumber], [Sex], [Nationality]) VALUES (N'KH020     ', N'191966666', N'LK002     ', N'Trần Tấn Hoàng', CAST(N'2004-04-06' AS Date), N'TP HCM', 988273232, N'Nam', N'Việt Nam')
INSERT [dbo].[Customer] ([IDCustomer], [IDCard], [IDCustomerType], [Name], [DateOfBirth], [Diachi], [PhoneNumber], [Sex], [Nationality]) VALUES (N'KH021     ', N'191966677', N'LK002     ', N'Trần Minh', CAST(N'2004-04-06' AS Date), N'TP HCM', 988786434, N'Nam', N'Việt Nam')
INSERT [dbo].[Customer] ([IDCustomer], [IDCard], [IDCustomerType], [Name], [DateOfBirth], [Diachi], [PhoneNumber], [Sex], [Nationality]) VALUES (N'KH022     ', N'191977777', N'LK001     ', N'Hoàng Ánh Tuyết', CAST(N'2004-04-06' AS Date), N'TP HCM', 98837273, N'Nữ', N'Việt Nam')
INSERT [dbo].[Customer] ([IDCustomer], [IDCard], [IDCustomerType], [Name], [DateOfBirth], [Diachi], [PhoneNumber], [Sex], [Nationality]) VALUES (N'KH023     ', N'12121212', N'LK002     ', N'Nguyễn Thúy', CAST(N'2004-04-06' AS Date), N'TP HCM', 93028390, N'Nữ', N'Việt Nam')
INSERT [dbo].[Customer] ([IDCustomer], [IDCard], [IDCustomerType], [Name], [DateOfBirth], [Diachi], [PhoneNumber], [Sex], [Nationality]) VALUES (N'KH024     ', N'13131313', N'LK003     ', N'Trần Ngọc Minh', CAST(N'2004-04-06' AS Date), N'TP HCM', 988329783, N'Nam', N'Việt Nam')
INSERT [dbo].[Customer] ([IDCustomer], [IDCard], [IDCustomerType], [Name], [DateOfBirth], [Diachi], [PhoneNumber], [Sex], [Nationality]) VALUES (N'KH025     ', N'14141414', N'LK004     ', N'Nguyễn Thị Em', CAST(N'2004-04-06' AS Date), N'TP HCM', 929839248, N'Nữ', N'Việt Nam')
INSERT [dbo].[Customer] ([IDCustomer], [IDCard], [IDCustomerType], [Name], [DateOfBirth], [Diachi], [PhoneNumber], [Sex], [Nationality]) VALUES (N'KH026     ', N'191984512', N'LK004     ', N'Trần Nhật Đăng', CAST(N'2004-04-06' AS Date), N'TP HCM', 987364732, N'Nam', N'Việt Nam')
SELECT * 
FROM information_schema.tables 
WHERE table_type = 'BASE TABLE';
/* chèn thông tin receiroom */ SELECT*FROM RECEIVEROOM
INSERT [dbo].[ReceiveRoom] ([IDReceiveRoom], [IDBookRoom], [IDRoom]) VALUES (N'PN001     ', N'DP001     ', N'PH001     ')
INSERT [dbo].[ReceiveRoom] ([IDReceiveRoom], [IDBookRoom], [IDRoom]) VALUES (N'PN002     ', N'DP002     ', N'PH002     ')
INSERT [dbo].[ReceiveRoom] ([IDReceiveRoom], [IDBookRoom], [IDRoom]) VALUES (N'PN003     ', N'DP003     ', N'PH003     ')
INSERT [dbo].[ReceiveRoom] ([IDReceiveRoom], [IDBookRoom], [IDRoom]) VALUES (N'PN004     ', N'DP004     ', N'PH004     ')
INSERT [dbo].[ReceiveRoom] ([IDReceiveRoom], [IDBookRoom], [IDRoom]) VALUES (N'PN005     ', N'DP005     ', N'PH005     ')
INSERT [dbo].[ReceiveRoom] ([IDReceiveRoom], [IDBookRoom], [IDRoom]) VALUES (N'PN006     ', N'DP006     ', N'PH006     ')
INSERT [dbo].[ReceiveRoom] ([IDReceiveRoom], [IDBookRoom], [IDRoom]) VALUES (N'PN007     ', N'DP007     ', N'PH007     ')
INSERT [dbo].[ReceiveRoom] ([IDReceiveRoom], [IDBookRoom], [IDRoom]) VALUES (N'PN008     ', N'DP008     ', N'PH008     ')
INSERT [dbo].[ReceiveRoom] ([IDReceiveRoom], [IDBookRoom], [IDRoom]) VALUES (N'PN009     ', N'DP009     ', N'PH009     ')
INSERT [dbo].[ReceiveRoom] ([IDReceiveRoom], [IDBookRoom], [IDRoom]) VALUES (N'PN010     ', N'DP010     ', N'PH005     ')
INSERT [dbo].[ReceiveRoom] ([IDReceiveRoom], [IDBookRoom], [IDRoom]) VALUES (N'PN011     ', N'DP011     ', N'PH006     ')
INSERT [dbo].[ReceiveRoom] ([IDReceiveRoom], [IDBookRoom], [IDRoom]) VALUES (N'PN012     ', N'DP012     ', N'PH012     ')
INSERT [dbo].[ReceiveRoom] ([IDReceiveRoom], [IDBookRoom], [IDRoom]) VALUES (N'PN013     ', N'DP013     ', N'PH009     ')
INSERT [dbo].[ReceiveRoom] ([IDReceiveRoom], [IDBookRoom], [IDRoom]) VALUES (N'PN014     ', N'DP014     ', N'PH013     ')
INSERT [dbo].[ReceiveRoom] ([IDReceiveRoom], [IDBookRoom], [IDRoom]) VALUES (N'PN015     ', N'DP015     ', N'PH016     ')
INSERT [dbo].[ReceiveRoom] ([IDReceiveRoom], [IDBookRoom], [IDRoom]) VALUES (N'PN016     ', N'DP016     ', N'PH001     ')
INSERT [dbo].[ReceiveRoom] ([IDReceiveRoom], [IDBookRoom], [IDRoom]) VALUES (N'PN017     ', N'DP017     ', N'PH018     ')
INSERT [dbo].[ReceiveRoom] ([IDReceiveRoom], [IDBookRoom], [IDRoom]) VALUES (N'PN018     ', N'DP018     ', N'PH007     ')
INSERT [dbo].[ReceiveRoom] ([IDReceiveRoom], [IDBookRoom], [IDRoom]) VALUES (N'PN019     ', N'DP019     ', N'PH008     ')
INSERT [dbo].[ReceiveRoom] ([IDReceiveRoom], [IDBookRoom], [IDRoom]) VALUES (N'PN020     ', N'DP020     ', N'PH014     ')
INSERT [dbo].[ReceiveRoom] ([IDReceiveRoom], [IDBookRoom], [IDRoom]) VALUES (N'PN021     ', N'DP025     ', N'PH006     ')
INSERT [dbo].[ReceiveRoom] ([IDReceiveRoom], [IDBookRoom], [IDRoom]) VALUES (N'PN022     ', N'DP025     ', N'PH009     ')
INSERT [dbo].[ReceiveRoom] ([IDReceiveRoom], [IDBookRoom], [IDRoom]) VALUES (N'PN023     ', N'DP025     ', N'PH011     ')
INSERT [dbo].[ReceiveRoom] ([IDReceiveRoom], [IDBookRoom], [IDRoom]) VALUES (N'PN024     ', N'DP026     ', N'PH001     ')
INSERT [dbo].[ReceiveRoom] ([IDReceiveRoom], [IDBookRoom], [IDRoom]) VALUES (N'PN025     ', N'DP027     ', N'PH013     ')
INSERT [dbo].[ReceiveRoom] ([IDReceiveRoom], [IDBookRoom], [IDRoom]) VALUES (N'PN026     ', N'DP029     ', N'PH009     ')
INSERT [dbo].[ReceiveRoom] ([IDReceiveRoom], [IDBookRoom], [IDRoom]) VALUES (N'PN027     ', N'DP031     ', N'PH001     ')
INSERT [dbo].[ReceiveRoom] ([IDReceiveRoom], [IDBookRoom], [IDRoom]) VALUES (N'PN028     ', N'DP032     ', N'PH005     ')
INSERT [dbo].[ReceiveRoom] ([IDReceiveRoom], [IDBookRoom], [IDRoom]) VALUES (N'PN029     ', N'DP033     ', N'PH009     ')
INSERT [dbo].[ReceiveRoom] ([IDReceiveRoom], [IDBookRoom], [IDRoom]) VALUES (N'PN030     ', N'DP034     ', N'PH009     ')
INSERT [dbo].[ReceiveRoom] ([IDReceiveRoom], [IDBookRoom], [IDRoom]) VALUES (N'PN031     ', N'DP036     ', N'PH011     ')
INSERT [dbo].[ReceiveRoom] ([IDReceiveRoom], [IDBookRoom], [IDRoom]) VALUES (N'PN032     ', N'DP035     ', N'PH006     ')
INSERT [dbo].[ReceiveRoom] ([IDReceiveRoom], [IDBookRoom], [IDRoom]) VALUES (N'PN033     ', N'DP037     ', N'PH012     ')
INSERT [dbo].[ReceiveRoom] ([IDReceiveRoom], [IDBookRoom], [IDRoom]) VALUES (N'PN034     ', N'DP038     ', N'PH001     ')
INSERT [dbo].[ReceiveRoom] ([IDReceiveRoom], [IDBookRoom], [IDRoom]) VALUES (N'PN035     ', N'DP039     ', N'PH001     ')
INSERT [dbo].[ReceiveRoom] ([IDReceiveRoom], [IDBookRoom], [IDRoom]) VALUES (N'PN036     ', N'DP042     ', N'PH005     ')
/* chèn thông tin book room*/ select*from bookroom
INSERT [dbo].[BookRoom] ([IDBookRoom], [IDCustomer], [IDRoomType], [DateBookRoom], [DateCheckIn], [DateCheckOut]) VALUES (N'DP001     ', N'KH004     ', N'LP001     ', CAST(N'2024-05-21T18:12:00' AS SmallDateTime), CAST(N'2024-05-21' AS Date), CAST(N'2024-05-28' AS Date))
INSERT [dbo].[BookRoom] ([IDBookRoom], [IDCustomer], [IDRoomType], [DateBookRoom], [DateCheckIn], [DateCheckOut]) VALUES (N'DP002     ', N'KH010     ', N'LP001     ', CAST(N'2024-05-21T18:13:00' AS SmallDateTime), CAST(N'2024-05-21' AS Date), CAST(N'2024-05-29' AS Date))
INSERT [dbo].[BookRoom] ([IDBookRoom], [IDCustomer], [IDRoomType], [DateBookRoom], [DateCheckIn], [DateCheckOut]) VALUES (N'DP003     ', N'KH001     ', N'LP001     ', CAST(N'2024-05-21T18:14:00' AS SmallDateTime), CAST(N'2024-05-21' AS Date), CAST(N'2024-05-27' AS Date))
INSERT [dbo].[BookRoom] ([IDBookRoom], [IDCustomer], [IDRoomType], [DateBookRoom], [DateCheckIn], [DateCheckOut]) VALUES (N'DP004     ', N'KH005     ', N'LP004     ', CAST(N'2024-05-21T18:15:00' AS SmallDateTime), CAST(N'2024-05-21' AS Date), CAST(N'2024-05-30' AS Date))
INSERT [dbo].[BookRoom] ([IDBookRoom], [IDCustomer], [IDRoomType], [DateBookRoom], [DateCheckIn], [DateCheckOut]) VALUES (N'DP005     ', N'KH011     ', N'LP004     ', CAST(N'2024-05-05T18:38:00' AS SmallDateTime), CAST(N'2024-05-05' AS Date), CAST(N'2024-05-18' AS Date))
INSERT [dbo].[BookRoom] ([IDBookRoom], [IDCustomer], [IDRoomType], [DateBookRoom], [DateCheckIn], [DateCheckOut]) VALUES (N'DP006     ', N'KH013     ', N'LP004     ', CAST(N'2024-05-10T01:54:00' AS SmallDateTime), CAST(N'2024-05-10' AS Date), CAST(N'2024-05-18' AS Date))
INSERT [dbo].[BookRoom] ([IDBookRoom], [IDCustomer], [IDRoomType], [DateBookRoom], [DateCheckIn], [DateCheckOut]) VALUES (N'DP007     ', N'KH003     ', N'LP003     ', CAST(N'2024-05-04T02:27:00' AS SmallDateTime), CAST(N'2024-05-04' AS Date), CAST(N'2024-05-10' AS Date))
INSERT [dbo].[BookRoom] ([IDBookRoom], [IDCustomer], [IDRoomType], [DateBookRoom], [DateCheckIn], [DateCheckOut]) VALUES (N'DP008     ', N'KH006     ', N'LP002     ', CAST(N'2024-05-13T22:45:00' AS SmallDateTime), CAST(N'2024-05-13' AS Date), CAST(N'2024-05-29' AS Date))
INSERT [dbo].[BookRoom] ([IDBookRoom], [IDCustomer], [IDRoomType], [DateBookRoom], [DateCheckIn], [DateCheckOut]) VALUES (N'DP009     ', N'KH007     ', N'LP002     ', CAST(N'2024-05-14T09:32:00' AS SmallDateTime), CAST(N'2024-05-14' AS Date), CAST(N'2024-05-29' AS Date))
INSERT [dbo].[BookRoom] ([IDBookRoom], [IDCustomer], [IDRoomType], [DateBookRoom], [DateCheckIn], [DateCheckOut]) VALUES (N'DP010     ', N'KH008     ', N'LP004     ', CAST(N'2024-05-14T09:33:00' AS SmallDateTime), CAST(N'2024-05-14' AS Date), CAST(N'2024-05-19' AS Date))
INSERT [dbo].[BookRoom] ([IDBookRoom], [IDCustomer], [IDRoomType], [DateBookRoom], [DateCheckIn], [DateCheckOut]) VALUES (N'DP011     ', N'KH009     ', N'LP003     ', CAST(N'2024-05-14T09:35:00' AS SmallDateTime), CAST(N'2024-05-14' AS Date), CAST(N'2024-06-17' AS Date))
INSERT [dbo].[BookRoom] ([IDBookRoom], [IDCustomer], [IDRoomType], [DateBookRoom], [DateCheckIn], [DateCheckOut]) VALUES (N'DP012     ', N'KH010     ', N'LP003     ', CAST(N'2024-05-14T09:36:00' AS SmallDateTime), CAST(N'2024-05-14' AS Date), CAST(N'2024-05-27' AS Date))
INSERT [dbo].[BookRoom] ([IDBookRoom], [IDCustomer], [IDRoomType], [DateBookRoom], [DateCheckIn], [DateCheckOut]) VALUES (N'DP013     ', N'KH012     ', N'LP003     ', CAST(N'2024-05-14T09:39:00' AS SmallDateTime), CAST(N'2024-05-14' AS Date), CAST(N'2024-05-06' AS Date))
INSERT [dbo].[BookRoom] ([IDBookRoom], [IDCustomer], [IDRoomType], [DateBookRoom], [DateCheckIn], [DateCheckOut]) VALUES (N'DP014     ', N'KH017     ', N'LP003     ', CAST(N'2024-05-16T22:17:00' AS SmallDateTime), CAST(N'2024-05-16' AS Date), CAST(N'2024-05-21' AS Date))
INSERT [dbo].[BookRoom] ([IDBookRoom], [IDCustomer], [IDRoomType], [DateBookRoom], [DateCheckIn], [DateCheckOut]) VALUES (N'DP015     ', N'KH018     ', N'LP002     ', CAST(N'2024-05-16T22:29:00' AS SmallDateTime), CAST(N'2024-05-16' AS Date), CAST(N'2024-05-26' AS Date))
INSERT [dbo].[BookRoom] ([IDBookRoom], [IDCustomer], [IDRoomType], [DateBookRoom], [DateCheckIn], [DateCheckOut]) VALUES (N'DP016     ', N'KH019     ', N'LP004     ', CAST(N'2024-05-16T22:38:00' AS SmallDateTime), CAST(N'2024-05-16' AS Date), CAST(N'2024-05-29' AS Date))
INSERT [dbo].[BookRoom] ([IDBookRoom], [IDCustomer], [IDRoomType], [DateBookRoom], [DateCheckIn], [DateCheckOut]) VALUES (N'DP017     ', N'KH020     ', N'LP002     ', CAST(N'2024-05-16T22:38:00' AS SmallDateTime), CAST(N'2024-05-16' AS Date), CAST(N'2024-05-28' AS Date))
INSERT [dbo].[BookRoom] ([IDBookRoom], [IDCustomer], [IDRoomType], [DateBookRoom], [DateCheckIn], [DateCheckOut]) VALUES (N'DP018     ', N'KH018     ', N'LP004     ', CAST(N'2024-05-16T22:39:00' AS SmallDateTime), CAST(N'2024-05-16' AS Date), CAST(N'2024-05-30' AS Date))
INSERT [dbo].[BookRoom] ([IDBookRoom], [IDCustomer], [IDRoomType], [DateBookRoom], [DateCheckIn], [DateCheckOut]) VALUES (N'DP019     ', N'KH021     ', N'LP003     ', CAST(N'2024-05-17T09:50:00' AS SmallDateTime), CAST(N'2024-05-17' AS Date), CAST(N'2024-05-22' AS Date))
INSERT [dbo].[BookRoom] ([IDBookRoom], [IDCustomer], [IDRoomType], [DateBookRoom], [DateCheckIn], [DateCheckOut]) VALUES (N'DP020     ', N'KH013     ', N'LP004     ', CAST(N'2024-05-18T09:12:00' AS SmallDateTime), CAST(N'2024-05-18' AS Date), CAST(N'2024-05-20' AS Date))
INSERT [dbo].[BookRoom] ([IDBookRoom], [IDCustomer], [IDRoomType], [DateBookRoom], [DateCheckIn], [DateCheckOut]) VALUES (N'DP021     ', N'KH014     ', N'LP003     ', CAST(N'2024-05-19T22:11:00' AS SmallDateTime), CAST(N'2024-05-19' AS Date), CAST(N'2024-05-30' AS Date))
INSERT [dbo].[BookRoom] ([IDBookRoom], [IDCustomer], [IDRoomType], [DateBookRoom], [DateCheckIn], [DateCheckOut]) VALUES (N'DP022     ', N'KH017     ', N'LP002     ', CAST(N'2024-05-19T22:11:00' AS SmallDateTime), CAST(N'2024-05-19' AS Date), CAST(N'2024-05-22' AS Date))
INSERT [dbo].[BookRoom] ([IDBookRoom], [IDCustomer], [IDRoomType], [DateBookRoom], [DateCheckIn], [DateCheckOut]) VALUES (N'DP023     ', N'KH018     ', N'LP003     ', CAST(N'2024-05-19T22:12:00' AS SmallDateTime), CAST(N'2024-05-19' AS Date), CAST(N'2024-05-28' AS Date))
INSERT [dbo].[BookRoom] ([IDBookRoom], [IDCustomer], [IDRoomType], [DateBookRoom], [DateCheckIn], [DateCheckOut]) VALUES (N'DP024     ', N'KH022     ', N'LP003     ', CAST(N'2024-05-19T22:12:00' AS SmallDateTime), CAST(N'2024-05-19' AS Date), CAST(N'2024-05-26' AS Date))
INSERT [dbo].[BookRoom] ([IDBookRoom], [IDCustomer], [IDRoomType], [DateBookRoom], [DateCheckIn], [DateCheckOut]) VALUES (N'DP025     ', N'KH020     ', N'LP004     ', CAST(N'2024-05-19T22:14:00' AS SmallDateTime), CAST(N'2024-05-19' AS Date), CAST(N'2024-05-28' AS Date))
INSERT [dbo].[BookRoom] ([IDBookRoom], [IDCustomer], [IDRoomType], [DateBookRoom], [DateCheckIn], [DateCheckOut]) VALUES (N'DP026     ', N'KH013     ', N'LP001     ', CAST(N'2024-05-21T18:09:00' AS SmallDateTime), CAST(N'2024-05-21' AS Date), CAST(N'2024-05-28' AS Date))
INSERT [dbo].[BookRoom] ([IDBookRoom], [IDCustomer], [IDRoomType], [DateBookRoom], [DateCheckIn], [DateCheckOut]) VALUES (N'DP027     ', N'KH014     ', N'LP002     ', CAST(N'2024-05-21T18:10:00' AS SmallDateTime), CAST(N'2024-05-21' AS Date), CAST(N'2024-05-25' AS Date))
INSERT [dbo].[BookRoom] ([IDBookRoom], [IDCustomer], [IDRoomType], [DateBookRoom], [DateCheckIn], [DateCheckOut]) VALUES (N'DP028     ', N'KH018     ', N'LP003     ', CAST(N'2024-05-21T18:33:00' AS SmallDateTime), CAST(N'2024-05-21' AS Date), CAST(N'2024-05-24' AS Date))
INSERT [dbo].[BookRoom] ([IDBookRoom], [IDCustomer], [IDRoomType], [DateBookRoom], [DateCheckIn], [DateCheckOut]) VALUES (N'DP029     ', N'KH013     ', N'LP003     ', CAST(N'2024-05-23T18:13:00' AS SmallDateTime), CAST(N'2024-05-23' AS Date), CAST(N'2024-05-24' AS Date))
INSERT [dbo].[BookRoom] ([IDBookRoom], [IDCustomer], [IDRoomType], [DateBookRoom], [DateCheckIn], [DateCheckOut]) VALUES (N'DP030     ', N'KH014     ', N'LP001     ', CAST(N'2024-05-23T18:22:00' AS SmallDateTime), CAST(N'2024-05-23' AS Date), CAST(N'2024-05-24' AS Date))
INSERT [dbo].[BookRoom] ([IDBookRoom], [IDCustomer], [IDRoomType], [DateBookRoom], [DateCheckIn], [DateCheckOut]) VALUES (N'DP031     ', N'KH018     ', N'LP001     ', CAST(N'2024-05-24T21:04:00' AS SmallDateTime), CAST(N'2024-05-24' AS Date), CAST(N'2024-05-25' AS Date))
INSERT [dbo].[BookRoom] ([IDBookRoom], [IDCustomer], [IDRoomType], [DateBookRoom], [DateCheckIn], [DateCheckOut]) VALUES (N'DP032     ', N'KH017     ', N'LP001     ', CAST(N'2024-05-24T21:06:00' AS SmallDateTime), CAST(N'2024-05-24' AS Date), CAST(N'2024-05-26' AS Date))
INSERT [dbo].[BookRoom] ([IDBookRoom], [IDCustomer], [IDRoomType], [DateBookRoom], [DateCheckIn], [DateCheckOut]) VALUES (N'DP033     ', N'KH013     ', N'LP001     ', CAST(N'2024-05-24T21:07:00' AS SmallDateTime), CAST(N'2024-05-24' AS Date), CAST(N'2024-05-25' AS Date))
INSERT [dbo].[BookRoom] ([IDBookRoom], [IDCustomer], [IDRoomType], [DateBookRoom], [DateCheckIn], [DateCheckOut]) VALUES (N'DP034     ', N'KH013     ', N'LP003     ', CAST(N'2024-05-24T21:15:00' AS SmallDateTime), CAST(N'2024-05-24' AS Date), CAST(N'2024-05-27' AS Date))
INSERT [dbo].[BookRoom] ([IDBookRoom], [IDCustomer], [IDRoomType], [DateBookRoom], [DateCheckIn], [DateCheckOut]) VALUES (N'DP035     ', N'KH023     ', N'LP004     ', CAST(N'2024-05-24T21:16:00' AS SmallDateTime), CAST(N'2024-05-24' AS Date), CAST(N'2024-05-27' AS Date))
INSERT [dbo].[BookRoom] ([IDBookRoom], [IDCustomer], [IDRoomType], [DateBookRoom], [DateCheckIn], [DateCheckOut]) VALUES (N'DP036     ', N'KH024     ', N'LP003     ', CAST(N'2024-05-24T21:17:00' AS SmallDateTime), CAST(N'2024-05-24' AS Date), CAST(N'2024-05-27' AS Date))
INSERT [dbo].[BookRoom] ([IDBookRoom], [IDCustomer], [IDRoomType], [DateBookRoom], [DateCheckIn], [DateCheckOut]) VALUES (N'DP037     ', N'KH025     ', N'LP002     ', CAST(N'2024-05-24T21:19:00' AS SmallDateTime), CAST(N'2024-05-24' AS Date), CAST(N'2024-05-28' AS Date))
INSERT [dbo].[BookRoom] ([IDBookRoom], [IDCustomer], [IDRoomType], [DateBookRoom], [DateCheckIn], [DateCheckOut]) VALUES (N'DP038     ', N'KH022     ', N'LP001     ', CAST(N'2024-05-24T21:26:00' AS SmallDateTime), CAST(N'2024-05-24' AS Date), CAST(N'2024-05-25' AS Date))
INSERT [dbo].[BookRoom] ([IDBookRoom], [IDCustomer], [IDRoomType], [DateBookRoom], [DateCheckIn], [DateCheckOut]) VALUES (N'DP039     ', N'KH013     ', N'LP001     ', CAST(N'2024-05-25T08:27:00' AS SmallDateTime), CAST(N'2024-05-25' AS Date), CAST(N'2024-05-26' AS Date))
INSERT [dbo].[BookRoom] ([IDBookRoom], [IDCustomer], [IDRoomType], [DateBookRoom], [DateCheckIn], [DateCheckOut]) VALUES (N'DP040     ', N'KH026     ', N'LP001     ', CAST(N'2024-05-25T08:29:00' AS SmallDateTime), CAST(N'2024-05-25' AS Date), CAST(N'2024-05-26' AS Date))
INSERT [dbo].[BookRoom] ([IDBookRoom], [IDCustomer], [IDRoomType], [DateBookRoom], [DateCheckIn], [DateCheckOut]) VALUES (N'DP041     ', N'KH026     ', N'LP001     ', CAST(N'2024-05-25T08:30:00' AS SmallDateTime), CAST(N'2024-05-25' AS Date), CAST(N'2024-05-26' AS Date))
INSERT [dbo].[BookRoom] ([IDBookRoom], [IDCustomer], [IDRoomType], [DateBookRoom], [DateCheckIn], [DateCheckOut]) VALUES (N'DP042     ', N'KH026     ', N'LP001     ', CAST(N'2024-05-25T08:30:00' AS SmallDateTime), CAST(N'2024-05-25' AS Date), CAST(N'2024-05-26' AS Date))
INSERT [dbo].[BookRoom] ([IDBookRoom], [IDCustomer], [IDRoomType], [DateBookRoom], [DateCheckIn], [DateCheckOut]) VALUES (N'DP043     ', N'KH026     ', N'LP004     ', CAST(N'2024-05-25T08:33:00' AS SmallDateTime), CAST(N'2024-05-25' AS Date), CAST(N'2024-05-01' AS Date))
/* CHÈN DỮ LIỆU VÀO BILL */ select*from bill
INSERT [dbo].[Bill] ([IDBill], [IDReceiveRoom], [StaffSetUp], [DateOfCreate], [RoomPrice], [ServicePrice], [TotalPrice], [Discount], [IDStatusBill], [Surcharge]) VALUES (N'HD001     ', N'PN001     ', N'admin', CAST(N'2021-04-21T14:34:00' AS SmallDateTime), 5000000, 0, 7500000, 0, 2, 2500000)
INSERT [dbo].[Bill] ([IDBill], [IDReceiveRoom], [StaffSetUp], [DateOfCreate], [RoomPrice], [ServicePrice], [TotalPrice], [Discount], [IDStatusBill], [Surcharge]) VALUES (N'HD002     ', N'PN002     ', N'admin', CAST(N'2021-04-21T14:34:00' AS SmallDateTime), 40000000, 0, 60000000, 10, 2, 20000000)
INSERT [dbo].[Bill] ([IDBill], [IDReceiveRoom], [StaffSetUp], [DateOfCreate], [RoomPrice], [ServicePrice], [TotalPrice], [Discount], [IDStatusBill], [Surcharge]) VALUES (N'HD003     ', N'PN003     ', N'admin', CAST(N'2021-04-21T14:17:00' AS SmallDateTime), 4000000, 0, 0, 0, 1, 2000000)
INSERT [dbo].[Bill] ([IDBill], [IDReceiveRoom], [StaffSetUp], [DateOfCreate], [RoomPrice], [ServicePrice], [TotalPrice], [Discount], [IDStatusBill], [Surcharge]) VALUES (N'HD004     ', N'PN004     ', N'admin', CAST(N'2021-04-21T14:45:00' AS SmallDateTime), 4000000, 1500000, 7500000, 1, 2, 2000000)
INSERT [dbo].[Bill] ([IDBill], [IDReceiveRoom], [StaffSetUp], [DateOfCreate], [RoomPrice], [ServicePrice], [TotalPrice], [Discount], [IDStatusBill], [Surcharge]) VALUES (N'HD005     ', N'PN005     ', N'admin', CAST(N'2021-05-18T09:44:00' AS SmallDateTime), 130000000, 2900000, 132900000, 10, 2, 0)
INSERT [dbo].[Bill] ([IDBill], [IDReceiveRoom], [StaffSetUp], [DateOfCreate], [RoomPrice], [ServicePrice], [TotalPrice], [Discount], [IDStatusBill], [Surcharge]) VALUES (N'HD006     ', N'PN006     ', N'admin', CAST(N'2021-05-18T09:44:00' AS SmallDateTime), 8000000, 4850000, 12850000, 0, 2, 0)
INSERT [dbo].[Bill] ([IDBill], [IDReceiveRoom], [StaffSetUp], [DateOfCreate], [RoomPrice], [ServicePrice], [TotalPrice], [Discount], [IDStatusBill], [Surcharge]) VALUES (N'HD007     ', N'PN007     ', N'admin', CAST(N'2021-04-21T01:56:00' AS SmallDateTime), 4000000, 3000000, 10000000, 2, 2, 3000000)
INSERT [dbo].[Bill] ([IDBill], [IDReceiveRoom], [StaffSetUp], [DateOfCreate], [RoomPrice], [ServicePrice], [TotalPrice], [Discount], [IDStatusBill], [Surcharge]) VALUES (N'HD008     ', N'PN008     ', N'admin', CAST(N'2021-05-24T19:49:00' AS SmallDateTime), 16000000, 200000, 16200000, 5, 2, 0)
INSERT [dbo].[Bill] ([IDBill], [IDReceiveRoom], [StaffSetUp], [DateOfCreate], [RoomPrice], [ServicePrice], [TotalPrice], [Discount], [IDStatusBill], [Surcharge]) VALUES (N'HD009     ', N'PN009     ', N'admin', CAST(N'2021-05-17T23:00:00' AS SmallDateTime), 160000000, 2600000, 162600000, 0, 2, 0)
INSERT [dbo].[Bill] ([IDBill], [IDReceiveRoom], [StaffSetUp], [DateOfCreate], [RoomPrice], [ServicePrice], [TotalPrice], [Discount], [IDStatusBill], [Surcharge]) VALUES (N'HD010     ', N'PN014     ', N'admin', CAST(N'2021-05-17T13:43:00' AS SmallDateTime), 28000000, 3000000, 31000000, 0, 2, 0)
INSERT [dbo].[Bill] ([IDBill], [IDReceiveRoom], [StaffSetUp], [DateOfCreate], [RoomPrice], [ServicePrice], [TotalPrice], [Discount], [IDStatusBill], [Surcharge]) VALUES (N'HD011     ', N'PN015     ', N'admin', CAST(N'2021-05-19T20:07:00' AS SmallDateTime), 70000000, 8700000, 78700000, 0, 2, 0)
INSERT [dbo].[Bill] ([IDBill], [IDReceiveRoom], [StaffSetUp], [DateOfCreate], [RoomPrice], [ServicePrice], [TotalPrice], [Discount], [IDStatusBill], [Surcharge]) VALUES (N'HD012     ', N'PN012     ', N'admin', CAST(N'2021-05-24T16:13:00' AS SmallDateTime), 91000000, 6100000, 97100000, 5, 2, 0)
INSERT [dbo].[Bill] ([IDBill], [IDReceiveRoom], [StaffSetUp], [DateOfCreate], [RoomPrice], [ServicePrice], [TotalPrice], [Discount], [IDStatusBill], [Surcharge]) VALUES (N'HD013     ', N'PN013     ', N'admin', CAST(N'2021-05-17T16:54:00' AS SmallDateTime), 20000000, 9600000, 29600000, 0, 2, 0)
INSERT [dbo].[Bill] ([IDBill], [IDReceiveRoom], [StaffSetUp], [DateOfCreate], [RoomPrice], [ServicePrice], [TotalPrice], [Discount], [IDStatusBill], [Surcharge]) VALUES (N'HD014     ', N'PN017     ', N'admin', CAST(N'2021-05-17T13:56:00' AS SmallDateTime), 7000000, 1100000, 8100000, 10, 2, 0)
INSERT [dbo].[Bill] ([IDBill], [IDReceiveRoom], [StaffSetUp], [DateOfCreate], [RoomPrice], [ServicePrice], [TotalPrice], [Discount], [IDStatusBill], [Surcharge]) VALUES (N'HD015     ', N'PN013     ', N'admin', CAST(N'2021-05-17T16:54:00' AS SmallDateTime), 20000000, 3300000, 23300000, 0, 2, 0)
INSERT [dbo].[Bill] ([IDBill], [IDReceiveRoom], [StaffSetUp], [DateOfCreate], [RoomPrice], [ServicePrice], [TotalPrice], [Discount], [IDStatusBill], [Surcharge]) VALUES (N'HD016     ', N'PN018     ', N'admin', CAST(N'2021-05-17T20:23:00' AS SmallDateTime), 14000000, 3950000, 17950000, 0, 2, 0)
INSERT [dbo].[Bill] ([IDBill], [IDReceiveRoom], [StaffSetUp], [DateOfCreate], [RoomPrice], [ServicePrice], [TotalPrice], [Discount], [IDStatusBill], [Surcharge]) VALUES (N'HD017     ', N'PN020     ', N'admin', CAST(N'2021-05-18T09:31:00' AS SmallDateTime), 2000000, 0, 0, 0, 1, 0)
INSERT [dbo].[Bill] ([IDBill], [IDReceiveRoom], [StaffSetUp], [DateOfCreate], [RoomPrice], [ServicePrice], [TotalPrice], [Discount], [IDStatusBill], [Surcharge]) VALUES (N'HD018     ', N'PN019     ', N'admin', CAST(N'2021-05-18T09:32:00' AS SmallDateTime), 5000000, 0, 0, 0, 1, 0)
INSERT [dbo].[Bill] ([IDBill], [IDReceiveRoom], [StaffSetUp], [DateOfCreate], [RoomPrice], [ServicePrice], [TotalPrice], [Discount], [IDStatusBill], [Surcharge]) VALUES (N'HD019     ', N'PN016     ', N'admin', CAST(N'2021-05-18T09:43:00' AS SmallDateTime), 130000000, 4350000, 134350000, 0, 2, 0)
INSERT [dbo].[Bill] ([IDBill], [IDReceiveRoom], [StaffSetUp], [DateOfCreate], [RoomPrice], [ServicePrice], [TotalPrice], [Discount], [IDStatusBill], [Surcharge]) VALUES (N'HD020     ', N'PN011     ', N'admin', CAST(N'2021-05-19T20:18:00' AS SmallDateTime), 64000000, 2700000, 66700000, 0, 2, 0)
INSERT [dbo].[Bill] ([IDBill], [IDReceiveRoom], [StaffSetUp], [DateOfCreate], [RoomPrice], [ServicePrice], [TotalPrice], [Discount], [IDStatusBill], [Surcharge]) VALUES (N'HD021     ', N'PN010     ', N'admin', CAST(N'2021-05-18T09:45:00' AS SmallDateTime), 350000000, 1150000, 526150000, 5, 2, 175000000)
INSERT [dbo].[Bill] ([IDBill], [IDReceiveRoom], [StaffSetUp], [DateOfCreate], [RoomPrice], [ServicePrice], [TotalPrice], [Discount], [IDStatusBill], [Surcharge]) VALUES (N'HD022     ', N'PN015     ', N'admin', CAST(N'2021-05-19T20:08:00' AS SmallDateTime), 70000000, 2400000, 72400000, 0, 2, 0)
INSERT [dbo].[Bill] ([IDBill], [IDReceiveRoom], [StaffSetUp], [DateOfCreate], [RoomPrice], [ServicePrice], [TotalPrice], [Discount], [IDStatusBill], [Surcharge]) VALUES (N'HD023     ', N'PN022     ', N'admin', CAST(N'2021-05-19T20:18:00' AS SmallDateTime), 36000000, 1700000, 37700000, 0, 2, 0)
INSERT [dbo].[Bill] ([IDBill], [IDReceiveRoom], [StaffSetUp], [DateOfCreate], [RoomPrice], [ServicePrice], [TotalPrice], [Discount], [IDStatusBill], [Surcharge]) VALUES (N'HD024     ', N'PN021     ', N'admin', CAST(N'2021-05-19T20:19:00' AS SmallDateTime), 9000000, 2400000, 11400000, 0, 2, 0)
INSERT [dbo].[Bill] ([IDBill], [IDReceiveRoom], [StaffSetUp], [DateOfCreate], [RoomPrice], [ServicePrice], [TotalPrice], [Discount], [IDStatusBill], [Surcharge]) VALUES (N'HD025     ', N'PN023     ', N'admin', CAST(N'2021-05-19T20:19:00' AS SmallDateTime), 36000000, 4550000, 40550000, 0, 2, 0)
INSERT [dbo].[Bill] ([IDBill], [IDReceiveRoom], [StaffSetUp], [DateOfCreate], [RoomPrice], [ServicePrice], [TotalPrice], [Discount], [IDStatusBill], [Surcharge]) VALUES (N'HD026     ', N'PN024     ', N'admin', CAST(N'2021-05-24T19:47:00' AS SmallDateTime), 70000000, 1725000, 71725000, 0, 2, 0)
INSERT [dbo].[Bill] ([IDBill], [IDReceiveRoom], [StaffSetUp], [DateOfCreate], [RoomPrice], [ServicePrice], [TotalPrice], [Discount], [IDStatusBill], [Surcharge]) VALUES (N'HD027     ', N'PN025     ', N'admin', CAST(N'2021-05-24T19:46:00' AS SmallDateTime), 28000000, 4450000, 32450000, 0, 2, 0)
INSERT [dbo].[Bill] ([IDBill], [IDReceiveRoom], [StaffSetUp], [DateOfCreate], [RoomPrice], [ServicePrice], [TotalPrice], [Discount], [IDStatusBill], [Surcharge]) VALUES (N'HD028     ', N'PN026     ', N'admin', CAST(N'2021-05-23T14:34:00' AS SmallDateTime), 4000000, 2900000, 6900000, 0, 2, 0)
INSERT [dbo].[Bill] ([IDBill], [IDReceiveRoom], [StaffSetUp], [DateOfCreate], [RoomPrice], [ServicePrice], [TotalPrice], [Discount], [IDStatusBill], [Surcharge]) VALUES (N'HD029     ', N'PN025     ', N'admin', CAST(N'2021-05-24T19:47:00' AS SmallDateTime), 28000000, 250000, 28250000, 0, 2, 0)
INSERT [dbo].[Bill] ([IDBill], [IDReceiveRoom], [StaffSetUp], [DateOfCreate], [RoomPrice], [ServicePrice], [TotalPrice], [Discount], [IDStatusBill], [Surcharge]) VALUES (N'HD030     ', N'PN024     ', N'admin', CAST(N'2021-05-24T19:47:00' AS SmallDateTime), 70000000, 50000, 70050000, 0, 2, 0)
INSERT [dbo].[Bill] ([IDBill], [IDReceiveRoom], [StaffSetUp], [DateOfCreate], [RoomPrice], [ServicePrice], [TotalPrice], [Discount], [IDStatusBill], [Surcharge]) VALUES (N'HD031     ', N'PN029     ', N'admin', CAST(N'2021-05-24T16:12:00' AS SmallDateTime), 4000000, 2900000, 6900000, 5, 2, 0)
INSERT [dbo].[Bill] ([IDBill], [IDReceiveRoom], [StaffSetUp], [DateOfCreate], [RoomPrice], [ServicePrice], [TotalPrice], [Discount], [IDStatusBill], [Surcharge]) VALUES (N'HD032     ', N'PN028     ', N'admin', CAST(N'2021-05-25T07:22:00' AS SmallDateTime), 20000000, 2700000, 22700000, 0, 2, 0)
INSERT [dbo].[Bill] ([IDBill], [IDReceiveRoom], [StaffSetUp], [DateOfCreate], [RoomPrice], [ServicePrice], [TotalPrice], [Discount], [IDStatusBill], [Surcharge]) VALUES (N'HD033     ', N'PN027     ', N'admin', CAST(N'2021-05-24T16:11:00' AS SmallDateTime), 10000000, 400000, 10400000, 5, 2, 0)
INSERT [dbo].[Bill] ([IDBill], [IDReceiveRoom], [StaffSetUp], [DateOfCreate], [RoomPrice], [ServicePrice], [TotalPrice], [Discount], [IDStatusBill], [Surcharge]) VALUES (N'HD034     ', N'PN029     ', N'admin', CAST(N'2021-05-24T16:13:00' AS SmallDateTime), 4000000, 1100000, 5100000, 5, 2, 0)
INSERT [dbo].[Bill] ([IDBill], [IDReceiveRoom], [StaffSetUp], [DateOfCreate], [RoomPrice], [ServicePrice], [TotalPrice], [Discount], [IDStatusBill], [Surcharge]) VALUES (N'HD035     ', N'PN012     ', N'admin', CAST(N'2021-05-24T16:13:00' AS SmallDateTime), 91000000, 275000, 91275000, 5, 2, 0)
INSERT [dbo].[Bill] ([IDBill], [IDReceiveRoom], [StaffSetUp], [DateOfCreate], [RoomPrice], [ServicePrice], [TotalPrice], [Discount], [IDStatusBill], [Surcharge]) VALUES (N'HD036     ', N'PN032     ', N'admin', CAST(N'2021-05-24T16:20:00' AS SmallDateTime), 3000000, 0, 0, 0, 1, 0)
INSERT [dbo].[Bill] ([IDBill], [IDReceiveRoom], [StaffSetUp], [DateOfCreate], [RoomPrice], [ServicePrice], [TotalPrice], [Discount], [IDStatusBill], [Surcharge]) VALUES (N'HD037     ', N'PN030     ', N'admin', CAST(N'2021-05-24T16:20:00' AS SmallDateTime), 12000000, 0, 0, 0, 1, 0)
INSERT [dbo].[Bill] ([IDBill], [IDReceiveRoom], [StaffSetUp], [DateOfCreate], [RoomPrice], [ServicePrice], [TotalPrice], [Discount], [IDStatusBill], [Surcharge]) VALUES (N'HD038     ', N'PN031     ', N'admin', CAST(N'2021-05-24T16:30:00' AS SmallDateTime), 12000000, 450000, 12450000, 5, 2, 0)
INSERT [dbo].[Bill] ([IDBill], [IDReceiveRoom], [StaffSetUp], [DateOfCreate], [RoomPrice], [ServicePrice], [TotalPrice], [Discount], [IDStatusBill], [Surcharge]) VALUES (N'HD039     ', N'PN033     ', N'admin', CAST(N'2021-05-24T16:20:00' AS SmallDateTime), 28000000, 0, 0, 0, 1, 0)
INSERT [dbo].[Bill] ([IDBill], [IDReceiveRoom], [StaffSetUp], [DateOfCreate], [RoomPrice], [ServicePrice], [TotalPrice], [Discount], [IDStatusBill], [Surcharge]) VALUES (N'HD040     ', N'PN034     ', N'admin', CAST(N'2021-05-24T16:27:00' AS SmallDateTime), 10000000, 0, 0, 0, 1, 0)
INSERT [dbo].[Bill] ([IDBill], [IDReceiveRoom], [StaffSetUp], [DateOfCreate], [RoomPrice], [ServicePrice], [TotalPrice], [Discount], [IDStatusBill], [Surcharge]) VALUES (N'HD041     ', N'PN028     ', N'admin', CAST(N'2021-05-25T07:23:00' AS SmallDateTime), 20000000, 500000, 20500000, 0, 2, 0)
INSERT [dbo].[Bill] ([IDBill], [IDReceiveRoom], [StaffSetUp], [DateOfCreate], [RoomPrice], [ServicePrice], [TotalPrice], [Discount], [IDStatusBill], [Surcharge]) VALUES (N'HD042     ', N'PN031     ', N'admin', CAST(N'2021-05-25T07:23:00' AS SmallDateTime), 12000000, 0, 0, 0, 1, 0)
INSERT [dbo].[Bill] ([IDBill], [IDReceiveRoom], [StaffSetUp], [DateOfCreate], [RoomPrice], [ServicePrice], [TotalPrice], [Discount], [IDStatusBill], [Surcharge]) VALUES (N'HD043     ', N'PN036     ', N'admin', CAST(N'2021-05-25T08:36:00' AS SmallDateTime), 10000000, 1700000, 11700000, 10, 2, 0)
/*chèn dữ liệu vào bill details*/

INSERT [dbo].[BillDetails] ([IDBill], [IDService], [soluong], [TotalPrice]) VALUES (N'HD001     ', N'DV002     ', 1, 100000)
INSERT [dbo].[BillDetails] ([IDBill], [IDService], [soluong], [TotalPrice]) VALUES (N'HD001     ', N'DV003     ', 1, 200000)
INSERT [dbo].[BillDetails] ([IDBill], [IDService], [soluong], [TotalPrice]) VALUES (N'HD001     ', N'DV004     ', 1, 1000000)
INSERT [dbo].[BillDetails] ([IDBill], [IDService], [soluong], [TotalPrice]) VALUES (N'HD001     ', N'DV005     ', 1, 150000)
INSERT [dbo].[BillDetails] ([IDBill], [IDService], [soluong], [TotalPrice]) VALUES (N'HD006     ', N'DV001     ', 2, 600000)
INSERT [dbo].[BillDetails] ([IDBill], [IDService], [soluong], [TotalPrice]) VALUES (N'HD011     ', N'DV001     ', 2, 2400000)
INSERT [dbo].[BillDetails] ([IDBill], [IDService], [soluong], [TotalPrice]) VALUES (N'HD014     ', N'DV001     ', 1, 1000000)
INSERT [dbo].[BillDetails] ([IDBill], [IDService], [soluong], [TotalPrice]) VALUES (N'HD031     ', N'DV001     ', 1, 1200000)
INSERT [dbo].[BillDetails] ([IDBill], [IDService], [soluong], [TotalPrice]) VALUES (N'HD043     ', N'DV001     ', 1, 1200000)
INSERT [dbo].[BillDetails] ([IDBill], [IDService], [soluong], [TotalPrice]) VALUES (N'HD002     ', N'DV002     ', 1, 1000000)
INSERT [dbo].[BillDetails] ([IDBill], [IDService], [soluong], [TotalPrice]) VALUES (N'HD007     ', N'DV002     ', 1, 75000)
INSERT [dbo].[BillDetails] ([IDBill], [IDService], [soluong], [TotalPrice]) VALUES (N'HD011     ', N'DV002     ', 1, 100000)
INSERT [dbo].[BillDetails] ([IDBill], [IDService], [soluong], [TotalPrice]) VALUES (N'HD012     ', N'DV002     ', 3, 300000)
INSERT [dbo].[BillDetails] ([IDBill], [IDService], [soluong], [TotalPrice]) VALUES (N'HD019     ', N'DV002     ', 2, 200000)
INSERT [dbo].[BillDetails] ([IDBill], [IDService], [soluong], [TotalPrice]) VALUES (N'HD022     ', N'DV002     ', 1, 100000)
INSERT [dbo].[BillDetails] ([IDBill], [IDService], [soluong], [TotalPrice]) VALUES (N'HD003     ', N'DV003     ', 1, 100000)
INSERT [dbo].[BillDetails] ([IDBill], [IDService], [soluong], [TotalPrice]) VALUES (N'HD005     ', N'DV003     ', 2, 2000000)
INSERT [dbo].[BillDetails] ([IDBill], [IDService], [soluong], [TotalPrice]) VALUES (N'HD008     ', N'DV003     ', 1, 50000)
INSERT [dbo].[BillDetails] ([IDBill], [IDService], [soluong], [TotalPrice]) VALUES (N'HD019     ', N'DV003     ', 2, 400000)
INSERT [dbo].[BillDetails] ([IDBill], [IDService], [soluong], [TotalPrice]) VALUES (N'HD020     ', N'DV003     ', 1, 200000)
INSERT [dbo].[BillDetails] ([IDBill], [IDService], [soluong], [TotalPrice]) VALUES (N'HD023     ', N'DV003     ', 3, 600000)
INSERT [dbo].[BillDetails] ([IDBill], [IDService], [soluong], [TotalPrice]) VALUES (N'HD024     ', N'DV003     ', 2, 400000)
INSERT [dbo].[BillDetails] ([IDBill], [IDService], [soluong], [TotalPrice]) VALUES (N'HD026     ', N'DV003     ', 1, 200000)
INSERT [dbo].[BillDetails] ([IDBill], [IDService], [soluong], [TotalPrice]) VALUES (N'HD028     ', N'DV003     ', 2, 400000)
INSERT [dbo].[BillDetails] ([IDBill], [IDService], [soluong], [TotalPrice]) VALUES (N'HD029     ', N'DV003     ', 1, 200000)
INSERT [dbo].[BillDetails] ([IDBill], [IDService], [soluong], [TotalPrice]) VALUES (N'HD032     ', N'DV003     ', 1, 200000)
INSERT [dbo].[BillDetails] ([IDBill], [IDService], [soluong], [TotalPrice]) VALUES (N'HD033     ', N'DV003     ', 1, 200000)
INSERT [dbo].[BillDetails] ([IDBill], [IDService], [soluong], [TotalPrice]) VALUES (N'HD034     ', N'DV003     ', 1, 200000)
INSERT [dbo].[BillDetails] ([IDBill], [IDService], [soluong], [TotalPrice]) VALUES (N'HD038     ', N'DV003     ', 2, 400000)
INSERT [dbo].[BillDetails] ([IDBill], [IDService], [soluong], [TotalPrice]) VALUES (N'HD003     ', N'DV004     ', 1, 200000)
INSERT [dbo].[BillDetails] ([IDBill], [IDService], [soluong], [TotalPrice]) VALUES (N'HD010     ', N'DV004     ', 2, 2000000)
INSERT [dbo].[BillDetails] ([IDBill], [IDService], [soluong], [TotalPrice]) VALUES (N'HD031     ', N'DV004     ', 1, 1000000)
INSERT [dbo].[BillDetails] ([IDBill], [IDService], [soluong], [TotalPrice]) VALUES (N'HD004     ', N'DV005     ', 1, 200000)
INSERT [dbo].[BillDetails] ([IDBill], [IDService], [soluong], [TotalPrice]) VALUES (N'HD006     ', N'DV005     ', 3, 450000)
INSERT [dbo].[BillDetails] ([IDBill], [IDService], [soluong], [TotalPrice]) VALUES (N'HD019     ', N'DV005     ', 1, 150000)
INSERT [dbo].[BillDetails] ([IDBill], [IDService], [soluong], [TotalPrice]) VALUES (N'HD023     ', N'DV005     ', 1, 150000)
INSERT [dbo].[BillDetails] ([IDBill], [IDService], [soluong], [TotalPrice]) VALUES (N'HD006     ', N'DV006     ', 1, 2000000)
INSERT [dbo].[BillDetails] ([IDBill], [IDService], [soluong], [TotalPrice]) VALUES (N'HD011     ', N'DV006     ', 1, 200000)
INSERT [dbo].[BillDetails] ([IDBill], [IDService], [soluong], [TotalPrice]) VALUES (N'HD016     ', N'DV006     ', 2, 400000)
INSERT [dbo].[BillDetails] ([IDBill], [IDService], [soluong], [TotalPrice]) VALUES (N'HD020     ', N'DV006     ', 2, 400000)
INSERT [dbo].[BillDetails] ([IDBill], [IDService], [soluong], [TotalPrice]) VALUES (N'HD031     ', N'DV006     ', 1, 200000)
INSERT [dbo].[BillDetails] ([IDBill], [IDService], [soluong], [TotalPrice]) VALUES (N'HD034     ', N'DV006     ', 1, 200000)
INSERT [dbo].[BillDetails] ([IDBill], [IDService], [soluong], [TotalPrice]) VALUES (N'HD006     ', N'DV007     ', 1, 500000)
INSERT [dbo].[BillDetails] ([IDBill], [IDService], [soluong], [TotalPrice]) VALUES (N'HD015     ', N'DV007     ', 2, 1000000)
INSERT [dbo].[BillDetails] ([IDBill], [IDService], [soluong], [TotalPrice]) VALUES (N'HD016     ', N'DV007     ', 1, 500000)
INSERT [dbo].[BillDetails] ([IDBill], [IDService], [soluong], [TotalPrice]) VALUES (N'HD020     ', N'DV007     ', 1, 500000)
INSERT [dbo].[BillDetails] ([IDBill], [IDService], [soluong], [TotalPrice]) VALUES (N'HD034     ', N'DV007     ', 1, 500000)
INSERT [dbo].[BillDetails] ([IDBill], [IDService], [soluong], [TotalPrice]) VALUES (N'HD020     ', N'DV008     ', 2, 1600000)
INSERT [dbo].[BillDetails] ([IDBill], [IDService], [soluong], [TotalPrice]) VALUES (N'HD023     ', N'DV008     ', 1, 800000)
INSERT [dbo].[BillDetails] ([IDBill], [IDService], [soluong], [TotalPrice]) VALUES (N'HD012     ', N'DV009     ', 2, 2000000)
INSERT [dbo].[BillDetails] ([IDBill], [IDService], [soluong], [TotalPrice]) VALUES (N'HD013     ', N'DV010     ', 2, 1000000)
INSERT [dbo].[BillDetails] ([IDBill], [IDService], [soluong], [TotalPrice]) VALUES (N'HD019     ', N'DV010     ', 1, 500000)
INSERT [dbo].[BillDetails] ([IDBill], [IDService], [soluong], [TotalPrice]) VALUES (N'HD017     ', N'DV011     ', 1, 500000)
INSERT [dbo].[BillDetails] ([IDBill], [IDService], [soluong], [TotalPrice]) VALUES (N'HD031     ', N'DV011     ', 1, 500000)
INSERT [dbo].[BillDetails] ([IDBill], [IDService], [soluong], [TotalPrice]) VALUES (N'HD010     ', N'DV012     ', 2, 400000)
INSERT [dbo].[BillDetails] ([IDBill], [IDService], [soluong], [TotalPrice]) VALUES (N'HD026     ', N'DV012     ', 1, 200000)
INSERT [dbo].[BillDetails] ([IDBill], [IDService], [soluong], [TotalPrice]) VALUES (N'HD033     ', N'DV012     ', 1, 200000)
INSERT [dbo].[BillDetails] ([IDBill], [IDService], [soluong], [TotalPrice]) VALUES (N'HD034     ', N'DV012     ', 1, 200000)
INSERT [dbo].[BillDetails] ([IDBill], [IDService], [soluong], [TotalPrice]) VALUES (N'HD035     ', N'DV012     ', 1, 200000)
INSERT [dbo].[BillDetails] ([IDBill], [IDService], [soluong], [TotalPrice]) VALUES (N'HD011     ', N'DV013     ', 2, 4000000)
INSERT [dbo].[BillDetails] ([IDBill], [IDService], [soluong], [TotalPrice]) VALUES (N'HD013     ', N'DV013     ', 4, 8000000)
INSERT [dbo].[BillDetails] ([IDBill], [IDService], [soluong], [TotalPrice]) VALUES (N'HD018     ', N'DV013     ', 1, 2000000)
INSERT [dbo].[BillDetails] ([IDBill], [IDService], [soluong], [TotalPrice]) VALUES (N'HD019     ', N'DV013     ', 1, 2000000)
INSERT [dbo].[BillDetails] ([IDBill], [IDService], [soluong], [TotalPrice]) VALUES (N'HD024     ', N'DV013     ', 1, 2000000)
INSERT [dbo].[BillDetails] ([IDBill], [IDService], [soluong], [TotalPrice]) VALUES (N'HD025     ', N'DV013     ', 1, 2000000)
INSERT [dbo].[BillDetails] ([IDBill], [IDService], [soluong], [TotalPrice]) VALUES (N'HD027     ', N'DV013     ', 1, 2000000)
INSERT [dbo].[BillDetails] ([IDBill], [IDService], [soluong], [TotalPrice]) VALUES (N'HD032     ', N'DV013     ', 1, 2000000)
INSERT [dbo].[BillDetails] ([IDBill], [IDService], [soluong], [TotalPrice]) VALUES (N'HD012     ', N'DV014     ', 1, 50000)
INSERT [dbo].[BillDetails] ([IDBill], [IDService], [soluong], [TotalPrice]) VALUES (N'HD014     ', N'DV014     ', 2, 100000)
INSERT [dbo].[BillDetails] ([IDBill], [IDService], [soluong], [TotalPrice]) VALUES (N'HD017     ', N'DV014     ', 1, 50000)
INSERT [dbo].[BillDetails] ([IDBill], [IDService], [soluong], [TotalPrice]) VALUES (N'HD018     ', N'DV014     ', 2, 100000)
INSERT [dbo].[BillDetails] ([IDBill], [IDService], [soluong], [TotalPrice]) VALUES (N'HD021     ', N'DV014     ', 1, 50000)
INSERT [dbo].[BillDetails] ([IDBill], [IDService], [soluong], [TotalPrice]) VALUES (N'HD026     ', N'DV014     ', 1, 50000)
INSERT [dbo].[BillDetails] ([IDBill], [IDService], [soluong], [TotalPrice]) VALUES (N'HD027     ', N'DV014     ', 1, 50000)
INSERT [dbo].[BillDetails] ([IDBill], [IDService], [soluong], [TotalPrice]) VALUES (N'HD029     ', N'DV014     ', 1, 50000)
INSERT [dbo].[BillDetails] ([IDBill], [IDService], [soluong], [TotalPrice]) VALUES (N'HD030     ', N'DV014     ', 1, 50000)
INSERT [dbo].[BillDetails] ([IDBill], [IDService], [soluong], [TotalPrice]) VALUES (N'HD038     ', N'DV014     ', 1, 50000)
INSERT [dbo].[BillDetails] ([IDBill], [IDService], [soluong], [TotalPrice]) VALUES (N'HD011     ', N'DV015     ', 2, 1000000)
INSERT [dbo].[BillDetails] ([IDBill], [IDService], [soluong], [TotalPrice]) VALUES (N'HD016     ', N'DV015     ', 3, 1500000)
INSERT [dbo].[BillDetails] ([IDBill], [IDService], [soluong], [TotalPrice]) VALUES (N'HD018     ', N'DV015     ', 1, 500000)
INSERT [dbo].[BillDetails] ([IDBill], [IDService], [soluong], [TotalPrice]) VALUES (N'HD019     ', N'DV015     ', 2, 1000000)
INSERT [dbo].[BillDetails] ([IDBill], [IDService], [soluong], [TotalPrice]) VALUES (N'HD028     ', N'DV015     ', 1, 500000)
INSERT [dbo].[BillDetails] ([IDBill], [IDService], [soluong], [TotalPrice]) VALUES (N'HD032     ', N'DV015     ', 1, 500000)
INSERT [dbo].[BillDetails] ([IDBill], [IDService], [soluong], [TotalPrice]) VALUES (N'HD041     ', N'DV015     ', 1, 500000)
INSERT [dbo].[BillDetails] ([IDBill], [IDService], [soluong], [TotalPrice]) VALUES (N'HD043     ', N'DV015     ', 1, 500000)
INSERT [dbo].[BillDetails] ([IDBill], [IDService], [soluong], [TotalPrice]) VALUES (N'HD008     ', N'DV016     ', 1, 150000)
INSERT [dbo].[BillDetails] ([IDBill], [IDService], [soluong], [TotalPrice]) VALUES (N'HD012     ', N'DV016     ', 1, 150000)
INSERT [dbo].[BillDetails] ([IDBill], [IDService], [soluong], [TotalPrice]) VALUES (N'HD013     ', N'DV016     ', 2, 300000)
INSERT [dbo].[BillDetails] ([IDBill], [IDService], [soluong], [TotalPrice]) VALUES (N'HD023     ', N'DV016     ', 1, 150000)
INSERT [dbo].[BillDetails] ([IDBill], [IDService], [soluong], [TotalPrice]) VALUES (N'HD025     ', N'DV016     ', 1, 150000)
INSERT [dbo].[BillDetails] ([IDBill], [IDService], [soluong], [TotalPrice]) VALUES (N'HD017     ', N'DV017     ', 1, 75000)
INSERT [dbo].[BillDetails] ([IDBill], [IDService], [soluong], [TotalPrice]) VALUES (N'HD026     ', N'DV017     ', 1, 75000)
INSERT [dbo].[BillDetails] ([IDBill], [IDService], [soluong], [TotalPrice]) VALUES (N'HD035     ', N'DV017     ', 1, 75000)
INSERT [dbo].[BillDetails] ([IDBill], [IDService], [soluong], [TotalPrice]) VALUES (N'HD016     ', N'DV018     ', 1, 50000)
INSERT [dbo].[BillDetails] ([IDBill], [IDService], [soluong], [TotalPrice]) VALUES (N'HD018     ', N'DV018     ', 1, 50000)
INSERT [dbo].[BillDetails] ([IDBill], [IDService], [soluong], [TotalPrice]) VALUES (N'HD019     ', N'DV018     ', 2, 100000)
INSERT [dbo].[BillDetails] ([IDBill], [IDService], [soluong], [TotalPrice]) VALUES (N'HD012     ', N'DV019     ', 2, 3600000)
INSERT [dbo].[BillDetails] ([IDBill], [IDService], [soluong], [TotalPrice]) VALUES (N'HD006     ', N'DV020     ', 1, 500000)
INSERT [dbo].[BillDetails] ([IDBill], [IDService], [soluong], [TotalPrice]) VALUES (N'HD018     ', N'DV020     ', 1, 500000)
INSERT [dbo].[BillDetails] ([IDBill], [IDService], [soluong], [TotalPrice]) VALUES (N'HD025     ', N'DV021     ', 1, 1200000)
INSERT [dbo].[BillDetails] ([IDBill], [IDService], [soluong], [TotalPrice]) VALUES (N'HD026     ', N'DV021     ', 1, 1200000)
INSERT [dbo].[BillDetails] ([IDBill], [IDService], [soluong], [TotalPrice]) VALUES (N'HD027     ', N'DV021     ', 1, 1200000)
INSERT [dbo].[BillDetails] ([IDBill], [IDService], [soluong], [TotalPrice]) VALUES (N'HD006     ', N'DV022     ', 1, 300000)
/* check*/-- tính tổng số tiền dịch vụ của hóa đơn đó
select b.IDBill, sum(PriceService) as Tong_tien
from ([Service] s inner join BillDetails bd on s.IDService=bd.IDService) inner join Bill b on b.IDBill=bd.IDBill
group by b.IDBill
/* RÀNG BUỘC CSDL BẰNG KHÓA NGOẠI*/
Alter table Bill add constraint PK_BILL foreign key (IDReceiveRoom) references ReceiveRoom(IDReceiveRoom)
Alter table BillDetails add constraint PK_1 foreign key (IDbill) references Bill(IDbill)
Alter table BillDetails add constraint PK_2 foreign key (IDService ) references [Service](IDService)
Alter table BookRoom add constraint PK_3 foreign key (IDCustomer) references Customer(IDCustomer)
Alter table BookRoom add constraint PK_4 foreign key (IDRoomType ) references RoomType(IDRoomType )
Alter table Customer add constraint PK_5 foreign key (IDCustomerType) references CustomerType(IDCustomerType)
Alter table ReceiveRoom add constraint PK_6 foreign key (IDBookRoom) references BookRoom(IDBookRoom)
Alter table Room add constraint PK_7 foreign key (IDRoomType) references RoomType(IDRoomType)
Alter table Room add constraint PK_8 foreign key (IDStatusRoom) references StatusRoom(IDStatusRoom)
Alter table [Service] add constraint PK_9 foreign key (IDServiceType) references ServiceType(IDServiceType)
Alter table history_message add constraint PK_10 foreign key (ID_send) references Staff(IDStaff)
/* KẾT THÚC VIỆC THIẾT LẬP CSDL*/
