USE [ITowerCafeDB]
GO

/****** Object: Table [dbo].[Products] Script Date: 16.10.2018 1:40:58 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Products] (
    [Id]   INT           IDENTITY (1, 1) NOT NULL,
    [Code] NVARCHAR (10) NOT NULL,
    [Name] NVARCHAR (50) NOT NULL
);


