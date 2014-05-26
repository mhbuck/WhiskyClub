USE [WhiskyClub]
GO
/****** Object:  Table [dbo].[Host]    Script Date: 2014-05-26 01:43:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Host](
	[HostId] [int] NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[Version] [timestamp] NOT NULL,
	[InsertedDate] [datetime2](7) NOT NULL,
	[UpdatedDate] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_Host] PRIMARY KEY CLUSTERED 
(
	[HostId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING ON
GO
ALTER TABLE [dbo].[Host] ADD  CONSTRAINT [DF_Host_InsertedDate]  DEFAULT (getdate()) FOR [InsertedDate]
GO
ALTER TABLE [dbo].[Host] ADD  CONSTRAINT [DF_Host_UpdatedDate]  DEFAULT (getdate()) FOR [UpdatedDate]
GO
