
CREATE TABLE About(
	[id] [int] IDENTITY(1,1) NOT NULL,
	[AboutUs] [nvarchar](max) NULL,
	[isdelete] [bit] NULL,
	[status] [bit] NULL,
	[Created_date] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

