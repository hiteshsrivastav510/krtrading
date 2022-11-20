
CREATE TABLE [dbo].[EmailLogging](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[EmailFrom] [nvarchar](500) NOT NULL,
	[EmailTo] [nvarchar](max) NOT NULL,
	[EmailCC] [nvarchar](max) NULL,
	[EmailSubject] [nvarchar](2000) NOT NULL,
	[EmailBody] [nvarchar](max) NOT NULL,
	[ErrorGenerated] [nvarchar](max) NULL,
	[CreatedBy] [uniqueidentifier] NULL,
	[CreatedDate] [datetime] NOT NULL,
	[EmailStatus] [nvarchar](200) NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO


