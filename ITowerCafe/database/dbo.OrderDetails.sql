USE [ITowerCafeDB]
GO

/****** Object: Table [dbo].[OrderDetails] Script Date: 16.10.2018 1:40:37 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[OrderDetails] (
    [Id]        INT IDENTITY (1, 1) NOT NULL,
    [OrderId]   INT NOT NULL,
    [ProductId] INT NOT NULL
);


