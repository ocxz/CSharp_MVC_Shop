
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 08/19/2019 11:45:39
-- Generated from EDMX file: F:\c#代码\c#进阶学习\5、Asp.Net学习\8、Mvc实现超市后台cnm\Sunny.ShopCNM\Sunny.ShopCNM.Model\DataModel.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [Sunny.ShopCNM];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------


-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------


-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'AdminInfo'
CREATE TABLE [dbo].[AdminInfo] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [AdminName] nvarchar(32)  NOT NULL,
    [AdminPwd] nvarchar(32)  NOT NULL
);
GO

-- Creating table 'UserInfo'
CREATE TABLE [dbo].[UserInfo] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [UName] nvarchar(32)  NOT NULL,
    [UPwd] nvarchar(32)  NOT NULL,
    [UGender] bit  NOT NULL,
    [UBirthday] datetime  NULL,
    [UPhone] nvarchar(max)  NULL,
    [UCategory] tinyint  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'AdminInfo'
ALTER TABLE [dbo].[AdminInfo]
ADD CONSTRAINT [PK_AdminInfo]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'UserInfo'
ALTER TABLE [dbo].[UserInfo]
ADD CONSTRAINT [PK_UserInfo]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------