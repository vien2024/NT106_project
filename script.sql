USE [Login]
GO
/****** Object:  Table [dbo].[Login_info]    Script Date: 4/13/2024 9:59:06 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Login_info](
	[firstname] [varchar](50) NULL,
	[lastname] [varchar](50) NULL,
	[password] [varchar](50) NULL,
	[confirmpass] [varchar](50) NULL,
	[email] [varchar](50) NULL,
	[image] [image] NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
