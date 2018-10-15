USE [ITowerCafeDB]
GO

/****** Object: Table [dbo].[CompanyTypes] Script Date: 16.10.2018 1:40:07 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[CompanyTypes] (
    [Id]   INT           IDENTITY (1, 1) NOT NULL,
    [Name] NVARCHAR (50) NOT NULL
);


