
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 11/02/2021 17:06:18
-- Generated from EDMX file: C:\Users\caldao\source\repos\MyProject4\MyProject4\Models\DB.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [MVCProject];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_TitlesBooks]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Books] DROP CONSTRAINT [FK_TitlesBooks];
GO
IF OBJECT_ID(N'[dbo].[FK_PeopleBooks]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Books] DROP CONSTRAINT [FK_PeopleBooks];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[People]', 'U') IS NOT NULL
    DROP TABLE [dbo].[People];
GO
IF OBJECT_ID(N'[dbo].[Books]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Books];
GO
IF OBJECT_ID(N'[dbo].[Titles]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Titles];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'People'
CREATE TABLE [dbo].[People] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] varchar(50)  NOT NULL,
    [Age] int  NULL
);
GO

-- Creating table 'Books'
CREATE TABLE [dbo].[Books] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [TitleId] int  NOT NULL,
    [PersonId] int  NULL
);
GO

-- Creating table 'Titles'
CREATE TABLE [dbo].[Titles] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'People'
ALTER TABLE [dbo].[People]
ADD CONSTRAINT [PK_People]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Books'
ALTER TABLE [dbo].[Books]
ADD CONSTRAINT [PK_Books]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Titles'
ALTER TABLE [dbo].[Titles]
ADD CONSTRAINT [PK_Titles]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [TitleId] in table 'Books'
ALTER TABLE [dbo].[Books]
ADD CONSTRAINT [FK_TitlesBooks]
    FOREIGN KEY ([TitleId])
    REFERENCES [dbo].[Titles]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_TitlesBooks'
CREATE INDEX [IX_FK_TitlesBooks]
ON [dbo].[Books]
    ([TitleId]);
GO

-- Creating foreign key on [PersonId] in table 'Books'
ALTER TABLE [dbo].[Books]
ADD CONSTRAINT [FK_PeopleBooks]
    FOREIGN KEY ([PersonId])
    REFERENCES [dbo].[People]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_PeopleBooks'
CREATE INDEX [IX_FK_PeopleBooks]
ON [dbo].[Books]
    ([PersonId]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------