USE [EmployeeManagement]
GO
/****** Object:  Table [dbo].[Department]    Script Date: 10/02/2020 12:56:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Employee]    Script Date: 10/02/2020 12:56:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
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
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[InOutDetails]    Script Date: 10/02/2020 12:56:44 PM ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[LeaveDetails]    Script Date: 10/02/2020 12:56:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
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
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Salary]    Script Date: 10/02/2020 12:56:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[SalarySlip]    Script Date: 10/02/2020 12:56:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[User]    Script Date: 10/02/2020 12:56:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[Department] ON 

GO
INSERT [dbo].[Department] ([Id], [Name], [IsActive], [CreatedOn], [CreatedBy]) VALUES (1, N'Admin', 1, CAST(0x0000AB5C010FB315 AS DateTime), N'dmin')
GO
INSERT [dbo].[Department] ([Id], [Name], [IsActive], [CreatedOn], [CreatedBy]) VALUES (2, N'Admin', 1, CAST(0x0000AB5C01100BC2 AS DateTime), N'Admin')
GO
INSERT [dbo].[Department] ([Id], [Name], [IsActive], [CreatedOn], [CreatedBy]) VALUES (3, N'HR', 1, CAST(0x0000AB5C01101FD2 AS DateTime), N'Admin')
GO
SET IDENTITY_INSERT [dbo].[Department] OFF
GO
SET IDENTITY_INSERT [dbo].[Employee] ON 

GO
INSERT [dbo].[Employee] ([Id], [EmployeeId], [FirstName], [MiddleName], [LastName], [DepartmentId], [Job_Title], [ContactNumber], [Email], [Address], [DateOfBirth], [DateofJoining], [DateOfLeaving], [Gender], [CreatedOn], [CreatedBy]) VALUES (1, N'E0001', N'Ajay', N'Rahul', N'Mishra', 1, N'Senior HR', N'9892098920', N'am@emp.com', N'Mumbai', CAST(0x07240B00 AS Date), CAST(0xB7400B00 AS Date), NULL, N'M', CAST(0x0000AB5C01118E1D AS DateTime), N'HR')
GO
SET IDENTITY_INSERT [dbo].[Employee] OFF
GO
SET IDENTITY_INSERT [dbo].[User] ON 

GO
INSERT [dbo].[User] ([Id], [EmployeeId], [Username], [Password], [IsActive], [CreatedOn], [CreatedBy], [ModifiedOn], [ModifiedBy]) VALUES (1, 1, N'admin', N'admin', 1, CAST(0x0000AB5C011261EC AS DateTime), N'Test', NULL, NULL)
GO
SET IDENTITY_INSERT [dbo].[User] OFF
GO
ALTER TABLE [dbo].[Department] ADD  CONSTRAINT [DF_Department_CreatedOn]  DEFAULT (getdate()) FOR [CreatedOn]
GO
ALTER TABLE [dbo].[Employee] ADD  CONSTRAINT [DF_Employee_CreatedOn]  DEFAULT (getdate()) FOR [CreatedOn]
GO
ALTER TABLE [dbo].[LeaveDetails] ADD  CONSTRAINT [DF_Leave_Approved]  DEFAULT ((0)) FOR [Approved]
GO
ALTER TABLE [dbo].[LeaveDetails] ADD  CONSTRAINT [DF_Leave_CreatedOn]  DEFAULT (getdate()) FOR [CreatedOn]
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
