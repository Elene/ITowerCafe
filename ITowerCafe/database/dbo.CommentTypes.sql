USE [ITowerCafeDB]
GO

/****** Object: Table [dbo].[CommentTypes] Script Date: 16.10.2018 1:38:39 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[CommentTypes] (
    [Id]   INT          IDENTITY (1, 1) NOT NULL,
    [Name] VARCHAR (50) NOT NULL
);


