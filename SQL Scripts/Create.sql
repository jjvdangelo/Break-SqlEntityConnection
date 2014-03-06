USE [BlowItUp]
GO

/****** Object:  Table [dbo].[Table_1]    Script Date: 3/5/2014 8:56:31 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Table_1](
	[id] [nvarchar](128) NOT NULL,
	[some_value] [int] NOT NULL,
 CONSTRAINT [PK_Table_1] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

CREATE TABLE [dbo].[Table_2](
	[id] [int] NOT NULL,
	[table_1_id] [nvarchar](128) NOT NULL,
	[value] [int] NOT NULL
) ON [PRIMARY]

GO