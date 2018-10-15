USE [ITowerCafeDB]
GO

/****** Object: Table [dbo].[Reviews] Script Date: 16.10.2018 1:41:11 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Reviews] (
    [Id]        INT IDENTITY (1, 1) NOT NULL,
    [OrderId]   INT NOT NULL,
    [RatingId]  INT NOT NULL,
    [CommentId] INT NULL
);


