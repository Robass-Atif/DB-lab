USE [LmsTestDb]
GO
/****** Object:  Table [dbo].[AspNetRoles]    Script Date: 27/03/2024 11:18:19 am ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetRoles](
	[Id] [nvarchar](128) NOT NULL,
	[Name] [nvarchar](256) NOT NULL,
 CONSTRAINT [PK_dbo.AspNetRoles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserRoles]    Script Date: 27/03/2024 11:18:19 am ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserRoles](
	[UserId] [nvarchar](128) NOT NULL,
	[RoleId] [nvarchar](128) NOT NULL,
 CONSTRAINT [PK_dbo.AspNetUserRoles] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUsers]    Script Date: 27/03/2024 11:18:19 am ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUsers](
	[Id] [nvarchar](128) NOT NULL,
	[Email] [nvarchar](256) NULL,
	[EmailConfirmed] [bit] NOT NULL,
	[PasswordHash] [nvarchar](max) NULL,
	[SecurityStamp] [nvarchar](max) NULL,
	[PhoneNumber] [nvarchar](max) NULL,
	[PhoneNumberConfirmed] [bit] NOT NULL,
	[TwoFactorEnabled] [bit] NOT NULL,
	[LockoutEndDateUtc] [datetime] NULL,
	[LockoutEnabled] [bit] NOT NULL,
	[AccessFailedCount] [int] NOT NULL,
	[UserName] [nvarchar](256) NOT NULL,
 CONSTRAINT [PK_dbo.AspNetUsers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Instructor]    Script Date: 27/03/2024 11:18:19 am ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Instructor](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[UserId] [nvarchar](128) NOT NULL,
 CONSTRAINT [PK_Instructor] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SpikoAnnouncement]    Script Date: 27/03/2024 11:18:19 am ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SpikoAnnouncement](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Description] [nvarchar](max) NOT NULL,
	[TimeStamp] [datetime] NOT NULL,
	[CourseId] [int] NOT NULL,
	[Title] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_SpikoAnnouncement] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SpikoAssignment]    Script Date: 27/03/2024 11:18:19 am ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SpikoAssignment](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[AssignmentTitle] [nvarchar](50) NOT NULL,
	[AssignmentDescription] [nvarchar](max) NULL,
	[Week] [int] NOT NULL,
	[SectionId] [int] NOT NULL,
	[CreatedBy] [int] NOT NULL,
	[CreatedOn] [datetime] NOT NULL,
	[AttachmentName] [nvarchar](50) NULL,
	[AttachmentLink] [nvarchar](450) NULL,
	[OpenDate] [datetime] NULL,
	[DeadLine] [datetime] NULL,
	[CheckFiles] [bit] NOT NULL,
	[OnlineSubmission] [bit] NOT NULL,
	[IsDeleted] [bit] NOT NULL,
 CONSTRAINT [PK_SpikoAssignment] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SpikoAssignmentSubmission]    Script Date: 27/03/2024 11:18:19 am ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SpikoAssignmentSubmission](
	[StudentId] [int] NOT NULL,
	[AssignmentId] [int] NOT NULL,
	[SubmittedOn] [datetime] NOT NULL,
	[FileName] [nvarchar](400) NOT NULL,
 CONSTRAINT [PK_SpikoAssignmentSubmission] PRIMARY KEY CLUSTERED 
(
	[StudentId] ASC,
	[AssignmentId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SpikoCourse]    Script Date: 27/03/2024 11:18:19 am ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SpikoCourse](
	[CourseId] [int] IDENTITY(1,1) NOT NULL,
	[CourseCode] [nvarchar](10) NOT NULL,
	[CourseTitle] [nvarchar](50) NOT NULL,
	[CreditHrs] [int] NOT NULL,
	[ContactHrs] [int] NOT NULL,
	[CourseDescription] [nvarchar](max) NOT NULL,
	[DateCreated] [datetime] NOT NULL,
	[IsActive] [bit] NOT NULL,
	[CreatedBy] [int] NOT NULL,
	[Session] [nvarchar](10) NOT NULL,
	[Year] [nvarchar](10) NOT NULL,
	[ThumbailPath] [nvarchar](200) NULL,
	[IsDeleted] [bit] NOT NULL,
 CONSTRAINT [PK_SpikoCourse] PRIMARY KEY CLUSTERED 
(
	[CourseId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SpikoEvaluation]    Script Date: 27/03/2024 11:18:19 am ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SpikoEvaluation](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Category] [nvarchar](50) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[TotalMarks] [numeric](18, 2) NOT NULL,
	[TotalWeightage] [numeric](18, 2) NULL,
	[CloId] [int] NULL,
	[CourseId] [int] NOT NULL,
 CONSTRAINT [PK_SpikoEvaluation] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SpikoSection]    Script Date: 27/03/2024 11:18:19 am ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SpikoSection](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[DateCreated] [datetime] NOT NULL,
	[CourseId] [int] NOT NULL,
	[CreatedBy] [int] NOT NULL,
	[IsDeleted] [bit] NOT NULL,
 CONSTRAINT [PK_SpikoSection] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SpikoStudent]    Script Date: 27/03/2024 11:18:19 am ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SpikoStudent](
	[StudentId] [int] IDENTITY(1,1) NOT NULL,
	[RegistrationNumber] [nvarchar](50) NOT NULL,
	[UserId] [nvarchar](128) NOT NULL,
	[FullName] [nvarchar](50) NULL,
 CONSTRAINT [PK_SpikoStudent] PRIMARY KEY CLUSTERED 
(
	[StudentId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SpikoStudentEvaluation]    Script Date: 27/03/2024 11:18:19 am ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SpikoStudentEvaluation](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[EvaluationId] [int] NOT NULL,
	[StudentId] [int] NOT NULL,
	[ObtainedMarks] [numeric](18, 2) NOT NULL,
	[Remarks] [nvarchar](100) NULL,
 CONSTRAINT [PK_SpikoStudentEvaluation] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SpikoStudentSection]    Script Date: 27/03/2024 11:18:19 am ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SpikoStudentSection](
	[StudentId] [int] NOT NULL,
	[SectionId] [int] NOT NULL,
	[EnrolledOn] [datetime] NOT NULL,
	[IsAccepted] [bit] NOT NULL,
	[IsActive] [bit] NOT NULL,
	[EnrollmentId] [int] IDENTITY(1,1) NOT NULL,
 CONSTRAINT [PK_SpikoStudentSection] PRIMARY KEY CLUSTERED 
(
	[StudentId] ASC,
	[SectionId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[SpikoAssignment] ADD  CONSTRAINT [DF_SpikoAssignment_CheckFiles]  DEFAULT ((0)) FOR [CheckFiles]
GO
ALTER TABLE [dbo].[SpikoAssignment] ADD  CONSTRAINT [DF_SpikoAssignment_OnlineSubmission]  DEFAULT ((0)) FOR [OnlineSubmission]
GO
ALTER TABLE [dbo].[SpikoAssignment] ADD  CONSTRAINT [DF_SpikoAssignment_IsDeleted]  DEFAULT ((0)) FOR [IsDeleted]
GO
ALTER TABLE [dbo].[SpikoCourse] ADD  CONSTRAINT [DF_SpikoCourse_IsDeleted]  DEFAULT ((0)) FOR [IsDeleted]
GO
ALTER TABLE [dbo].[SpikoSection] ADD  CONSTRAINT [DF_SpikoSection_IsDeleted]  DEFAULT ((0)) FOR [IsDeleted]
GO
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AspNetUserRoles_dbo.AspNetRoles_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[AspNetRoles] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_dbo.AspNetUserRoles_dbo.AspNetRoles_RoleId]
GO
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AspNetUserRoles_dbo.AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_dbo.AspNetUserRoles_dbo.AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[Instructor]  WITH CHECK ADD  CONSTRAINT [FK_Instructor_AspNetUsers] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
GO
ALTER TABLE [dbo].[Instructor] CHECK CONSTRAINT [FK_Instructor_AspNetUsers]
GO
ALTER TABLE [dbo].[SpikoAnnouncement]  WITH CHECK ADD  CONSTRAINT [FK_SpikoAnnouncement_SpikoCourse] FOREIGN KEY([CourseId])
REFERENCES [dbo].[SpikoCourse] ([CourseId])
GO
ALTER TABLE [dbo].[SpikoAnnouncement] CHECK CONSTRAINT [FK_SpikoAnnouncement_SpikoCourse]
GO
ALTER TABLE [dbo].[SpikoAssignment]  WITH CHECK ADD  CONSTRAINT [FK_SpikoAssignment_Instructor] FOREIGN KEY([CreatedBy])
REFERENCES [dbo].[Instructor] ([Id])
GO
ALTER TABLE [dbo].[SpikoAssignment] CHECK CONSTRAINT [FK_SpikoAssignment_Instructor]
GO
ALTER TABLE [dbo].[SpikoAssignment]  WITH CHECK ADD  CONSTRAINT [FK_SpikoAssignment_SpikoSection] FOREIGN KEY([SectionId])
REFERENCES [dbo].[SpikoSection] ([Id])
GO
ALTER TABLE [dbo].[SpikoAssignment] CHECK CONSTRAINT [FK_SpikoAssignment_SpikoSection]
GO
ALTER TABLE [dbo].[SpikoAssignmentSubmission]  WITH CHECK ADD  CONSTRAINT [FK_SpikoAssignmentSubmission_SpikoAssignment] FOREIGN KEY([AssignmentId])
REFERENCES [dbo].[SpikoAssignment] ([Id])
GO
ALTER TABLE [dbo].[SpikoAssignmentSubmission] CHECK CONSTRAINT [FK_SpikoAssignmentSubmission_SpikoAssignment]
GO
ALTER TABLE [dbo].[SpikoAssignmentSubmission]  WITH CHECK ADD  CONSTRAINT [FK_SpikoAssignmentSubmission_SpikoStudent] FOREIGN KEY([StudentId])
REFERENCES [dbo].[SpikoStudent] ([StudentId])
GO
ALTER TABLE [dbo].[SpikoAssignmentSubmission] CHECK CONSTRAINT [FK_SpikoAssignmentSubmission_SpikoStudent]
GO
ALTER TABLE [dbo].[SpikoCourse]  WITH CHECK ADD  CONSTRAINT [FK_SpikoCourse_Instructor] FOREIGN KEY([CreatedBy])
REFERENCES [dbo].[Instructor] ([Id])
GO
ALTER TABLE [dbo].[SpikoCourse] CHECK CONSTRAINT [FK_SpikoCourse_Instructor]
GO
ALTER TABLE [dbo].[SpikoEvaluation]  WITH CHECK ADD  CONSTRAINT [FK_SpikoEvaluation_SpikoCourse] FOREIGN KEY([CourseId])
REFERENCES [dbo].[SpikoCourse] ([CourseId])
GO
ALTER TABLE [dbo].[SpikoEvaluation] CHECK CONSTRAINT [FK_SpikoEvaluation_SpikoCourse]
GO
ALTER TABLE [dbo].[SpikoSection]  WITH CHECK ADD  CONSTRAINT [FK_SpikoSection_Instructor] FOREIGN KEY([CreatedBy])
REFERENCES [dbo].[Instructor] ([Id])
GO
ALTER TABLE [dbo].[SpikoSection] CHECK CONSTRAINT [FK_SpikoSection_Instructor]
GO
ALTER TABLE [dbo].[SpikoSection]  WITH CHECK ADD  CONSTRAINT [FK_SpikoSection_SpikoCourse] FOREIGN KEY([CourseId])
REFERENCES [dbo].[SpikoCourse] ([CourseId])
GO
ALTER TABLE [dbo].[SpikoSection] CHECK CONSTRAINT [FK_SpikoSection_SpikoCourse]
GO
ALTER TABLE [dbo].[SpikoStudent]  WITH CHECK ADD  CONSTRAINT [FK_SpikoStudent_AspNetUsers] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
GO
ALTER TABLE [dbo].[SpikoStudent] CHECK CONSTRAINT [FK_SpikoStudent_AspNetUsers]
GO
ALTER TABLE [dbo].[SpikoStudentEvaluation]  WITH CHECK ADD  CONSTRAINT [FK_SpikoStudentEvaluation_SpikoEvaluation] FOREIGN KEY([EvaluationId])
REFERENCES [dbo].[SpikoEvaluation] ([Id])
GO
ALTER TABLE [dbo].[SpikoStudentEvaluation] CHECK CONSTRAINT [FK_SpikoStudentEvaluation_SpikoEvaluation]
GO
ALTER TABLE [dbo].[SpikoStudentEvaluation]  WITH CHECK ADD  CONSTRAINT [FK_SpikoStudentEvaluation_SpikoStudent] FOREIGN KEY([StudentId])
REFERENCES [dbo].[SpikoStudent] ([StudentId])
GO
ALTER TABLE [dbo].[SpikoStudentEvaluation] CHECK CONSTRAINT [FK_SpikoStudentEvaluation_SpikoStudent]
GO
ALTER TABLE [dbo].[SpikoStudentSection]  WITH CHECK ADD  CONSTRAINT [FK_SpikoStudentSection_SpikoSection] FOREIGN KEY([SectionId])
REFERENCES [dbo].[SpikoSection] ([Id])
GO
ALTER TABLE [dbo].[SpikoStudentSection] CHECK CONSTRAINT [FK_SpikoStudentSection_SpikoSection]
GO
ALTER TABLE [dbo].[SpikoStudentSection]  WITH CHECK ADD  CONSTRAINT [FK_SpikoStudentSection_SpikoStudent] FOREIGN KEY([StudentId])
REFERENCES [dbo].[SpikoStudent] ([StudentId])
GO
ALTER TABLE [dbo].[SpikoStudentSection] CHECK CONSTRAINT [FK_SpikoStudentSection_SpikoStudent]
GO
