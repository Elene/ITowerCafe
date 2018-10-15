SET IDENTITY_INSERT [dbo].[Orders] ON
INSERT INTO [dbo].[Orders] ([Id], [Cost], [Date], [Status], [UserId], [CompanyId]) VALUES (2002, CAST(19.00 AS Decimal(18, 2)), N'0001-01-01', N'N', 1, 2008)
INSERT INTO [dbo].[Orders] ([Id], [Cost], [Date], [Status], [UserId], [CompanyId]) VALUES (2003, CAST(0.80 AS Decimal(18, 2)), N'0001-01-01', N'N', 1, 2009)
SET IDENTITY_INSERT [dbo].[Orders] OFF
