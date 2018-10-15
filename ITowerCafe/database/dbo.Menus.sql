USE [ITowerCafeDB]
GO

/****** Object: Table [dbo].[Menus] Script Date: 16.10.2018 1:40:29 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Menus] (
    [Id]               INT IDENTITY (1, 1) NOT NULL,
    [CreatorCompanyId] INT NOT NULL
);


