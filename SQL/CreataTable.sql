/*
 * テーブル作成用SQL。
 */
USE [BookDB]
GO

CREATE TABLE [dbo].[Author] ( 
    [AuthorId] [bigint] IDENTITY (1, 1) NOT NULL, 
    [AuthorName] [nvarchar] (100) NOT NULL, 
    CONSTRAINT [PK_Author] PRIMARY KEY CLUSTERED ([AuthorId])
);

CREATE TABLE [dbo].[Book] ( 
    [BookId] [bigint] IDENTITY (1, 1) NOT NULL, 
    [Title] [nvarchar] (100) NOT NULL, 
    [AuthorId] [bigint] NULL, 
    CONSTRAINT [PK_Book] PRIMARY KEY CLUSTERED ([BookId])
);

ALTER TABLE [dbo].[Book] WITH CHECK ADD CONSTRAINT [FK_Book_AuthorId] 
    FOREIGN KEY ([AuthorId]) 
    REFERENCES [dbo].[Author] ([AuthorId]);

GO
