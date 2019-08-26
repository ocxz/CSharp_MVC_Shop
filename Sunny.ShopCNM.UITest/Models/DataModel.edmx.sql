
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 08/19/2019 13:19:46
-- Generated from EDMX file: F:\c#代码\c#进阶学习\5、Asp.Net学习\8、Mvc实现超市后台cnm\Sunny.ShopCNM\Sunny.ShopCNM.UITest\Models\DataModel.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [Sunny.ShopCNMTest];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_ProvinceCity]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[City] DROP CONSTRAINT [FK_ProvinceCity];
GO
IF OBJECT_ID(N'[dbo].[FK_CityCounty]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[County] DROP CONSTRAINT [FK_CityCounty];
GO
IF OBJECT_ID(N'[dbo].[FK_AddressProvince]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Province] DROP CONSTRAINT [FK_AddressProvince];
GO
IF OBJECT_ID(N'[dbo].[FK_AddressCity]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[City] DROP CONSTRAINT [FK_AddressCity];
GO
IF OBJECT_ID(N'[dbo].[FK_AddressCounty]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[County] DROP CONSTRAINT [FK_AddressCounty];
GO
IF OBJECT_ID(N'[dbo].[FK_AddressUserInfo]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[UserInfo] DROP CONSTRAINT [FK_AddressUserInfo];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[UserInfo]', 'U') IS NOT NULL
    DROP TABLE [dbo].[UserInfo];
GO
IF OBJECT_ID(N'[dbo].[Province]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Province];
GO
IF OBJECT_ID(N'[dbo].[City]', 'U') IS NOT NULL
    DROP TABLE [dbo].[City];
GO
IF OBJECT_ID(N'[dbo].[County]', 'U') IS NOT NULL
    DROP TABLE [dbo].[County];
GO
IF OBJECT_ID(N'[dbo].[Address]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Address];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'UserInfo'
CREATE TABLE [dbo].[UserInfo] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [UName] nvarchar(32)  NOT NULL,
    [UPwd] nvarchar(32)  NOT NULL,
    [UGender] bit  NOT NULL,
    [UBirthday] datetime  NULL,
    [UPhone] nvarchar(max)  NULL,
    [UCategory] tinyint  NOT NULL,
    [AddressId] int  NOT NULL
);
GO

-- Creating table 'Province'
CREATE TABLE [dbo].[Province] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [PName] nvarchar(max)  NOT NULL,
    [AddressId] int  NOT NULL
);
GO

-- Creating table 'City'
CREATE TABLE [dbo].[City] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [CityName] nvarchar(max)  NOT NULL,
    [ProvinceId] int  NOT NULL,
    [AddressId] int  NOT NULL
);
GO

-- Creating table 'County'
CREATE TABLE [dbo].[County] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [CountyName] nvarchar(max)  NOT NULL,
    [CityId] int  NOT NULL,
    [AddressId] int  NOT NULL
);
GO

-- Creating table 'Address'
CREATE TABLE [dbo].[Address] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [UserInfoId] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'UserInfo'
ALTER TABLE [dbo].[UserInfo]
ADD CONSTRAINT [PK_UserInfo]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Province'
ALTER TABLE [dbo].[Province]
ADD CONSTRAINT [PK_Province]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'City'
ALTER TABLE [dbo].[City]
ADD CONSTRAINT [PK_City]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'County'
ALTER TABLE [dbo].[County]
ADD CONSTRAINT [PK_County]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Address'
ALTER TABLE [dbo].[Address]
ADD CONSTRAINT [PK_Address]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [ProvinceId] in table 'City'
ALTER TABLE [dbo].[City]
ADD CONSTRAINT [FK_ProvinceCity]
    FOREIGN KEY ([ProvinceId])
    REFERENCES [dbo].[Province]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ProvinceCity'
CREATE INDEX [IX_FK_ProvinceCity]
ON [dbo].[City]
    ([ProvinceId]);
GO

-- Creating foreign key on [CityId] in table 'County'
ALTER TABLE [dbo].[County]
ADD CONSTRAINT [FK_CityCounty]
    FOREIGN KEY ([CityId])
    REFERENCES [dbo].[City]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_CityCounty'
CREATE INDEX [IX_FK_CityCounty]
ON [dbo].[County]
    ([CityId]);
GO

-- Creating foreign key on [AddressId] in table 'Province'
ALTER TABLE [dbo].[Province]
ADD CONSTRAINT [FK_AddressProvince]
    FOREIGN KEY ([AddressId])
    REFERENCES [dbo].[Address]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_AddressProvince'
CREATE INDEX [IX_FK_AddressProvince]
ON [dbo].[Province]
    ([AddressId]);
GO

-- Creating foreign key on [AddressId] in table 'City'
ALTER TABLE [dbo].[City]
ADD CONSTRAINT [FK_AddressCity]
    FOREIGN KEY ([AddressId])
    REFERENCES [dbo].[Address]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_AddressCity'
CREATE INDEX [IX_FK_AddressCity]
ON [dbo].[City]
    ([AddressId]);
GO

-- Creating foreign key on [AddressId] in table 'County'
ALTER TABLE [dbo].[County]
ADD CONSTRAINT [FK_AddressCounty]
    FOREIGN KEY ([AddressId])
    REFERENCES [dbo].[Address]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_AddressCounty'
CREATE INDEX [IX_FK_AddressCounty]
ON [dbo].[County]
    ([AddressId]);
GO

-- Creating foreign key on [AddressId] in table 'UserInfo'
ALTER TABLE [dbo].[UserInfo]
ADD CONSTRAINT [FK_AddressUserInfo]
    FOREIGN KEY ([AddressId])
    REFERENCES [dbo].[Address]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_AddressUserInfo'
CREATE INDEX [IX_FK_AddressUserInfo]
ON [dbo].[UserInfo]
    ([AddressId]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------