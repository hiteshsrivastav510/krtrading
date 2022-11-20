
CREATE TABLE [dbo].[UserMembership](
	[UserId] [uniqueidentifier] NOT NULL,
	[Password] [nvarchar](256) NOT NULL,
	[Email] [nvarchar](512) NULL,
	[LoweredEmail] [nvarchar](512) NULL,
	[PasswordQuestion] [nvarchar](256) NULL,
	[PasswordAnswer] [nvarchar](256) NULL,
	[IsApproved] [bit] NOT NULL,
	[IsLockedOut] [bit] NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[LastLoginDate] [datetime] NOT NULL,
	[LastPasswordChangeDate] [datetime] NOT NULL,
	[LastLockedOutDate] [datetime] NOT NULL,
	[FailedPasswordAttemptCount] [int] NOT NULL,
	[FailedPasswordAttemptCountDate] [datetime] NOT NULL,
	[FailedPasswordAnswerCount] [int] NOT NULL,
	[FailedPasswordAnswerCountDate] [datetime] NOT NULL,
	[Comment] [nvarchar](256) NULL
) ON [PRIMARY]
GO


