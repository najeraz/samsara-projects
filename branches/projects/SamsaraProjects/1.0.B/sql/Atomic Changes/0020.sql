USE [SamsaraProjects]
GO

/****** Object:  Table [TIConsulting].[ServerConsultingStatuses]    Script Date: 04/17/2012 19:26:18 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [TIConsulting].[ServerConsultingStatuses](
	[ServerConsultingStatusId] [int] NOT NULL,
	[Name] [varchar](255) NOT NULL,
	[Deleted] [bit] NOT NULL,
	[Activated] [bit] NOT NULL,
	[CreatedOn] [datetime] NULL,
	[CreatedBy] [int] NULL,
	[UpdatedOn] [datetime] NULL,
	[UpdatedBy] [int] NULL,
 CONSTRAINT [PK_ServerConsultingStatuses] PRIMARY KEY CLUSTERED 
(
	[ServerConsultingStatusId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [TIConsulting].[ServerConsultingStatuses] ADD  CONSTRAINT [DF_ServerConsultingStatuses_Deleted]  DEFAULT ((0)) FOR [Deleted]
GO

ALTER TABLE [TIConsulting].[ServerConsultingStatuses] ADD  CONSTRAINT [DF_ServerConsultingStatuses_Activated]  DEFAULT ((1)) FOR [Activated]
GO


