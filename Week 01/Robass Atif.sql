USE [TestDB_2022_CS_150]
GO
/****** Object:  Table [dbo].[student]    Script Date: 23/01/2024 9:01:23 am ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[student](
	[ID] [nchar](10) NULL,
	[Name] [nchar](10) NULL,
	[Password] [nchar](10) NULL,
	[role] [nchar](10) NULL,
	[marks] [nchar](10) NULL,
	[result] [nchar](10) NULL
) ON [PRIMARY]
GO
INSERT [dbo].[student] ([ID], [Name], [Password], [role], [marks], [result]) VALUES (N'robasss   ', N'123       ', N'123       ', N'teacher   ', N'123       ', N'23        ')
INSERT [dbo].[student] ([ID], [Name], [Password], [role], [marks], [result]) VALUES (N'ali       ', N'123       ', N'213       ', N'1233      ', N'213       ', N'123       ')
INSERT [dbo].[student] ([ID], [Name], [Password], [role], [marks], [result]) VALUES (N'213       ', N'23        ', N'123       ', N'123       ', N'123       ', N'123       ')
INSERT [dbo].[student] ([ID], [Name], [Password], [role], [marks], [result]) VALUES (N'123       ', N'123       ', N'123       ', N'213123    ', N'123       ', N'123       ')
GO
