
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 06/16/2016 10:32:27
-- Generated from EDMX file: C:\Users\Michal\Documents\BasicCMSPage\Domain\DB.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [WorldNews];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_NewsUsers]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[News] DROP CONSTRAINT [FK_NewsUsers];
GO
IF OBJECT_ID(N'[dbo].[FK_UsersRoles_Users]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[UsersRoles] DROP CONSTRAINT [FK_UsersRoles_Users];
GO
IF OBJECT_ID(N'[dbo].[FK_UsersRoles_Roles]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[UsersRoles] DROP CONSTRAINT [FK_UsersRoles_Roles];
GO
IF OBJECT_ID(N'[dbo].[FK_StaticPagesUsers]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[StaticPages] DROP CONSTRAINT [FK_StaticPagesUsers];
GO
IF OBJECT_ID(N'[dbo].[FK_CommentsNews]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Comment] DROP CONSTRAINT [FK_CommentsNews];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[News]', 'U') IS NOT NULL
    DROP TABLE [dbo].[News];
GO
IF OBJECT_ID(N'[dbo].[Users]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Users];
GO
IF OBJECT_ID(N'[dbo].[Roles]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Roles];
GO
IF OBJECT_ID(N'[dbo].[StaticPages]', 'U') IS NOT NULL
    DROP TABLE [dbo].[StaticPages];
GO
IF OBJECT_ID(N'[dbo].[Comment]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Comment];
GO
IF OBJECT_ID(N'[dbo].[UsersRoles]', 'U') IS NOT NULL
    DROP TABLE [dbo].[UsersRoles];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'News'
CREATE TABLE [dbo].[News] (
    [Id] bigint IDENTITY(1,1) NOT NULL,
    [AddDate] datetime  NOT NULL,
    [ModificationDate] datetime  NOT NULL,
    [Content] nvarchar(max)  NOT NULL,
    [Archive] bit  NOT NULL,
    [UsersId] bigint  NOT NULL,
    [Title] nvarchar(max)  NOT NULL,
    [Description] nvarchar(max)  NULL
);
GO

-- Creating table 'Users'
CREATE TABLE [dbo].[Users] (
    [Id] bigint IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [Surname] nvarchar(max)  NOT NULL,
    [Email] nvarchar(max)  NOT NULL,
    [Password] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Roles'
CREATE TABLE [dbo].[Roles] (
    [Id] bigint IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [Description] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'StaticPages'
CREATE TABLE [dbo].[StaticPages] (
    [Id] bigint IDENTITY(1,1) NOT NULL,
    [AddedDate] datetime  NOT NULL,
    [ModificationDate] datetime  NOT NULL,
    [Content] nvarchar(max)  NOT NULL,
    [UsersId] bigint  NOT NULL,
    [Title] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Comment'
CREATE TABLE [dbo].[Comment] (
    [Id] bigint IDENTITY(1,1) NOT NULL,
    [AddDate] datetime  NOT NULL,
    [Comment] nvarchar(max)  NOT NULL,
    [UserName] nvarchar(max)  NOT NULL,
    [UserIP] nvarchar(max)  NOT NULL,
    [UserEmail] nvarchar(max)  NOT NULL,
    [News_Id] bigint  NOT NULL
);
GO

-- Creating table 'UsersRoles'
CREATE TABLE [dbo].[UsersRoles] (
    [Users_Id] bigint  NOT NULL,
    [Roles_Id] bigint  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'News'
ALTER TABLE [dbo].[News]
ADD CONSTRAINT [PK_News]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Users'
ALTER TABLE [dbo].[Users]
ADD CONSTRAINT [PK_Users]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Roles'
ALTER TABLE [dbo].[Roles]
ADD CONSTRAINT [PK_Roles]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'StaticPages'
ALTER TABLE [dbo].[StaticPages]
ADD CONSTRAINT [PK_StaticPages]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Comment'
ALTER TABLE [dbo].[Comment]
ADD CONSTRAINT [PK_Comment]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Users_Id], [Roles_Id] in table 'UsersRoles'
ALTER TABLE [dbo].[UsersRoles]
ADD CONSTRAINT [PK_UsersRoles]
    PRIMARY KEY CLUSTERED ([Users_Id], [Roles_Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [UsersId] in table 'News'
ALTER TABLE [dbo].[News]
ADD CONSTRAINT [FK_NewsUsers]
    FOREIGN KEY ([UsersId])
    REFERENCES [dbo].[Users]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_NewsUsers'
CREATE INDEX [IX_FK_NewsUsers]
ON [dbo].[News]
    ([UsersId]);
GO

-- Creating foreign key on [Users_Id] in table 'UsersRoles'
ALTER TABLE [dbo].[UsersRoles]
ADD CONSTRAINT [FK_UsersRoles_Users]
    FOREIGN KEY ([Users_Id])
    REFERENCES [dbo].[Users]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Roles_Id] in table 'UsersRoles'
ALTER TABLE [dbo].[UsersRoles]
ADD CONSTRAINT [FK_UsersRoles_Roles]
    FOREIGN KEY ([Roles_Id])
    REFERENCES [dbo].[Roles]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_UsersRoles_Roles'
CREATE INDEX [IX_FK_UsersRoles_Roles]
ON [dbo].[UsersRoles]
    ([Roles_Id]);
GO

-- Creating foreign key on [UsersId] in table 'StaticPages'
ALTER TABLE [dbo].[StaticPages]
ADD CONSTRAINT [FK_StaticPagesUsers]
    FOREIGN KEY ([UsersId])
    REFERENCES [dbo].[Users]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_StaticPagesUsers'
CREATE INDEX [IX_FK_StaticPagesUsers]
ON [dbo].[StaticPages]
    ([UsersId]);
GO

-- Creating foreign key on [News_Id] in table 'Comment'
ALTER TABLE [dbo].[Comment]
ADD CONSTRAINT [FK_CommentsNews]
    FOREIGN KEY ([News_Id])
    REFERENCES [dbo].[News]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_CommentsNews'
CREATE INDEX [IX_FK_CommentsNews]
ON [dbo].[Comment]
    ([News_Id]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------