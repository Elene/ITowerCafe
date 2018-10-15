USE [ITowerCafeDB]
GO

/****** Object: Table [dbo].[Comments] Script Date: 16.10.2018 1:37:12 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Comments] (
    [Id]     INT            IDENTITY (1, 1) NOT NULL,
    [TypeId] INT            NOT NULL,
    [Text]   NVARCHAR (500) NOT NULL
);


