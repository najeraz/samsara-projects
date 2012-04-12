USE [SamsaraProjects]
GO

/****** Object:  Table [TIConsulting].[ServerConsultingComputerBrands]    Script Date: 04/11/2012 19:00:22 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [TIConsulting].[ServerConsultingComputerBrands](
	[ServerConsultingComputerBrandId] [int] IDENTITY(1,1) NOT NULL,
	[ServerConsultingId] [int] NULL,
	[ComputerBrandId] [int] NULL,
	[Activated] [bit] NOT NULL,
	[Deleted] [bit] NOT NULL,
	[CreatedOn] [datetime] NULL,
	[CreatedBy] [int] NULL,
	[UpdatedOn] [datetime] NULL,
	[UpdatedBy] [int] NULL,
 CONSTRAINT [PK_ServerConsultingComputerBrands] PRIMARY KEY CLUSTERED 
(
	[ServerConsultingComputerBrandId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [TIConsulting].[ServerConsultingComputerBrands]  WITH CHECK ADD  CONSTRAINT [FK_ServerConsultingComputerBrands_ComputerBrands] FOREIGN KEY([ComputerBrandId])
REFERENCES [CustomerContext].[ComputerBrands] ([ComputerBrandId])
GO

ALTER TABLE [TIConsulting].[ServerConsultingComputerBrands] CHECK CONSTRAINT [FK_ServerConsultingComputerBrands_ComputerBrands]
GO

ALTER TABLE [TIConsulting].[ServerConsultingComputerBrands]  WITH CHECK ADD  CONSTRAINT [FK_ServerConsultingComputerBrands_ServerConsulting] FOREIGN KEY([ServerConsultingId])
REFERENCES [TIConsulting].[ServerConsulting] ([ServerConsultingId])
GO

ALTER TABLE [TIConsulting].[ServerConsultingComputerBrands] CHECK CONSTRAINT [FK_ServerConsultingComputerBrands_ServerConsulting]
GO


