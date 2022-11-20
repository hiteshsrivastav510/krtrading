use krtradingNew
go
CREATE TABLE [dbo].[ChangePasswordEmailLinks](
	[LinkId] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [uniqueidentifier] NULL,
	[LinkRequestDate] [datetime] NULL,
	[OldPassword] [nvarchar](256) NULL,
	[status] [nvarchar](15) NULL,
	[changePasswordLink] [nvarchar](max) NULL,
	[linkExpireTime] [int] NULL,
	[modifiedDate] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[LinkId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO


