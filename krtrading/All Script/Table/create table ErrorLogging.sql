
CREATE TABLE [dbo].[ErrorLogging](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[ErrorDesc] [nvarchar](max) NOT NULL,
	[MoreInfo] [nvarchar](max) NULL,
	[generatedDate] [datetime] NOT NULL,
	[UserName] [nvarchar](max) NULL,
	[ActionResultName] [nvarchar](500) NULL,
	[ControllerName] [nvarchar](500) NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO


