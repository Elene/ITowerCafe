USE [ITowerCafeDB]
GO

/****** Object: Table [dbo].[Ratings] Script Date: 16.10.2018 1:41:04 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

DROP TABLE [dbo].[Ratings];


GO
CREATE TABLE [dbo].[Ratings] (
    [Id]    INT IDENTITY (1, 1) NOT NULL,
    [Value] INT NOT NULL
);


