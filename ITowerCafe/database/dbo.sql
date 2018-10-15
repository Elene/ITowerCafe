CREATE TABLE [dbo].[CommentTypes] (
    [Id]   INT          IDENTITY (1, 1) NOT NULL,
    [Name] VARCHAR (50) NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);


---
SET IDENTITY_INSERT [dbo].[CommentTypes] ON
INSERT INTO [dbo].[CommentTypes] ([Id], [Name]) VALUES (1, N'Service')
SET IDENTITY_INSERT [dbo].[CommentTypes] OFF

---
CREATE TABLE [dbo].[CompanyCostTypes] (
    [Id]   INT          IDENTITY (1, 1) NOT NULL,
    [Name] VARCHAR (50) NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);


---
SET IDENTITY_INSERT [dbo].[CompanyCostTypes] ON
INSERT INTO [dbo].[CompanyCostTypes] ([Id], [Name]) VALUES (1, N'Cheap')
INSERT INTO [dbo].[CompanyCostTypes] ([Id], [Name]) VALUES (2, N'Expensive')
SET IDENTITY_INSERT [dbo].[CompanyCostTypes] OFF

---
CREATE TABLE [dbo].[CompanyTypes] (
    [Id]   INT           IDENTITY (1, 1) NOT NULL,
    [Name] NVARCHAR (50) NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

---
SET IDENTITY_INSERT [dbo].[CompanyTypes] ON
INSERT INTO [dbo].[CompanyTypes] ([Id], [Name]) VALUES (1, N'Fast Food')
INSERT INTO [dbo].[CompanyTypes] ([Id], [Name]) VALUES (8, N'Restaurant')
SET IDENTITY_INSERT [dbo].[CompanyTypes] OFF


---
CREATE TABLE [dbo].[ProductCategories] (
    [Id]   INT           IDENTITY (1, 1) NOT NULL,
    [Name] NVARCHAR (50) NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);


---
SET IDENTITY_INSERT [dbo].[ProductCategories] ON
INSERT INTO [dbo].[ProductCategories] ([Id], [Name]) VALUES (1, N'Salad')
INSERT INTO [dbo].[ProductCategories] ([Id], [Name]) VALUES (2, N'Hotdish')
SET IDENTITY_INSERT [dbo].[ProductCategories] OFF

---
CREATE TABLE [dbo].[Comments] (
    [Id]     INT            IDENTITY (1, 1) NOT NULL,
    [TypeId] INT            NOT NULL,
    [Text]   NVARCHAR (500) NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [Comments_FK2] FOREIGN KEY ([TypeId]) REFERENCES [dbo].[CommentTypes] ([Id])
);

---
SET IDENTITY_INSERT [dbo].[Comments] ON
INSERT INTO [dbo].[Comments] ([Id], [TypeId], [Text]) VALUES (4004, 1, N'This was the best khachapuri ever')
INSERT INTO [dbo].[Comments] ([Id], [TypeId], [Text]) VALUES (4005, 1, N'I liked it, but it was not my best experience.')
SET IDENTITY_INSERT [dbo].[Comments] OFF

---
CREATE TABLE [dbo].[Products] (
    [Id]   INT           IDENTITY (1, 1) NOT NULL,
    [Code] NVARCHAR (10) NOT NULL,
    [Name] NVARCHAR (50) NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

---
SET IDENTITY_INSERT [dbo].[Products] ON
INSERT INTO [dbo].[Products] ([Id], [Code], [Name]) VALUES (1002, N'KHI', N'Khinkali')
INSERT INTO [dbo].[Products] ([Id], [Code], [Name]) VALUES (1003, N'MTS', N'Mtsvadi')
INSERT INTO [dbo].[Products] ([Id], [Code], [Name]) VALUES (1004, N'SAL', N'Salad')
INSERT INTO [dbo].[Products] ([Id], [Code], [Name]) VALUES (1005, N'KHA', N'Khachapuri')
INSERT INTO [dbo].[Products] ([Id], [Code], [Name]) VALUES (1006, N'SAN', N'Sandwich')
SET IDENTITY_INSERT [dbo].[Products] OFF


---
CREATE TABLE [dbo].[Companies] (
    [Id]          INT            IDENTITY (1, 1) NOT NULL,
    [Name]        NVARCHAR (50)  NOT NULL,
    [Description] NVARCHAR (500) NOT NULL,
    [LogoUrl]     NVARCHAR (100) NOT NULL,
    [TypeId]      INT            NOT NULL,
    [CostId]      INT            NOT NULL,
    [CreateDate]  DATE           DEFAULT (getdate()) NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [Companies_FK2] FOREIGN KEY ([CostId]) REFERENCES [dbo].[CompanyCostTypes] ([Id]),
    CONSTRAINT [Companies_FK1] FOREIGN KEY ([TypeId]) REFERENCES [dbo].[CompanyTypes] ([Id])
);

---
SET IDENTITY_INSERT [dbo].[Companies] ON
INSERT INTO [dbo].[Companies] ([Id], [Name], [Description], [LogoUrl], [TypeId], [CostId], [CreateDate]) VALUES (2008, N'Subway', N'Casual counter-serve chain for build-your-own sandwiches & salads.', N'https://www.subway.com/~/media/Base_English/Images/Branding/subway-logo-new-1200x630.png', 1, 1, NULL)
INSERT INTO [dbo].[Companies] ([Id], [Name], [Description], [LogoUrl], [TypeId], [CostId], [CreateDate]) VALUES (2009, N'Restaurant Meama', N'Meama is a Georgian restaurant, located in very historical heart of capital. Incredible atmosphere created by Traditional Georgian dishes, wine and stunning views of Tbilisi will keep you coming.', N'https://cdn1.vectorstock.com/i/1000x1000/36/00/fork-leaf-restaurant-eco-logo-vector-19313600.jpg', 8, 2, NULL)
SET IDENTITY_INSERT [dbo].[Companies] OFF

---
CREATE TABLE [dbo].[Orders] (
    [Id]        INT             IDENTITY (1, 1) NOT NULL,
    [Cost]      DECIMAL (18, 2) NOT NULL,
    [Date]      DATE            NOT NULL,
    [Status]    NVARCHAR (1)    NOT NULL,
    [UserId]    INT             NOT NULL,
    [CompanyId] INT             NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [Orders_FK1] FOREIGN KEY ([CompanyId]) REFERENCES [dbo].[Companies] ([Id]),
    CHECK ([Status]='N' OR [Status]='S' OR [Status]='C')
);

---
SET IDENTITY_INSERT [dbo].[Orders] ON
INSERT INTO [dbo].[Orders] ([Id], [Cost], [Date], [Status], [UserId], [CompanyId]) VALUES (2002, CAST(19.00 AS Decimal(18, 2)), N'0001-01-01', N'N', 1, 2008)
INSERT INTO [dbo].[Orders] ([Id], [Cost], [Date], [Status], [UserId], [CompanyId]) VALUES (2003, CAST(0.80 AS Decimal(18, 2)), N'0001-01-01', N'N', 1, 2009)
SET IDENTITY_INSERT [dbo].[Orders] OFF

---
CREATE TABLE [dbo].[Menus] (
    [Id]               INT IDENTITY (1, 1) NOT NULL,
    [CreatorCompanyId] INT NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [Menus_FK1] FOREIGN KEY ([CreatorCompanyId]) REFERENCES [dbo].[Companies] ([Id])
);

---
SET IDENTITY_INSERT [dbo].[Menus] ON
INSERT INTO [dbo].[Menus] ([Id], [CreatorCompanyId]) VALUES (2002, 2008)
INSERT INTO [dbo].[Menus] ([Id], [CreatorCompanyId]) VALUES (2003, 2009)
SET IDENTITY_INSERT [dbo].[Menus] OFF


---
CREATE TABLE [dbo].[MenuProducts] (
    [Id]              INT             IDENTITY (1, 1) NOT NULL,
    [Name]            NVARCHAR (50)   NOT NULL,
    [Price]           DECIMAL (18, 2) NOT NULL,
    [CategoryId]      INT             NOT NULL,
    [PreparationTime] INT             NOT NULL,
    [ProductCodeId]   INT             NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [MenuProducts_FK1] FOREIGN KEY ([CategoryId]) REFERENCES [dbo].[ProductCategories] ([Id]),
    CONSTRAINT [MenuProducts_FK2] FOREIGN KEY ([ProductCodeId]) REFERENCES [dbo].[Products] ([Id])
);
---
SET IDENTITY_INSERT [dbo].[MenuProducts] ON
INSERT INTO [dbo].[MenuProducts] ([Id], [Name], [Price], [CategoryId], [PreparationTime], [ProductCodeId]) VALUES (4002, N'Best Salad', CAST(12.00 AS Decimal(18, 2)), 1, 15, 1004)
INSERT INTO [dbo].[MenuProducts] ([Id], [Name], [Price], [CategoryId], [PreparationTime], [ProductCodeId]) VALUES (4003, N'Delicious Khachapuri', CAST(7.00 AS Decimal(18, 2)), 2, 21, 1005)
INSERT INTO [dbo].[MenuProducts] ([Id], [Name], [Price], [CategoryId], [PreparationTime], [ProductCodeId]) VALUES (4004, N'Khinkali Kalakuri', CAST(0.80 AS Decimal(18, 2)), 2, 15, 1002)
SET IDENTITY_INSERT [dbo].[MenuProducts] OFF

---
CREATE TABLE [dbo].[MenuProductsMap] (
    [Id]            INT IDENTITY (1, 1) NOT NULL,
    [MenuId]        INT NOT NULL,
    [MenuProductId] INT NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [MenuProductsMap_FK1] FOREIGN KEY ([MenuId]) REFERENCES [dbo].[Menus] ([Id]),
    CONSTRAINT [MenuProductsMap_FK2] FOREIGN KEY ([MenuProductId]) REFERENCES [dbo].[MenuProducts] ([Id])
);

---
SET IDENTITY_INSERT [dbo].[MenuProductsMap] ON
INSERT INTO [dbo].[MenuProductsMap] ([Id], [MenuId], [MenuProductId]) VALUES (3002, 2002, 4002)
INSERT INTO [dbo].[MenuProductsMap] ([Id], [MenuId], [MenuProductId]) VALUES (3003, 2002, 4003)
INSERT INTO [dbo].[MenuProductsMap] ([Id], [MenuId], [MenuProductId]) VALUES (3004, 2003, 4004)
SET IDENTITY_INSERT [dbo].[MenuProductsMap] OFF


---
CREATE TABLE [dbo].[OrderDetails] (
    [Id]        INT IDENTITY (1, 1) NOT NULL,
    [OrderId]   INT NOT NULL,
    [ProductId] INT NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [OrderDetails_FK1] FOREIGN KEY ([OrderId]) REFERENCES [dbo].[Orders] ([Id]),
    CONSTRAINT [OrderDetails_FK2] FOREIGN KEY ([ProductId]) REFERENCES [dbo].[MenuProducts] ([Id])
);

---
SET IDENTITY_INSERT [dbo].[OrderDetails] ON
INSERT INTO [dbo].[OrderDetails] ([Id], [OrderId], [ProductId]) VALUES (3002, 2002, 4002)
INSERT INTO [dbo].[OrderDetails] ([Id], [OrderId], [ProductId]) VALUES (3003, 2002, 4003)
INSERT INTO [dbo].[OrderDetails] ([Id], [OrderId], [ProductId]) VALUES (3004, 2003, 4004)
SET IDENTITY_INSERT [dbo].[OrderDetails] OFF

---
CREATE TABLE [dbo].[Ratings] (
    [Id]    INT IDENTITY (1, 1) NOT NULL,
    [Value] INT NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

---
SET IDENTITY_INSERT [dbo].[Ratings] ON
INSERT INTO [dbo].[Ratings] ([Id], [Value]) VALUES (4004, 5)
INSERT INTO [dbo].[Ratings] ([Id], [Value]) VALUES (4005, 4)
SET IDENTITY_INSERT [dbo].[Ratings] OFF


---
CREATE TABLE [dbo].[Reviews] (
    [Id]        INT IDENTITY (1, 1) NOT NULL,
    [OrderId]   INT NOT NULL,
    [RatingId]  INT NOT NULL,
    [CommentId] INT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [Reviews_FK3] FOREIGN KEY ([CommentId]) REFERENCES [dbo].[Comments] ([Id]),
    CONSTRAINT [Reviews_FK1] FOREIGN KEY ([OrderId]) REFERENCES [dbo].[Orders] ([Id]),
    CONSTRAINT [Reviews_FK2] FOREIGN KEY ([RatingId]) REFERENCES [dbo].[Ratings] ([Id])
);

---
SET IDENTITY_INSERT [dbo].[Reviews] ON
INSERT INTO [dbo].[Reviews] ([Id], [OrderId], [RatingId], [CommentId]) VALUES (3004, 2002, 4004, 4004)
INSERT INTO [dbo].[Reviews] ([Id], [OrderId], [RatingId], [CommentId]) VALUES (3005, 2003, 4005, 4005)
SET IDENTITY_INSERT [dbo].[Reviews] OFF



