
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 08/21/2019 16:46:02
-- Generated from EDMX file: F:\c#代码\c#进阶学习\5、Asp.Net学习\8、Mvc实现超市后台cnm\Sunny.ShopCNM\Sunny.ShopCNM\Models\DataModel.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [Sunny.ShopCNM2];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_BillProvider]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Bill] DROP CONSTRAINT [FK_BillProvider];
GO
IF OBJECT_ID(N'[dbo].[FK_BillUserInfo]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Bill] DROP CONSTRAINT [FK_BillUserInfo];
GO
IF OBJECT_ID(N'[dbo].[FK_UserInfoAddress]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[UserInfo] DROP CONSTRAINT [FK_UserInfoAddress];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Address]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Address];
GO
IF OBJECT_ID(N'[dbo].[AdminInfo]', 'U') IS NOT NULL
    DROP TABLE [dbo].[AdminInfo];
GO
IF OBJECT_ID(N'[dbo].[Bill]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Bill];
GO
IF OBJECT_ID(N'[dbo].[Provider]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Provider];
GO
IF OBJECT_ID(N'[dbo].[UserInfo]', 'U') IS NOT NULL
    DROP TABLE [dbo].[UserInfo];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'UserInfo'
CREATE TABLE [dbo].[UserInfo] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [UName] nvarchar(32)  NOT NULL,
    [UPwd] nvarchar(32)  NOT NULL,
    [UGender] bit  NULL,
    [UBirthday] datetime  NULL,
    [UPhone] nchar(11)  NULL,
    [UCategory] int  NULL,
    [AddressDetial] nvarchar(max)  NULL,
    [DelFlag] bit  NULL,
    [AddressId] int  NOT NULL
);
GO

-- Creating table 'Address'
CREATE TABLE [dbo].[Address] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Aid] nvarchar(20)  NULL,
    [Pid] nvarchar(20)  NULL,
    [Name] nvarchar(20)  NULL,
    [Sname] nvarchar(20)  NULL,
    [Memame] nvarchar(30)  NULL
);
GO

-- Creating table 'AdminInfo'
CREATE TABLE [dbo].[AdminInfo] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [AdminName] nvarchar(32)  NOT NULL,
    [AdminPwd] nvarchar(32)  NOT NULL,
    [AdminPhone] nchar(11)  NOT NULL
);
GO

-- Creating table 'Provider'
CREATE TABLE [dbo].[Provider] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [PName] nvarchar(32)  NOT NULL,
    [LinkMan] nvarchar(32)  NOT NULL,
    [LinkPhone] nchar(11)  NOT NULL,
    [LinkAddress] nvarchar(max)  NULL,
    [Fax] nchar(11)  NULL,
    [Detial] nvarchar(max)  NULL,
    [CreateTime] datetime  NULL,
    [DelFlag] nvarchar(max)  NOT NULL,
    [AddressId] int  NOT NULL
);
GO

-- Creating table 'Bill'
CREATE TABLE [dbo].[Bill] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [BName] nvarchar(max)  NOT NULL,
    [ProductUnit] nvarchar(max)  NULL,
    [ProductCount] int  NULL,
    [TotalMoney] decimal(18,0)  NOT NULL,
    [IsPaid] bit  NOT NULL,
    [ProviderId] int  NOT NULL,
    [UserInfoId] int  NOT NULL,
    [DelFlag] bit  NOT NULL,
    [CreateTime] datetime  NULL
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

-- Creating primary key on [Id] in table 'Address'
ALTER TABLE [dbo].[Address]
ADD CONSTRAINT [PK_Address]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'AdminInfo'
ALTER TABLE [dbo].[AdminInfo]
ADD CONSTRAINT [PK_AdminInfo]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Provider'
ALTER TABLE [dbo].[Provider]
ADD CONSTRAINT [PK_Provider]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Bill'
ALTER TABLE [dbo].[Bill]
ADD CONSTRAINT [PK_Bill]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [ProviderId] in table 'Bill'
ALTER TABLE [dbo].[Bill]
ADD CONSTRAINT [FK_BillProvider]
    FOREIGN KEY ([ProviderId])
    REFERENCES [dbo].[Provider]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_BillProvider'
CREATE INDEX [IX_FK_BillProvider]
ON [dbo].[Bill]
    ([ProviderId]);
GO

-- Creating foreign key on [UserInfoId] in table 'Bill'
ALTER TABLE [dbo].[Bill]
ADD CONSTRAINT [FK_BillUserInfo]
    FOREIGN KEY ([UserInfoId])
    REFERENCES [dbo].[UserInfo]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_BillUserInfo'
CREATE INDEX [IX_FK_BillUserInfo]
ON [dbo].[Bill]
    ([UserInfoId]);
GO

-- Creating foreign key on [AddressId] in table 'UserInfo'
ALTER TABLE [dbo].[UserInfo]
ADD CONSTRAINT [FK_UserInfoAddress]
    FOREIGN KEY ([AddressId])
    REFERENCES [dbo].[Address]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_UserInfoAddress'
CREATE INDEX [IX_FK_UserInfoAddress]
ON [dbo].[UserInfo]
    ([AddressId]);
GO

-- Creating foreign key on [AddressId] in table 'Provider'
ALTER TABLE [dbo].[Provider]
ADD CONSTRAINT [FK_ProviderAddress]
    FOREIGN KEY ([AddressId])
    REFERENCES [dbo].[Address]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ProviderAddress'
CREATE INDEX [IX_FK_ProviderAddress]
ON [dbo].[Provider]
    ([AddressId]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------