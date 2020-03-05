USE [Regqa]
GO
/****** Object:  Table [dbo].[Department]    Script Date: 3/6/2020 4:42:12 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Department](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[IsActive] [bit] NOT NULL,
	[CreatedOn] [datetime] NOT NULL,
	[CreatedBy] [varchar](100) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 80) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Employee]    Script Date: 3/6/2020 4:42:12 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Employee](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[EmployeeId] [varchar](20) NOT NULL,
	[FirstName] [varchar](100) NOT NULL,
	[MiddleName] [varchar](100) NULL,
	[LastName] [varchar](100) NOT NULL,
	[DepartmentId] [int] NOT NULL,
	[Job_Title] [varchar](100) NOT NULL,
	[ContactNumber] [varchar](20) NOT NULL,
	[Email] [varchar](50) NOT NULL,
	[Address] [varchar](200) NOT NULL,
	[DateOfBirth] [date] NOT NULL,
	[DateofJoining] [date] NOT NULL,
	[DateOfLeaving] [date] NULL,
	[Gender] [varchar](1) NOT NULL,
	[CreatedOn] [datetime] NOT NULL,
	[CreatedBy] [varchar](100) NOT NULL,
	[IsActive] [bit] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 80) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[InOutDetails]    Script Date: 3/6/2020 4:42:12 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[InOutDetails](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[EmployeeId] [int] NOT NULL,
	[OfficeDate] [date] NOT NULL,
	[InTIme] [time](7) NULL,
	[OutTime] [time](7) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 80) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Key]    Script Date: 3/6/2020 4:42:12 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Key](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Sequence] [int] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LeaveDetails]    Script Date: 3/6/2020 4:42:12 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LeaveDetails](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[EmployeeId] [int] NOT NULL,
	[FromDate] [date] NOT NULL,
	[ToDate] [date] NOT NULL,
	[NoOfDate] [int] NOT NULL,
	[LeaveReason] [varchar](500) NULL,
	[Approved] [bit] NOT NULL,
	[CreatedOn] [datetime] NOT NULL,
	[CreatedBy] [varchar](50) NULL,
	[IsDeleted] [bit] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 80) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Salary]    Script Date: 3/6/2020 4:42:12 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Salary](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[EmployeeId] [int] NOT NULL,
	[BasicSalary] [decimal](18, 0) NOT NULL,
	[EPF] [decimal](18, 0) NOT NULL,
	[CashInHand] [decimal](18, 0) NOT NULL,
	[CreatedOn] [datetime] NOT NULL,
	[CreatedBy] [varchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 80) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SalarySlip]    Script Date: 3/6/2020 4:42:12 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SalarySlip](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[EmployeeId] [int] NOT NULL,
	[FinancialYear] [int] NOT NULL,
	[FinancialMonth] [int] NOT NULL,
	[BasicSalary] [decimal](18, 0) NOT NULL,
	[EPF] [decimal](18, 0) NOT NULL,
	[CashInHand] [decimal](18, 0) NOT NULL,
	[CreatedOn] [datetime] NOT NULL,
	[CreatedBy] [varchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 80) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[User]    Script Date: 3/6/2020 4:42:12 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[EmployeeId] [int] NOT NULL,
	[Username] [varchar](100) NOT NULL,
	[Password] [varchar](100) NOT NULL,
	[IsActive] [bit] NOT NULL,
	[CreatedOn] [datetime] NOT NULL,
	[CreatedBy] [varchar](100) NULL,
	[ModifiedOn] [datetime] NULL,
	[ModifiedBy] [varchar](100) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 80) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Department] ON 
GO
INSERT [dbo].[Department] ([Id], [Name], [IsActive], [CreatedOn], [CreatedBy]) VALUES (1, N'Admin1', 0, CAST(N'2020-02-09T16:29:13.670' AS DateTime), N'dmin')
GO
INSERT [dbo].[Department] ([Id], [Name], [IsActive], [CreatedOn], [CreatedBy]) VALUES (2, N'Admin2', 1, CAST(N'2020-02-09T16:30:29.340' AS DateTime), N'Admin')
GO
INSERT [dbo].[Department] ([Id], [Name], [IsActive], [CreatedOn], [CreatedBy]) VALUES (3, N'HR', 1, CAST(N'2020-02-09T16:30:46.460' AS DateTime), N'Admin')
GO
INSERT [dbo].[Department] ([Id], [Name], [IsActive], [CreatedOn], [CreatedBy]) VALUES (4, N'test', 1, CAST(N'2020-02-27T01:44:28.103' AS DateTime), N'Admin')
GO
INSERT [dbo].[Department] ([Id], [Name], [IsActive], [CreatedOn], [CreatedBy]) VALUES (5, N'Admin', 1, CAST(N'2020-02-27T01:56:07.543' AS DateTime), N'Admin')
GO
INSERT [dbo].[Department] ([Id], [Name], [IsActive], [CreatedOn], [CreatedBy]) VALUES (6, N'Admin3', 1, CAST(N'2020-02-29T12:04:59.243' AS DateTime), N'Admin')
GO
SET IDENTITY_INSERT [dbo].[Department] OFF
GO
SET IDENTITY_INSERT [dbo].[Employee] ON 
GO
INSERT [dbo].[Employee] ([Id], [EmployeeId], [FirstName], [MiddleName], [LastName], [DepartmentId], [Job_Title], [ContactNumber], [Email], [Address], [DateOfBirth], [DateofJoining], [DateOfLeaving], [Gender], [CreatedOn], [CreatedBy], [IsActive]) VALUES (1, N'E0001', N'Ajay', N'Rahul', N'Mishra', 3, N'Senior HR', N'9892098920', N'am@emp.com', N'Mumbai', CAST(N'1995-01-01' AS Date), CAST(N'2020-02-09' AS Date), NULL, N'M', CAST(N'2020-02-09T16:35:59.030' AS DateTime), N'HR', 0)
GO
INSERT [dbo].[Employee] ([Id], [EmployeeId], [FirstName], [MiddleName], [LastName], [DepartmentId], [Job_Title], [ContactNumber], [Email], [Address], [DateOfBirth], [DateofJoining], [DateOfLeaving], [Gender], [CreatedOn], [CreatedBy], [IsActive]) VALUES (4, N'E0002', N'Ajay', N'Rahul', N'Mishra', 1, N'Senior HR', N'9892098920', N'am@emp.com', N'Mumbai', CAST(N'2000-01-01' AS Date), CAST(N'2020-02-09' AS Date), NULL, N'M', CAST(N'2020-02-09T00:00:00.000' AS DateTime), N'HR', 1)
GO
INSERT [dbo].[Employee] ([Id], [EmployeeId], [FirstName], [MiddleName], [LastName], [DepartmentId], [Job_Title], [ContactNumber], [Email], [Address], [DateOfBirth], [DateofJoining], [DateOfLeaving], [Gender], [CreatedOn], [CreatedBy], [IsActive]) VALUES (5, N'E013', N'Farooque', N'I', N'Mansoori', 1, N'Developer', N'9892098920', N'fm@gmail.com', N'Rfndsjfndsfneje', CAST(N'1990-11-11' AS Date), CAST(N'2020-02-26' AS Date), NULL, N'M', CAST(N'2020-02-26T03:15:09.000' AS DateTime), N'Admin', 1)
GO
INSERT [dbo].[Employee] ([Id], [EmployeeId], [FirstName], [MiddleName], [LastName], [DepartmentId], [Job_Title], [ContactNumber], [Email], [Address], [DateOfBirth], [DateofJoining], [DateOfLeaving], [Gender], [CreatedOn], [CreatedBy], [IsActive]) VALUES (6, N'E014', N'aman', N'munti', N'mansoori', 4, N'Developer', N'9892098920', N'abc@gmai.com', N'W', CAST(N'1990-11-11' AS Date), CAST(N'2020-02-29' AS Date), NULL, N'M', CAST(N'2020-02-29T18:09:49.000' AS DateTime), N'admin', 1)
GO
INSERT [dbo].[Employee] ([Id], [EmployeeId], [FirstName], [MiddleName], [LastName], [DepartmentId], [Job_Title], [ContactNumber], [Email], [Address], [DateOfBirth], [DateofJoining], [DateOfLeaving], [Gender], [CreatedOn], [CreatedBy], [IsActive]) VALUES (7, N'E015', N'Farooque', N'isaque', N'khan', 1, N'sed', N'9892098920', N'test@gmail.com', N'dfdf', CAST(N'1990-11-14' AS Date), CAST(N'2020-02-29' AS Date), NULL, N'M', CAST(N'2020-02-29T18:16:41.000' AS DateTime), N'Admin', 1)
GO
SET IDENTITY_INSERT [dbo].[Employee] OFF
GO
SET IDENTITY_INSERT [dbo].[InOutDetails] ON 
GO
INSERT [dbo].[InOutDetails] ([Id], [EmployeeId], [OfficeDate], [InTIme], [OutTime]) VALUES (5, 4, CAST(N'2020-03-04' AS Date), CAST(N'09:33:00' AS Time), CAST(N'18:33:00' AS Time))
GO
INSERT [dbo].[InOutDetails] ([Id], [EmployeeId], [OfficeDate], [InTIme], [OutTime]) VALUES (6, 5, CAST(N'2020-03-04' AS Date), CAST(N'10:24:00' AS Time), CAST(N'19:24:00' AS Time))
GO
INSERT [dbo].[InOutDetails] ([Id], [EmployeeId], [OfficeDate], [InTIme], [OutTime]) VALUES (7, 6, CAST(N'2020-03-04' AS Date), CAST(N'09:15:00' AS Time), CAST(N'18:15:00' AS Time))
GO
INSERT [dbo].[InOutDetails] ([Id], [EmployeeId], [OfficeDate], [InTIme], [OutTime]) VALUES (8, 7, CAST(N'2020-03-04' AS Date), CAST(N'10:49:00' AS Time), CAST(N'19:49:00' AS Time))
GO
INSERT [dbo].[InOutDetails] ([Id], [EmployeeId], [OfficeDate], [InTIme], [OutTime]) VALUES (9, 4, CAST(N'2020-03-05' AS Date), CAST(N'09:27:00' AS Time), CAST(N'19:18:00' AS Time))
GO
INSERT [dbo].[InOutDetails] ([Id], [EmployeeId], [OfficeDate], [InTIme], [OutTime]) VALUES (10, 5, CAST(N'2020-03-05' AS Date), CAST(N'09:52:00' AS Time), CAST(N'19:43:00' AS Time))
GO
INSERT [dbo].[InOutDetails] ([Id], [EmployeeId], [OfficeDate], [InTIme], [OutTime]) VALUES (11, 6, CAST(N'2020-03-05' AS Date), CAST(N'09:34:00' AS Time), CAST(N'19:25:00' AS Time))
GO
INSERT [dbo].[InOutDetails] ([Id], [EmployeeId], [OfficeDate], [InTIme], [OutTime]) VALUES (12, 7, CAST(N'2020-03-05' AS Date), CAST(N'09:59:00' AS Time), CAST(N'19:50:00' AS Time))
GO
SET IDENTITY_INSERT [dbo].[InOutDetails] OFF
GO
SET IDENTITY_INSERT [dbo].[Key] ON 
GO
INSERT [dbo].[Key] ([Id], [Sequence]) VALUES (1, 15)
GO
SET IDENTITY_INSERT [dbo].[Key] OFF
GO
SET IDENTITY_INSERT [dbo].[LeaveDetails] ON 
GO
INSERT [dbo].[LeaveDetails] ([Id], [EmployeeId], [FromDate], [ToDate], [NoOfDate], [LeaveReason], [Approved], [CreatedOn], [CreatedBy], [IsDeleted]) VALUES (1, 4, CAST(N'2020-03-05' AS Date), CAST(N'2020-03-05' AS Date), 1, N'rtrt', 0, CAST(N'2020-03-05T12:07:35.883' AS DateTime), N'Admin', 1)
GO
INSERT [dbo].[LeaveDetails] ([Id], [EmployeeId], [FromDate], [ToDate], [NoOfDate], [LeaveReason], [Approved], [CreatedOn], [CreatedBy], [IsDeleted]) VALUES (2, 1, CAST(N'2020-03-04' AS Date), CAST(N'2020-03-04' AS Date), 1, N'dfdsf', 1, CAST(N'2020-03-05T12:54:39.457' AS DateTime), N'Admin', 1)
GO
INSERT [dbo].[LeaveDetails] ([Id], [EmployeeId], [FromDate], [ToDate], [NoOfDate], [LeaveReason], [Approved], [CreatedOn], [CreatedBy], [IsDeleted]) VALUES (3, 4, CAST(N'2020-03-03' AS Date), CAST(N'2020-03-06' AS Date), 4, N'dfdsfdfsfd', 1, CAST(N'2020-03-05T12:55:57.153' AS DateTime), N'Admin', 0)
GO
SET IDENTITY_INSERT [dbo].[LeaveDetails] OFF
GO
SET IDENTITY_INSERT [dbo].[Salary] ON 
GO
INSERT [dbo].[Salary] ([Id], [EmployeeId], [BasicSalary], [EPF], [CashInHand], [CreatedOn], [CreatedBy]) VALUES (1, 4, CAST(10000 AS Decimal(18, 0)), CAST(1200 AS Decimal(18, 0)), CAST(8800 AS Decimal(18, 0)), CAST(N'2020-03-05T13:44:58.687' AS DateTime), N'test')
GO
INSERT [dbo].[Salary] ([Id], [EmployeeId], [BasicSalary], [EPF], [CashInHand], [CreatedOn], [CreatedBy]) VALUES (2, 1, CAST(12000 AS Decimal(18, 0)), CAST(1440 AS Decimal(18, 0)), CAST(10560 AS Decimal(18, 0)), CAST(N'2020-03-05T15:54:37.733' AS DateTime), N'Admin')
GO
SET IDENTITY_INSERT [dbo].[Salary] OFF
GO
SET IDENTITY_INSERT [dbo].[SalarySlip] ON 
GO
INSERT [dbo].[SalarySlip] ([Id], [EmployeeId], [FinancialYear], [FinancialMonth], [BasicSalary], [EPF], [CashInHand], [CreatedOn], [CreatedBy]) VALUES (2, 4, 2020, 3, CAST(10000 AS Decimal(18, 0)), CAST(1200 AS Decimal(18, 0)), CAST(8800 AS Decimal(18, 0)), CAST(N'2020-03-05T14:29:54.787' AS DateTime), N'Admin')
GO
INSERT [dbo].[SalarySlip] ([Id], [EmployeeId], [FinancialYear], [FinancialMonth], [BasicSalary], [EPF], [CashInHand], [CreatedOn], [CreatedBy]) VALUES (4, 4, 2020, 1, CAST(10000 AS Decimal(18, 0)), CAST(1200 AS Decimal(18, 0)), CAST(8800 AS Decimal(18, 0)), CAST(N'2020-03-05T15:33:20.567' AS DateTime), N'Admin')
GO
SET IDENTITY_INSERT [dbo].[SalarySlip] OFF
GO
SET IDENTITY_INSERT [dbo].[User] ON 
GO
INSERT [dbo].[User] ([Id], [EmployeeId], [Username], [Password], [IsActive], [CreatedOn], [CreatedBy], [ModifiedOn], [ModifiedBy]) VALUES (1, 1, N'admin', N'admin@12345', 1, CAST(N'2020-02-09T16:38:59.773' AS DateTime), N'Test', CAST(N'2020-02-27T15:56:13.957' AS DateTime), NULL)
GO
SET IDENTITY_INSERT [dbo].[User] OFF
GO
ALTER TABLE [dbo].[Department] ADD  CONSTRAINT [DF_Department_CreatedOn]  DEFAULT (getdate()) FOR [CreatedOn]
GO
ALTER TABLE [dbo].[Employee] ADD  CONSTRAINT [DF_Employee_CreatedOn]  DEFAULT (getdate()) FOR [CreatedOn]
GO
ALTER TABLE [dbo].[Employee] ADD  CONSTRAINT [DF_Employee_IsActive]  DEFAULT ((0)) FOR [IsActive]
GO
ALTER TABLE [dbo].[LeaveDetails] ADD  CONSTRAINT [DF_Leave_Approved]  DEFAULT ((0)) FOR [Approved]
GO
ALTER TABLE [dbo].[LeaveDetails] ADD  CONSTRAINT [DF_Leave_CreatedOn]  DEFAULT (getdate()) FOR [CreatedOn]
GO
ALTER TABLE [dbo].[LeaveDetails] ADD  CONSTRAINT [leave_delete]  DEFAULT ((0)) FOR [IsDeleted]
GO
ALTER TABLE [dbo].[Salary] ADD  CONSTRAINT [DF_Salary_CreatedOn]  DEFAULT (getdate()) FOR [CreatedOn]
GO
ALTER TABLE [dbo].[SalarySlip] ADD  CONSTRAINT [DF_SalarySlip_CreatedOn]  DEFAULT (getdate()) FOR [CreatedOn]
GO
ALTER TABLE [dbo].[User] ADD  CONSTRAINT [DF_User_CreatedOn]  DEFAULT (getdate()) FOR [CreatedOn]
GO
ALTER TABLE [dbo].[Employee]  WITH CHECK ADD FOREIGN KEY([DepartmentId])
REFERENCES [dbo].[Department] ([Id])
GO
ALTER TABLE [dbo].[InOutDetails]  WITH CHECK ADD FOREIGN KEY([EmployeeId])
REFERENCES [dbo].[Employee] ([Id])
GO
ALTER TABLE [dbo].[LeaveDetails]  WITH CHECK ADD FOREIGN KEY([EmployeeId])
REFERENCES [dbo].[Employee] ([Id])
GO
ALTER TABLE [dbo].[Salary]  WITH CHECK ADD FOREIGN KEY([EmployeeId])
REFERENCES [dbo].[Employee] ([Id])
GO
ALTER TABLE [dbo].[SalarySlip]  WITH CHECK ADD FOREIGN KEY([EmployeeId])
REFERENCES [dbo].[Employee] ([Id])
GO
ALTER TABLE [dbo].[User]  WITH CHECK ADD FOREIGN KEY([EmployeeId])
REFERENCES [dbo].[Employee] ([Id])
GO
/****** Object:  StoredProcedure [dbo].[GetEmployeeId]    Script Date: 3/6/2020 4:42:12 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE proc [dbo].[GetEmployeeId]
AS
BEGIN
UPDATE [Key]
set [Sequence]= [Sequence]+1
where Id=1
 SELECT 'E' + RIGHT('000'+CAST([Sequence] AS VARCHAR(3)),3) as EmployeeId
 from [Key] where Id=1

 END
GO
