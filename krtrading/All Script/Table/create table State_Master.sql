
CREATE TABLE [dbo].[State_Master](
	[State_Id] [int] IDENTITY(1,1) NOT NULL,
	[Country_Id] [int] NULL,
	[State_Name] [nvarchar](max) NULL,
	[IsActive] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[State_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[State_Master] ON 
GO
INSERT [dbo].[State_Master] ([State_Id], [Country_Id], [State_Name], [IsActive]) VALUES (1, 78, N'Andhra Pradesh', 1)
GO
INSERT [dbo].[State_Master] ([State_Id], [Country_Id], [State_Name], [IsActive]) VALUES (2, 78, N'Arunachal Pradesh', 1)
GO
INSERT [dbo].[State_Master] ([State_Id], [Country_Id], [State_Name], [IsActive]) VALUES (3, 78, N'Assam', 1)
GO
INSERT [dbo].[State_Master] ([State_Id], [Country_Id], [State_Name], [IsActive]) VALUES (4, 78, N'Bihar', 1)
GO
INSERT [dbo].[State_Master] ([State_Id], [Country_Id], [State_Name], [IsActive]) VALUES (5, 78, N'Chhattisgarh', 1)
GO
INSERT [dbo].[State_Master] ([State_Id], [Country_Id], [State_Name], [IsActive]) VALUES (6, 78, N'Goa', 1)
GO
INSERT [dbo].[State_Master] ([State_Id], [Country_Id], [State_Name], [IsActive]) VALUES (7, 78, N'Gujarat', 1)
GO
INSERT [dbo].[State_Master] ([State_Id], [Country_Id], [State_Name], [IsActive]) VALUES (8, 78, N'Haryana', 1)
GO
INSERT [dbo].[State_Master] ([State_Id], [Country_Id], [State_Name], [IsActive]) VALUES (9, 78, N'Himachal Pradesh', 1)
GO
INSERT [dbo].[State_Master] ([State_Id], [Country_Id], [State_Name], [IsActive]) VALUES (10, 78, N'Jharkhand', 1)
GO
INSERT [dbo].[State_Master] ([State_Id], [Country_Id], [State_Name], [IsActive]) VALUES (11, 78, N'Karnataka', 1)
GO
INSERT [dbo].[State_Master] ([State_Id], [Country_Id], [State_Name], [IsActive]) VALUES (12, 78, N'Kerala', 1)
GO
INSERT [dbo].[State_Master] ([State_Id], [Country_Id], [State_Name], [IsActive]) VALUES (13, 78, N'Madhya Pradesh', 1)
GO
INSERT [dbo].[State_Master] ([State_Id], [Country_Id], [State_Name], [IsActive]) VALUES (14, 78, N'Maharashtra', 1)
GO
INSERT [dbo].[State_Master] ([State_Id], [Country_Id], [State_Name], [IsActive]) VALUES (15, 78, N'Manipur', 1)
GO
INSERT [dbo].[State_Master] ([State_Id], [Country_Id], [State_Name], [IsActive]) VALUES (16, 78, N'Meghalaya', 1)
GO
INSERT [dbo].[State_Master] ([State_Id], [Country_Id], [State_Name], [IsActive]) VALUES (17, 78, N'Mizoram', 1)
GO
INSERT [dbo].[State_Master] ([State_Id], [Country_Id], [State_Name], [IsActive]) VALUES (18, 78, N'Nagaland', 1)
GO
INSERT [dbo].[State_Master] ([State_Id], [Country_Id], [State_Name], [IsActive]) VALUES (19, 78, N'Odisha', 1)
GO
INSERT [dbo].[State_Master] ([State_Id], [Country_Id], [State_Name], [IsActive]) VALUES (20, 78, N'Punjab', 1)
GO
INSERT [dbo].[State_Master] ([State_Id], [Country_Id], [State_Name], [IsActive]) VALUES (21, 78, N'Rajasthan', 1)
GO
INSERT [dbo].[State_Master] ([State_Id], [Country_Id], [State_Name], [IsActive]) VALUES (22, 78, N'Sikkim', 1)
GO
INSERT [dbo].[State_Master] ([State_Id], [Country_Id], [State_Name], [IsActive]) VALUES (23, 78, N'Tamil Nadu', 1)
GO
INSERT [dbo].[State_Master] ([State_Id], [Country_Id], [State_Name], [IsActive]) VALUES (24, 78, N'Telangana', 1)
GO
INSERT [dbo].[State_Master] ([State_Id], [Country_Id], [State_Name], [IsActive]) VALUES (25, 78, N'Tripura', 1)
GO
INSERT [dbo].[State_Master] ([State_Id], [Country_Id], [State_Name], [IsActive]) VALUES (26, 78, N'Uttar Pradesh', 1)
GO
INSERT [dbo].[State_Master] ([State_Id], [Country_Id], [State_Name], [IsActive]) VALUES (27, 78, N'Uttarakhand', 1)
GO
INSERT [dbo].[State_Master] ([State_Id], [Country_Id], [State_Name], [IsActive]) VALUES (28, 78, N'West Bengal', 1)
GO
INSERT [dbo].[State_Master] ([State_Id], [Country_Id], [State_Name], [IsActive]) VALUES (29, 78, N'Andaman and Nicobar Islands', 1)
GO
INSERT [dbo].[State_Master] ([State_Id], [Country_Id], [State_Name], [IsActive]) VALUES (30, 78, N'Chandigarh', 1)
GO
INSERT [dbo].[State_Master] ([State_Id], [Country_Id], [State_Name], [IsActive]) VALUES (31, 78, N'Dadra & Nagar Haveli and Daman & Diu', 1)
GO
INSERT [dbo].[State_Master] ([State_Id], [Country_Id], [State_Name], [IsActive]) VALUES (32, 78, N'Delhi', 1)
GO
INSERT [dbo].[State_Master] ([State_Id], [Country_Id], [State_Name], [IsActive]) VALUES (33, 78, N'Jammu and Kashmir', 1)
GO
INSERT [dbo].[State_Master] ([State_Id], [Country_Id], [State_Name], [IsActive]) VALUES (34, 78, N'Lakshadweep', 1)
GO
INSERT [dbo].[State_Master] ([State_Id], [Country_Id], [State_Name], [IsActive]) VALUES (35, 78, N'Puducherry', 1)
GO
INSERT [dbo].[State_Master] ([State_Id], [Country_Id], [State_Name], [IsActive]) VALUES (36, 78, N'Ladakh', 1)
GO
SET IDENTITY_INSERT [dbo].[State_Master] OFF
GO
