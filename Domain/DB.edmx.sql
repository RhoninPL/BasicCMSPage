
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 06/14/2016 14:01:37
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


-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[NewsSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[NewsSet];
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

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------