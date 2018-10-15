USE [ITowerCafeDB]
GO

/****** Object: Table [dbo].[Orders] Script Date: 16.10.2018 1:40:43 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Orders] (
    [Id]        INT             IDENTITY (1, 1) NOT NULL,
    [Cost]      DECIMAL (18, 2) NOT NULL,
    [Date]      DATE            NOT NULL,
    [Status]    NVARCHAR (1)    NOT NULL,
    [UserId]    INT             NOT NULL,
    [CompanyId] INT             NOT NULL
);


