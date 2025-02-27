USE [Lab2_Home]
GO
/****** Object:  Table [dbo].[Attendance]    Script Date: 28/01/2024 6:59:14 pm ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Attendance](
	[StudentRegNo] [nchar](10) NULL,
	[CourseName] [nchar](10) NULL,
	[TimeStamp] [datetime] NULL,
	[Status] [varchar](50) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Courses]    Script Date: 28/01/2024 6:59:14 pm ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Courses](
	[Name] [nchar](10) NULL,
	[Code] [nchar](10) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Enrollments]    Script Date: 28/01/2024 6:59:14 pm ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Enrollments](
	[StudentRegNo] [nchar](10) NULL,
	[CourseName] [nchar](10) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Student]    Script Date: 28/01/2024 6:59:14 pm ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Student](
	[RegistrationNumber] [nchar](10) NULL,
	[Name] [nchar](10) NULL,
	[Department] [nchar](10) NULL,
	[Session] [nchar](10) NULL,
	[Address] [nchar](10) NULL
) ON [PRIMARY]
GO
INSERT [dbo].[Attendance] ([StudentRegNo], [CourseName], [TimeStamp], [Status]) VALUES (N'1         ', N'ali       ', CAST(N'2024-01-28T18:52:28.273' AS DateTime), N'0')
INSERT [dbo].[Attendance] ([StudentRegNo], [CourseName], [TimeStamp], [Status]) VALUES (N'1         ', N'ali       ', CAST(N'2024-01-28T18:55:35.263' AS DateTime), N'1')
GO
INSERT [dbo].[Courses] ([Name], [Code]) VALUES (N'ali       ', N'asd       ')
INSERT [dbo].[Courses] ([Name], [Code]) VALUES (N'sd        ', N'asd       ')
GO
INSERT [dbo].[Enrollments] ([StudentRegNo], [CourseName]) VALUES (N'1         ', N'ali       ')
GO
INSERT [dbo].[Student] ([RegistrationNumber], [Name], [Department], [Session], [Address]) VALUES (N'1         ', N'1         ', N'1         ', N'1         ', N'1         ')
INSERT [dbo].[Student] ([RegistrationNumber], [Name], [Department], [Session], [Address]) VALUES (N'2         ', N'ai        ', N'2         ', N'2         ', N'2         ')
GO
