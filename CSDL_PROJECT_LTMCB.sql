create database LTMCB


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

CREATE TABLE Staff (
    IDStaff char(10) PRIMARY KEY ,
	UserName nvarchar(100) ,
	DisplayName nvarchar(100) ,
	[PassWord] nvarchar(100) ,
	IDStaffType char(10) ,
	IDCardStaff nvarchar(100),
	DateOfBirthStaff date ,
	SexStaff nvarchar(100) ,
	AddressStaff nvarchar(200) ,
	PhoneNumberStaff int ,
	StartDay date 
)

CREATE TABLE StatusBill (
	IDStatusBill char(10) PRIMARY KEY,
	NameStatusBill nvarchar(100) 
)

CREATE TABLE StatusRoom(
	IDStatusRoom char(10) PRIMARY KEY ,
	NameStatusRoom nvarchar(100) 
)

create table  history_message ( 
     IDMessage char(10) PRIMARY KEY ,
	 ID_send char(10) ,
	 TIME_SEND smalldatetime ,
	 Conten_message nvarchar(2000) 

)