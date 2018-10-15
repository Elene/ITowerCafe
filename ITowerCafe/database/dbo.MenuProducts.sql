USE [ITowerCafeDB]
GO

/****** Object: Table [dbo].[MenuProducts] Script Date: 16.10.2018 1:40:15 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[MenuProducts] (
    [Id]              INT             IDENTITY (1, 1) NOT NULL,
    [Name]            NVARCHAR (50)   NOT NULL,
    [Price]           DECIMAL (18, 2) NOT NULL,
    [CategoryId]      INT             NOT NULL,
    [PreparationTime] INT             NOT NULL,
    [ProductCodeId]   INT             NOT NULL
);


