use GuildCars
go


IF EXISTS(SELECT * FROM sys.tables WHERE name='Sales')
	DROP TABLE Sales

IF EXISTS(SELECT * FROM sys.tables WHERE name='States')
	DROP TABLE States
	
IF EXISTS(SELECT * FROM sys.tables WHERE name='PurchaseType')
	DROP TABLE PurchaseType

IF EXISTS(SELECT * FROM sys.tables WHERE name='Vehicle')
	DROP TABLE Vehicle

IF EXISTS(SELECT * FROM sys.tables WHERE name='BodyType')
	DROP TABLE BodyType

IF EXISTS(SELECT * FROM sys.tables WHERE name='Models')
	DROP TABLE Models

IF EXISTS(SELECT * FROM sys.tables WHERE name='Make')
	DROP TABLE Make

IF EXISTS(SELECT * FROM sys.tables WHERE name='Color')
	DROP TABLE Color

IF EXISTS(SELECT * FROM sys.tables WHERE name='Contacts')
	DROP TABLE Contacts

IF EXISTS(SELECT * FROM sys.tables WHERE name='Specials')
	DROP TABLE Specials
	
IF EXISTS(SELECT * FROM sys.tables WHERE name='Roles')
	DROP TABLE Roles



CREATE TABLE Roles(
	RoleID INT IDENTITY(1,1) PRIMARY KEY,
	[Role] nvarchar(30) NOT NULL

)
GO
	CREATE TABLE Specials(
	SpecialID INT IDENTITY(1,1) PRIMARY KEY,
	SpecialTitle nvarchar(30) NOT NULL,
	SpecialDescription nvarchar(300) NOT NULL,
)
GO

	CREATE TABLE PurchaseType(
	PurchaseTypeID INT IDENTITY(1,1) PRIMARY KEY,
	[Type] nvarchar(40) NOT NULL
)

GO
	CREATE TABLE BodyType(
	BodyTypeID INT IDENTITY(1,1) PRIMARY KEY,
	[Type] nvarchar(40) NOT NULL
)
GO
	CREATE TABLE Make(
	MakeID INT IDENTITY(1,1) PRIMARY KEY,
	MakeType nvarchar(50) NOT NULL,
)
GO
	CREATE TABLE Models(
	ModelsID INT IDENTITY(1,1) PRIMARY KEY,
	MakeID int FOREIGN KEY REFERENCES Make(MakeID),
	Model nvarchar(50) NOT NULL,
)
GO
	CREATE TABLE Color(
	ColorID INT IDENTITY(1,1) PRIMARY KEY,
	ColorName nvarchar(20) NOT NULL,

)
GO
	CREATE TABLE Vehicle(
	VehicleID INT IDENTITY(1,1) PRIMARY KEY,
	Id nvarchar(128) NOT NULL,
	ModelID int FOREIGN KEY REFERENCES Models(ModelsID),
	BodyTypeID int FOREIGN KEY REFERENCES BodyType(BodyTypeID),
	InteriorColorID int FOREIGN KEY REFERENCES Color(ColorID),
	ExteriorColorID int FOREIGN KEY REFERENCES Color(ColorID),
	IsAutomatic bit NOT NULL,
	SalesPrice decimal(8,2) NOT NULL,
	MSRP decimal(8,2) NOT NULL,
	Mileage int NULL,
	VIN nvarchar(20) NOT NULL,
	[Year] int NOT NULL,
	[Description] nvarchar(500) NULL,
	ImageFileName nvarchar(50) NOT NULL,
	IsFeatured bit NULL,
	CreatedDate datetime2 not null default(getdate()),
	IsNew as (case when Mileage < 1000 then 1 else 0 end)
)
GO


CREATE TABLE States(
	StateID INT IDENTITY(1,1) PRIMARY KEY,
StateAbbreviation varchar(2) NOT NULL
)
GO

	CREATE TABLE Sales(
	SalesID INT IDENTITY(1,1) PRIMARY KEY,
	Id nvarchar(128) NOT NULL,
	VehicleID int FOREIGN KEY REFERENCES Vehicle(VehicleID),
	PurchaseTypeID int FOREIGN KEY REFERENCES PurchaseType(PurchaseTypeID),
	StateID int FOREIGN KEY REFERENCES States(StateID),
	[Name] nvarchar(60) NOT NULL,
	Email varchar(30) NOT NULL,
	Phone INT NOT NULL,
	PurchasePrice decimal(8,2) NOT NULL,
	[Message] nvarchar(750) NOT NULL,
	Street1 nvarchar(50) NOT NULL,
	Street2 nvarchar(50) NULL,
	City nvarchar(50) NOT NULL,
	ZipCode int NOT NULL,
)
GO

	CREATE TABLE Contacts(
	ContactID INT IDENTITY(1,1) PRIMARY KEY,
	[Name] nvarchar(60) NOT NULL,
	Email varchar(30) NOT NULL,
	Phone INT NULL,
	[Message] nvarchar(750) NOT NULL,
)
GO


