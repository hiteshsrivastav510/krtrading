use krtradingNew
go

CREATE TABLE [dbo].[mail_template](
	[Mail_Id] [int] IDENTITY(1,1) NOT NULL,
	[Mail_Sub] [nvarchar](max) NOT NULL,
	[Mail_Action] [nvarchar](500) NOT NULL,
	[Mail_Body] [nvarchar](max) NOT NULL,
	[Mail_To] [nvarchar](500) NULL,
	[Mail_CC] [nvarchar](500) NULL,
	[Mail_Lang] [nvarchar](500) NULL,
PRIMARY KEY CLUSTERED 
(
	[Mail_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO


