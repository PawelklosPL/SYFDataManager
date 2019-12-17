
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 12/17/2019 20:52:20
-- Generated from EDMX file: C:\Users\Lecytyna Sojowa\Documents\GitHub\SYFDataManager\DBConnection\SYFModel.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [aspnet-SYFDataManager-20191027023639];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK__Avatar_To__Avata__47DBAE45]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Avatar_To_Tag] DROP CONSTRAINT [FK__Avatar_To__Avata__47DBAE45];
GO
IF OBJECT_ID(N'[dbo].[FK__Avatar_To__Avata__5AEE82B9]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Avatar_To_ImageUrl] DROP CONSTRAINT [FK__Avatar_To__Avata__5AEE82B9];
GO
IF OBJECT_ID(N'[dbo].[FK__Avatar_To__Image__5BE2A6F2]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Avatar_To_ImageUrl] DROP CONSTRAINT [FK__Avatar_To__Image__5BE2A6F2];
GO
IF OBJECT_ID(N'[dbo].[FK__Avatar_To__Tag_I__48CFD27E]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Avatar_To_Tag] DROP CONSTRAINT [FK__Avatar_To__Tag_I__48CFD27E];
GO
IF OBJECT_ID(N'[dbo].[FK_dbo_AspNetUserClaims_dbo_AspNetUsers_UserId]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[AspNetUserClaims] DROP CONSTRAINT [FK_dbo_AspNetUserClaims_dbo_AspNetUsers_UserId];
GO
IF OBJECT_ID(N'[dbo].[FK_dbo_AspNetUserLogins_dbo_AspNetUsers_UserId]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[AspNetUserLogins] DROP CONSTRAINT [FK_dbo_AspNetUserLogins_dbo_AspNetUsers_UserId];
GO
IF OBJECT_ID(N'[dbo].[FK_dbo_AspNetUserRoles_dbo_AspNetRoles_RoleId]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[AspNetUserRoles] DROP CONSTRAINT [FK_dbo_AspNetUserRoles_dbo_AspNetRoles_RoleId];
GO
IF OBJECT_ID(N'[dbo].[FK_dbo_AspNetUserRoles_dbo_AspNetUsers_UserId]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[AspNetUserRoles] DROP CONSTRAINT [FK_dbo_AspNetUserRoles_dbo_AspNetUsers_UserId];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[__MigrationHistory]', 'U') IS NOT NULL
    DROP TABLE [dbo].[__MigrationHistory];
GO
IF OBJECT_ID(N'[dbo].[AspNetRoles]', 'U') IS NOT NULL
    DROP TABLE [dbo].[AspNetRoles];
GO
IF OBJECT_ID(N'[dbo].[AspNetUserClaims]', 'U') IS NOT NULL
    DROP TABLE [dbo].[AspNetUserClaims];
GO
IF OBJECT_ID(N'[dbo].[AspNetUserLogins]', 'U') IS NOT NULL
    DROP TABLE [dbo].[AspNetUserLogins];
GO
IF OBJECT_ID(N'[dbo].[AspNetUserRoles]', 'U') IS NOT NULL
    DROP TABLE [dbo].[AspNetUserRoles];
GO
IF OBJECT_ID(N'[dbo].[AspNetUsers]', 'U') IS NOT NULL
    DROP TABLE [dbo].[AspNetUsers];
GO
IF OBJECT_ID(N'[dbo].[Avatar]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Avatar];
GO
IF OBJECT_ID(N'[dbo].[Avatar_To_ImageUrl]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Avatar_To_ImageUrl];
GO
IF OBJECT_ID(N'[dbo].[Avatar_To_Tag]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Avatar_To_Tag];
GO
IF OBJECT_ID(N'[dbo].[ImageUrl]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ImageUrl];
GO
IF OBJECT_ID(N'[dbo].[Tag]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Tag];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Avatars'
CREATE TABLE [dbo].[Avatars] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [AuthorName] varchar(100)  NULL,
    [AuthorId] int  NULL,
    [FolderName] varchar(100)  NULL,
    [ShortDescription] varchar(250)  NULL,
    [PublishDate] datetime  NULL,
    [ImagesUrl_Id] int  NULL,
    [Tag_Id] int  NULL,
    [SharePoint] int  NULL,
    [Description] varchar(250)  NULL,
    [SharePoints] int  NULL,
    [Name] varchar(250)  NULL,
    [Comment_Id] int  NULL
);
GO

-- Creating table 'Avatar_To_ImageUrl'
CREATE TABLE [dbo].[Avatar_To_ImageUrl] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Avatar_Id] int  NOT NULL,
    [ImageUrl_Id] int  NOT NULL
);
GO

-- Creating table 'Avatar_To_Tag'
CREATE TABLE [dbo].[Avatar_To_Tag] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Avatar_Id] int  NOT NULL,
    [Tag_Id] int  NOT NULL
);
GO

-- Creating table 'ImageUrls'
CREATE TABLE [dbo].[ImageUrls] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(50)  NULL,
    [Url] nvarchar(50)  NULL
);
GO

-- Creating table 'Tags'
CREATE TABLE [dbo].[Tags] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(50)  NULL
);
GO

-- Creating table 'C__MigrationHistory'
CREATE TABLE [dbo].[C__MigrationHistory] (
    [MigrationId] nvarchar(150)  NOT NULL,
    [ContextKey] nvarchar(300)  NOT NULL,
    [Model] varbinary(max)  NOT NULL,
    [ProductVersion] nvarchar(32)  NOT NULL
);
GO

-- Creating table 'AspNetRoles'
CREATE TABLE [dbo].[AspNetRoles] (
    [Id] nvarchar(128)  NOT NULL,
    [Name] nvarchar(256)  NOT NULL
);
GO

-- Creating table 'AspNetUserClaims'
CREATE TABLE [dbo].[AspNetUserClaims] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [UserId] nvarchar(128)  NOT NULL,
    [ClaimType] nvarchar(max)  NULL,
    [ClaimValue] nvarchar(max)  NULL
);
GO

-- Creating table 'AspNetUserLogins'
CREATE TABLE [dbo].[AspNetUserLogins] (
    [LoginProvider] nvarchar(128)  NOT NULL,
    [ProviderKey] nvarchar(128)  NOT NULL,
    [UserId] nvarchar(128)  NOT NULL
);
GO

-- Creating table 'AspNetUsers'
CREATE TABLE [dbo].[AspNetUsers] (
    [Id] nvarchar(128)  NOT NULL,
    [Email] nvarchar(256)  NULL,
    [EmailConfirmed] bit  NOT NULL,
    [PasswordHash] nvarchar(max)  NULL,
    [SecurityStamp] nvarchar(max)  NULL,
    [PhoneNumber] nvarchar(max)  NULL,
    [PhoneNumberConfirmed] bit  NOT NULL,
    [TwoFactorEnabled] bit  NOT NULL,
    [LockoutEndDateUtc] datetime  NULL,
    [LockoutEnabled] bit  NOT NULL,
    [AccessFailedCount] int  NOT NULL,
    [UserName] nvarchar(256)  NOT NULL
);
GO

-- Creating table 'AspNetUserRoles'
CREATE TABLE [dbo].[AspNetUserRoles] (
    [AspNetRoles_Id] nvarchar(128)  NOT NULL,
    [AspNetUsers_Id] nvarchar(128)  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'Avatars'
ALTER TABLE [dbo].[Avatars]
ADD CONSTRAINT [PK_Avatars]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Avatar_To_ImageUrl'
ALTER TABLE [dbo].[Avatar_To_ImageUrl]
ADD CONSTRAINT [PK_Avatar_To_ImageUrl]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Avatar_To_Tag'
ALTER TABLE [dbo].[Avatar_To_Tag]
ADD CONSTRAINT [PK_Avatar_To_Tag]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'ImageUrls'
ALTER TABLE [dbo].[ImageUrls]
ADD CONSTRAINT [PK_ImageUrls]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Tags'
ALTER TABLE [dbo].[Tags]
ADD CONSTRAINT [PK_Tags]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [MigrationId], [ContextKey] in table 'C__MigrationHistory'
ALTER TABLE [dbo].[C__MigrationHistory]
ADD CONSTRAINT [PK_C__MigrationHistory]
    PRIMARY KEY CLUSTERED ([MigrationId], [ContextKey] ASC);
GO

-- Creating primary key on [Id] in table 'AspNetRoles'
ALTER TABLE [dbo].[AspNetRoles]
ADD CONSTRAINT [PK_AspNetRoles]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'AspNetUserClaims'
ALTER TABLE [dbo].[AspNetUserClaims]
ADD CONSTRAINT [PK_AspNetUserClaims]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [LoginProvider], [ProviderKey], [UserId] in table 'AspNetUserLogins'
ALTER TABLE [dbo].[AspNetUserLogins]
ADD CONSTRAINT [PK_AspNetUserLogins]
    PRIMARY KEY CLUSTERED ([LoginProvider], [ProviderKey], [UserId] ASC);
GO

-- Creating primary key on [Id] in table 'AspNetUsers'
ALTER TABLE [dbo].[AspNetUsers]
ADD CONSTRAINT [PK_AspNetUsers]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [AspNetRoles_Id], [AspNetUsers_Id] in table 'AspNetUserRoles'
ALTER TABLE [dbo].[AspNetUserRoles]
ADD CONSTRAINT [PK_AspNetUserRoles]
    PRIMARY KEY CLUSTERED ([AspNetRoles_Id], [AspNetUsers_Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [UserId] in table 'AspNetUserClaims'
ALTER TABLE [dbo].[AspNetUserClaims]
ADD CONSTRAINT [FK_dbo_AspNetUserClaims_dbo_AspNetUsers_UserId]
    FOREIGN KEY ([UserId])
    REFERENCES [dbo].[AspNetUsers]
        ([Id])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_dbo_AspNetUserClaims_dbo_AspNetUsers_UserId'
CREATE INDEX [IX_FK_dbo_AspNetUserClaims_dbo_AspNetUsers_UserId]
ON [dbo].[AspNetUserClaims]
    ([UserId]);
GO

-- Creating foreign key on [UserId] in table 'AspNetUserLogins'
ALTER TABLE [dbo].[AspNetUserLogins]
ADD CONSTRAINT [FK_dbo_AspNetUserLogins_dbo_AspNetUsers_UserId]
    FOREIGN KEY ([UserId])
    REFERENCES [dbo].[AspNetUsers]
        ([Id])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_dbo_AspNetUserLogins_dbo_AspNetUsers_UserId'
CREATE INDEX [IX_FK_dbo_AspNetUserLogins_dbo_AspNetUsers_UserId]
ON [dbo].[AspNetUserLogins]
    ([UserId]);
GO

-- Creating foreign key on [AspNetRoles_Id] in table 'AspNetUserRoles'
ALTER TABLE [dbo].[AspNetUserRoles]
ADD CONSTRAINT [FK_AspNetUserRoles_AspNetRole]
    FOREIGN KEY ([AspNetRoles_Id])
    REFERENCES [dbo].[AspNetRoles]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [AspNetUsers_Id] in table 'AspNetUserRoles'
ALTER TABLE [dbo].[AspNetUserRoles]
ADD CONSTRAINT [FK_AspNetUserRoles_AspNetUser]
    FOREIGN KEY ([AspNetUsers_Id])
    REFERENCES [dbo].[AspNetUsers]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_AspNetUserRoles_AspNetUser'
CREATE INDEX [IX_FK_AspNetUserRoles_AspNetUser]
ON [dbo].[AspNetUserRoles]
    ([AspNetUsers_Id]);
GO

-- Creating foreign key on [Avatar_Id] in table 'Avatar_To_Tag'
ALTER TABLE [dbo].[Avatar_To_Tag]
ADD CONSTRAINT [FK__Avatar_To__Avata__47DBAE45]
    FOREIGN KEY ([Avatar_Id])
    REFERENCES [dbo].[Avatars]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__Avatar_To__Avata__47DBAE45'
CREATE INDEX [IX_FK__Avatar_To__Avata__47DBAE45]
ON [dbo].[Avatar_To_Tag]
    ([Avatar_Id]);
GO

-- Creating foreign key on [Tag_Id] in table 'Avatar_To_Tag'
ALTER TABLE [dbo].[Avatar_To_Tag]
ADD CONSTRAINT [FK__Avatar_To__Tag_I__48CFD27E]
    FOREIGN KEY ([Tag_Id])
    REFERENCES [dbo].[Tags]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__Avatar_To__Tag_I__48CFD27E'
CREATE INDEX [IX_FK__Avatar_To__Tag_I__48CFD27E]
ON [dbo].[Avatar_To_Tag]
    ([Tag_Id]);
GO

-- Creating foreign key on [Avatar_Id] in table 'Avatar_To_ImageUrl'
ALTER TABLE [dbo].[Avatar_To_ImageUrl]
ADD CONSTRAINT [FK__Avatar_To__Avata__5AEE82B9]
    FOREIGN KEY ([Avatar_Id])
    REFERENCES [dbo].[Avatars]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__Avatar_To__Avata__5AEE82B9'
CREATE INDEX [IX_FK__Avatar_To__Avata__5AEE82B9]
ON [dbo].[Avatar_To_ImageUrl]
    ([Avatar_Id]);
GO

-- Creating foreign key on [ImageUrl_Id] in table 'Avatar_To_ImageUrl'
ALTER TABLE [dbo].[Avatar_To_ImageUrl]
ADD CONSTRAINT [FK__Avatar_To__Image__5BE2A6F2]
    FOREIGN KEY ([ImageUrl_Id])
    REFERENCES [dbo].[ImageUrls]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__Avatar_To__Image__5BE2A6F2'
CREATE INDEX [IX_FK__Avatar_To__Image__5BE2A6F2]
ON [dbo].[Avatar_To_ImageUrl]
    ([ImageUrl_Id]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------