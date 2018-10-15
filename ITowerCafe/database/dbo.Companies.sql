USE [ITowerCafeDB]
GO

/****** Object: Table [dbo].[Companies] Script Date: 16.10.2018 1:39:10 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Companies] (
    [Id]          INT            IDENTITY (1, 1) NOT NULL,
    [Name]        NVARCHAR (50)  NOT NULL,
    [Description] NVARCHAR (500) NOT NULL,
    [LogoUrl]     NVARCHAR (100) NOT NULL,
    [TypeId]      INT            NOT NULL,
    [CostId]      INT            NOT NULL,
    [CreateDate]  DATE           NULL
);


