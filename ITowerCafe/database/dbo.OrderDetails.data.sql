SET IDENTITY_INSERT [dbo].[OrderDetails] ON
INSERT INTO [dbo].[OrderDetails] ([Id], [OrderId], [ProductId]) VALUES (3002, 2002, 4002)
INSERT INTO [dbo].[OrderDetails] ([Id], [OrderId], [ProductId]) VALUES (3003, 2002, 4003)
INSERT INTO [dbo].[OrderDetails] ([Id], [OrderId], [ProductId]) VALUES (3004, 2003, 4004)
SET IDENTITY_INSERT [dbo].[OrderDetails] OFF
