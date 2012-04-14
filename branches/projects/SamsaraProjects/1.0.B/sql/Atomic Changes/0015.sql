USE [SamsaraProjects]
GO

IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[CustomerContext].[FK_Customers_BusinessTypes]') AND parent_object_id = OBJECT_ID(N'[CustomerContext].[Customers]'))
ALTER TABLE [CustomerContext].[Customers] DROP CONSTRAINT [FK_Customers_BusinessTypes]
GO

USE [SamsaraProjects]
GO

/****** Object:  Table [CustomerContext].[Customers]    Script Date: 04/14/2012 09:55:55 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[CustomerContext].[Customers]') AND type in (N'U'))
DROP TABLE [CustomerContext].[Customers]
GO


