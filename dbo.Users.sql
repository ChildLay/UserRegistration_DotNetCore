Create database [UserDB]
GO

/****** Object: Table [dbo].[Users] Script Date: 6/10/2019 4:42:17 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Users] (
    [Id]                INT          IDENTITY (1, 1) NOT NULL,
    [Name]              VARCHAR (50) NULL,
    [Email]             VARCHAR (50) NULL,
    [Gender]            VARCHAR (50) NULL,
    [RegisteredDate]    VARCHAR (10) NULL,
    [EventDate]         VARCHAR (50) NULL,
    [AdditionalRequest] VARCHAR (50) NULL
);


