SET IDENTITY_INSERT [dbo].[MenuProducts] ON
INSERT INTO [dbo].[MenuProducts] ([Id], [Name], [Price], [CategoryId], [PreparationTime], [ProductCodeId]) VALUES (4002, N'Best Salad', CAST(12.00 AS Decimal(18, 2)), 1, 15, 1004)
INSERT INTO [dbo].[MenuProducts] ([Id], [Name], [Price], [CategoryId], [PreparationTime], [ProductCodeId]) VALUES (4003, N'Delicious Khachapuri', CAST(7.00 AS Decimal(18, 2)), 2, 21, 1005)
INSERT INTO [dbo].[MenuProducts] ([Id], [Name], [Price], [CategoryId], [PreparationTime], [ProductCodeId]) VALUES (4004, N'Khinkali Kalakuri', CAST(0.80 AS Decimal(18, 2)), 2, 15, 1002)
SET IDENTITY_INSERT [dbo].[MenuProducts] OFF
