CREATE TABLE [dbo].[Brands] (
    [Id]   INT           IDENTITY (1, 1) NOT NULL,
    [Name] NVARCHAR (50) NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);
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
    [Name] NVARCHAR (50) NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);


GO

CREATE TABLE [dbo].[Users]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY(1,1),
	[FirstName] nvarchar(25) NOT NULL,
	[LastName] nvarchar(25) NOT NULL,
	[Email] nvarchar(25) NOT NULL,
	[Password] nvarchar(25) NOT NULL,
	[UserId] INT NOT NULL,
	FOREIGN KEY ([CustomerId]) REFERENCES  [dbo].[Customers] ([UserId])
		 
	)

	GO

CREATE TABLE [dbo].[Customers]
(
[UserId] INT NOT NULL PRIMARY KEY IDENTITY(1,1),
[CompanyName] nvarchar(50) NOT NULL

)


GO

CREATE TABLE [dbo].[Rentals]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY(1,1),
	[CarId] INT NOT NULL,
	[CustomerId] INT NOT NULL,
	[RentDate] dateTime NOT NULL,
	[ReturnDate] dateTime NULL,
	FOREIGN KEY ([CustomerId]) REFERENCES  [dbo].[Customers] ([UserId]),
	FOREIGN KEY ([CarId]) REFERENCES  [dbo].[Cars] ([Id])
		 
	)