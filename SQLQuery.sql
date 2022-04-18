use ReCapDb;

CREATE TABLE [dbo].[Brands] (
    [Id]   INT           IDENTITY (1, 1) NOT NULL,
    [Name] VARCHAR (50) NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);
GO

CREATE TABLE [dbo].[CarImages]
(
	[Id] INT IDENTITY(1,1) NOT NULL,
	[CarId] INT NOT NULL,
	[ImagePath] varchar(250) NOT NULL,
	[Date] dateTime NOT NULL,
	FOREIGN KEY ([CarId]) REFERENCES  [dbo].[Cars] ([Id]),
	PRIMARY KEY CLUSTERED ([Id] ASC)	 
	)

GO

CREATE TABLE [dbo].[Cars] (
    [Id]          INT           IDENTITY (1, 1) NOT NULL,
    [BrandId]     INT           NOT NULL,
    [ColorId]     INT           NOT NULL,
    [ModelYear]   NVARCHAR (25) NOT NULL,
    [DailyPrice]  DECIMAL (18)  NOT NULL,
    [Description] VARCHAR (300) NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    FOREIGN KEY ([BrandId]) REFERENCES [dbo].[Brands] ([Id]),
    FOREIGN KEY ([ColorId]) REFERENCES [dbo].[Colors] ([Id])
);
GO

CREATE TABLE [dbo].[Colors] (
    [Id]   INT           IDENTITY (1, 1) NOT NULL,
    [Name] VARCHAR (50) NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

GO

CREATE TABLE [dbo].[Customers]
(
 [Id]           INT           IDENTITY (1, 1) NOT NULL,
[UserId] INT NOT NULL ,
[CompanyName] varchar(50) NOT NULL
FOREIGN KEY ([UserId]) REFERENCES [dbo].[Users] ([Id])
PRIMARY KEY CLUSTERED ([Id] ASC)
);


GO

CREATE TABLE [dbo].[OperationClaims] (
    [Id]   INT           IDENTITY (1, 1) NOT NULL,
    [Name] VARCHAR (250) NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

GO

CREATE TABLE [dbo].[Rentals]
(
	[Id] INT IDENTITY(1,1) NOT NULL ,
	[CarId] INT NOT NULL,
	[CustomerId] INT NOT NULL,
	[RentDate] dateTime NOT NULL,
	[ReturnDate] dateTime NULL,
	FOREIGN KEY ([CustomerId]) REFERENCES  [dbo].[Customers] ([Id]),
	FOREIGN KEY ([CarId]) REFERENCES  [dbo].[Cars] ([Id]),
	PRIMARY KEY CLUSTERED ([Id] ASC)	 
	);

GO

CREATE TABLE [dbo].[UserOperationClaims] (
    [Id]               INT IDENTITY (1, 1) NOT NULL,
    [UserId]           INT NOT NULL,
    [OperationClaimId] INT NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

GO

CREATE TABLE [dbo].[Users]
(
[Id] INT NOT NULL  IDENTITY(1,1),
[FirstName] VARCHAR (50) NOT NULL,
[LastName]  VARCHAR (50) NOT NULL,
[Email]     VARCHAR (50) NOT NULL,
[PasswordHash]  VARBINARY(500) NOT NULL,
[PasswordSalt] VARBINARY(500) NOT NULL, 
[Status] BIT NOT NULL, 
PRIMARY KEY CLUSTERED ([Id] ASC)
    
);



 INSERT INTO CarImages (CarId,ImagePath,Date) 
 Values(2,'www.audi.com/images','20120618 10:34:09 AM')

INSERT INTO Cars(BrandId, ColorId,ModelYear,DailyPrice,Description) 
VALUES( 1,1,'2007',90000,'Opel Corsa'),
(2,2,'2017',900000,'Volvo S60'),
(3,3,'2022',560000,'Audi A3 SP'),
(4,4,'2009',2190000,'Mercedes AMG G63')
 
 INSERT INTO Colors Values('Mustard'),('White'),('Black'),('Green')

 Insert Into Brands Values('Opel'),('Volvo'),('Audi'),('Mercedes')

