USE [ITowerCafeDB]
GO

/****** Object: Table [dbo].[ProductCategories] Script Date: 16.10.2018 1:40:51 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[ProductCategories] (
    [Id]   INT           IDENTITY (1, 1) NOT NULL,
    [Name] NVARCHAR (50) NOT NULL
);


