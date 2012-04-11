USE [SamsaraProjects]
GO

/****** Object:  Table [Framework].[AbstractQuantities]    Script Date: 04/11/2012 16:37:35 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [Framework].[AbstractQuantities](
	[AbstractQuantityId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](255) NOT NULL,
	[Description] [varchar](max) NULL,
	[Activated] [bit] NOT NULL,
	[Deleted] [bit] NOT NULL,
	[CreatedOn] [datetime] NOT NULL,
	[CreatedBy] [int] NOT NULL,
	[UpdatedOn] [datetime] NULL,
	[UpdatedBy] [int] NULL,
 CONSTRAINT [PK_AbstractQuantities] PRIMARY KEY CLUSTERED 
(
	[AbstractQuantityId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO


INSERT INTO [Framework].[AbstractQuantities] (
[Name], [Description], [Activated], [Deleted], [CreatedOn], [CreatedBy], [UpdatedOn], [UpdatedBy])
VALUES(
'Ninguno', NULL, 1, 0, GETDATE(), 1, NULL, NULL)

INSERT INTO [Framework].[AbstractQuantities] (
[Name], [Description], [Activated], [Deleted], [CreatedOn], [CreatedBy], [UpdatedOn], [UpdatedBy])
VALUES(
'Uno', NULL, 1, 0, GETDATE(), 1, NULL, NULL)

INSERT INTO [Framework].[AbstractQuantities] (
[Name], [Description], [Activated], [Deleted], [CreatedOn], [CreatedBy], [UpdatedOn], [UpdatedBy])
VALUES(
'Varios', NULL, 1, 0, GETDATE(), 1, NULL, NULL)
