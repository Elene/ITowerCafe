USE [ITowerCafeDB]
GO

/****** Object: Table [dbo].[MenuProductsMap] Script Date: 16.10.2018 1:40:21 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[MenuProductsMap] (
    [Id]            INT IDENTITY (1, 1) NOT NULL,
    [MenuId]        INT NOT NULL,
    [MenuProductId] INT NOT NULL
);


