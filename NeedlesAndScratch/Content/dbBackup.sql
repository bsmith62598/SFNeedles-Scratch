/*    ==Scripting Parameters==

    Source Server Version : SQL Server 2016 (13.0.5026)
    Source Database Engine Edition : Microsoft SQL Server Express Edition
    Source Database Engine Type : Standalone SQL Server

    Target Server Version : SQL Server 2017
    Target Database Engine Edition : Microsoft SQL Server Standard Edition
    Target Database Engine Type : Standalone SQL Server
*/
USE [NeedlesAndScratch]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[UserDetails]') AND type in (N'U'))
ALTER TABLE [dbo].[UserDetails] DROP CONSTRAINT IF EXISTS [FK_UserDetails_Genre]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[UserDetails]') AND type in (N'U'))
ALTER TABLE [dbo].[UserDetails] DROP CONSTRAINT IF EXISTS [FK_UserDetails_Band]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Record]') AND type in (N'U'))
ALTER TABLE [dbo].[Record] DROP CONSTRAINT IF EXISTS [FK_Record_Studio]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Record]') AND type in (N'U'))
ALTER TABLE [dbo].[Record] DROP CONSTRAINT IF EXISTS [FK_Record_StockStatus]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Record]') AND type in (N'U'))
ALTER TABLE [dbo].[Record] DROP CONSTRAINT IF EXISTS [FK_Record_Genre]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Record]') AND type in (N'U'))
ALTER TABLE [dbo].[Record] DROP CONSTRAINT IF EXISTS [FK_Record_Band]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[EmpToDept]') AND type in (N'U'))
ALTER TABLE [dbo].[EmpToDept] DROP CONSTRAINT IF EXISTS [FK_EmpToDept_Employee]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[EmpToDept]') AND type in (N'U'))
ALTER TABLE [dbo].[EmpToDept] DROP CONSTRAINT IF EXISTS [FK_EmpToDept_Department]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Employee]') AND type in (N'U'))
ALTER TABLE [dbo].[Employee] DROP CONSTRAINT IF EXISTS [FK_Employee_Employee]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[BandToArtist]') AND type in (N'U'))
ALTER TABLE [dbo].[BandToArtist] DROP CONSTRAINT IF EXISTS [FK_BandToArtist_Band]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[BandToArtist]') AND type in (N'U'))
ALTER TABLE [dbo].[BandToArtist] DROP CONSTRAINT IF EXISTS [FK_BandToArtist_Artist]
GO
/****** Object:  Table [dbo].[UserDetails]    Script Date: 6/24/2021 11:57:46 AM ******/
DROP TABLE IF EXISTS [dbo].[UserDetails]
GO
/****** Object:  Table [dbo].[Studio]    Script Date: 6/24/2021 11:57:46 AM ******/
DROP TABLE IF EXISTS [dbo].[Studio]
GO
/****** Object:  Table [dbo].[StockStatus]    Script Date: 6/24/2021 11:57:46 AM ******/
DROP TABLE IF EXISTS [dbo].[StockStatus]
GO
/****** Object:  Table [dbo].[Record]    Script Date: 6/24/2021 11:57:46 AM ******/
DROP TABLE IF EXISTS [dbo].[Record]
GO
/****** Object:  Table [dbo].[Genre]    Script Date: 6/24/2021 11:57:46 AM ******/
DROP TABLE IF EXISTS [dbo].[Genre]
GO
/****** Object:  Table [dbo].[EmpToDept]    Script Date: 6/24/2021 11:57:46 AM ******/
DROP TABLE IF EXISTS [dbo].[EmpToDept]
GO
/****** Object:  Table [dbo].[Employee]    Script Date: 6/24/2021 11:57:46 AM ******/
DROP TABLE IF EXISTS [dbo].[Employee]
GO
/****** Object:  Table [dbo].[Department]    Script Date: 6/24/2021 11:57:46 AM ******/
DROP TABLE IF EXISTS [dbo].[Department]
GO
/****** Object:  Table [dbo].[BandToArtist]    Script Date: 6/24/2021 11:57:46 AM ******/
DROP TABLE IF EXISTS [dbo].[BandToArtist]
GO
/****** Object:  Table [dbo].[Band]    Script Date: 6/24/2021 11:57:46 AM ******/
DROP TABLE IF EXISTS [dbo].[Band]
GO
/****** Object:  Table [dbo].[Band]    Script Date: 6/24/2021 11:57:46 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Band]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Band](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[BandName] [nvarchar](50) NOT NULL,
	[Founded] [date] NULL,
	[IsActive] [bit] NOT NULL,
	[ArtistID] [int] NOT NULL,
 CONSTRAINT [PK_Band] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[BandToArtist]    Script Date: 6/24/2021 11:57:46 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[BandToArtist]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[BandToArtist](
	[BandID] [int] NOT NULL,
	[ArtistID] [int] NOT NULL
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[Department]    Script Date: 6/24/2021 11:57:46 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Department]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Department](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[DeptName] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Department] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[Employee]    Script Date: 6/24/2021 11:57:46 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Employee]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Employee](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](50) NOT NULL,
	[LastName] [nvarchar](50) NOT NULL,
	[DateOfBirth] [date] NOT NULL,
	[HireDate] [date] NOT NULL,
	[ReportsTo] [int] NOT NULL,
	[DeptID] [int] NOT NULL,
 CONSTRAINT [PK_Employee] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[EmpToDept]    Script Date: 6/24/2021 11:57:46 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[EmpToDept]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[EmpToDept](
	[DeptID] [int] NOT NULL,
	[EmpID] [int] NOT NULL
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[Genre]    Script Date: 6/24/2021 11:57:46 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Genre]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Genre](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[GenreName] [nchar](10) NOT NULL,
 CONSTRAINT [PK_Genre] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[Record]    Script Date: 6/24/2021 11:57:46 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Record]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Record](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[RecordName] [nvarchar](40) NOT NULL,
	[Tracks] [int] NOT NULL,
	[Length] [int] NOT NULL,
	[YearRecorded] [date] NULL,
	[RecordCover] [varchar](100) NULL,
	[StockStatus] [int] NOT NULL,
	[GenreID] [int] NOT NULL,
	[BandID] [int] NOT NULL,
	[StudioID] [int] NOT NULL,
 CONSTRAINT [PK_Record] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[StockStatus]    Script Date: 6/24/2021 11:57:46 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[StockStatus]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[StockStatus](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Status] [nchar](10) NOT NULL,
 CONSTRAINT [PK_StockStatus] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[Studio]    Script Date: 6/24/2021 11:57:46 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Studio]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Studio](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[StudioName] [nvarchar](50) NOT NULL,
	[StudioState] [char](2) NULL,
	[StudioCity] [nvarchar](50) NULL,
	[StudioCountry] [varchar](50) NOT NULL,
	[YearFounded] [date] NOT NULL,
 CONSTRAINT [PK_Studio] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[UserDetails]    Script Date: 6/24/2021 11:57:46 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[UserDetails]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[UserDetails](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [varchar](50) NOT NULL,
	[LastName] [varchar](50) NULL,
	[Email] [varchar](50) NULL,
	[FavGenre] [int] NULL,
	[FavBand] [int] NULL,
 CONSTRAINT [PK_UserDetails] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET IDENTITY_INSERT [dbo].[Band] ON 

INSERT [dbo].[Band] ([ID], [BandName], [Founded], [IsActive], [ArtistID]) VALUES (2, N'311', CAST(N'1989-01-01' AS Date), 1, 0)
SET IDENTITY_INSERT [dbo].[Band] OFF
SET IDENTITY_INSERT [dbo].[Genre] ON 

INSERT [dbo].[Genre] ([ID], [GenreName]) VALUES (1, N'Rock      ')
INSERT [dbo].[Genre] ([ID], [GenreName]) VALUES (2, N'Alt       ')
INSERT [dbo].[Genre] ([ID], [GenreName]) VALUES (3, N'Pop       ')
INSERT [dbo].[Genre] ([ID], [GenreName]) VALUES (4, N'Classic   ')
SET IDENTITY_INSERT [dbo].[Genre] OFF
SET IDENTITY_INSERT [dbo].[Record] ON 

INSERT [dbo].[Record] ([ID], [RecordName], [Tracks], [Length], [YearRecorded], [RecordCover], [StockStatus], [GenreID], [BandID], [StudioID]) VALUES (1, N'Grassroots', 13, 150, CAST(N'1994-01-01' AS Date), NULL, 1, 2, 2, 1)
SET IDENTITY_INSERT [dbo].[Record] OFF
SET IDENTITY_INSERT [dbo].[StockStatus] ON 

INSERT [dbo].[StockStatus] ([ID], [Status]) VALUES (1, N'InStock   ')
INSERT [dbo].[StockStatus] ([ID], [Status]) VALUES (2, N'OutOfStock')
INSERT [dbo].[StockStatus] ([ID], [Status]) VALUES (3, N'BackOrder ')
INSERT [dbo].[StockStatus] ([ID], [Status]) VALUES (5, N'Disc      ')
SET IDENTITY_INSERT [dbo].[StockStatus] OFF
SET IDENTITY_INSERT [dbo].[Studio] ON 

INSERT [dbo].[Studio] ([ID], [StudioName], [StudioState], [StudioCity], [StudioCountry], [YearFounded]) VALUES (1, N'Capricorn Records', N'IL', N'City', N'USA', CAST(N'1986-01-01' AS Date))
SET IDENTITY_INSERT [dbo].[Studio] OFF
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_BandToArtist_Artist]') AND parent_object_id = OBJECT_ID(N'[dbo].[BandToArtist]'))
ALTER TABLE [dbo].[BandToArtist]  WITH CHECK ADD  CONSTRAINT [FK_BandToArtist_Artist] FOREIGN KEY([ArtistID])
REFERENCES [dbo].[Artist] ([ID])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_BandToArtist_Artist]') AND parent_object_id = OBJECT_ID(N'[dbo].[BandToArtist]'))
ALTER TABLE [dbo].[BandToArtist] CHECK CONSTRAINT [FK_BandToArtist_Artist]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_BandToArtist_Band]') AND parent_object_id = OBJECT_ID(N'[dbo].[BandToArtist]'))
ALTER TABLE [dbo].[BandToArtist]  WITH CHECK ADD  CONSTRAINT [FK_BandToArtist_Band] FOREIGN KEY([BandID])
REFERENCES [dbo].[Band] ([ID])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_BandToArtist_Band]') AND parent_object_id = OBJECT_ID(N'[dbo].[BandToArtist]'))
ALTER TABLE [dbo].[BandToArtist] CHECK CONSTRAINT [FK_BandToArtist_Band]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Employee_Employee]') AND parent_object_id = OBJECT_ID(N'[dbo].[Employee]'))
ALTER TABLE [dbo].[Employee]  WITH CHECK ADD  CONSTRAINT [FK_Employee_Employee] FOREIGN KEY([ReportsTo])
REFERENCES [dbo].[Employee] ([ID])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Employee_Employee]') AND parent_object_id = OBJECT_ID(N'[dbo].[Employee]'))
ALTER TABLE [dbo].[Employee] CHECK CONSTRAINT [FK_Employee_Employee]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_EmpToDept_Department]') AND parent_object_id = OBJECT_ID(N'[dbo].[EmpToDept]'))
ALTER TABLE [dbo].[EmpToDept]  WITH CHECK ADD  CONSTRAINT [FK_EmpToDept_Department] FOREIGN KEY([DeptID])
REFERENCES [dbo].[Department] ([ID])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_EmpToDept_Department]') AND parent_object_id = OBJECT_ID(N'[dbo].[EmpToDept]'))
ALTER TABLE [dbo].[EmpToDept] CHECK CONSTRAINT [FK_EmpToDept_Department]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_EmpToDept_Employee]') AND parent_object_id = OBJECT_ID(N'[dbo].[EmpToDept]'))
ALTER TABLE [dbo].[EmpToDept]  WITH CHECK ADD  CONSTRAINT [FK_EmpToDept_Employee] FOREIGN KEY([EmpID])
REFERENCES [dbo].[Employee] ([ID])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_EmpToDept_Employee]') AND parent_object_id = OBJECT_ID(N'[dbo].[EmpToDept]'))
ALTER TABLE [dbo].[EmpToDept] CHECK CONSTRAINT [FK_EmpToDept_Employee]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Record_Band]') AND parent_object_id = OBJECT_ID(N'[dbo].[Record]'))
ALTER TABLE [dbo].[Record]  WITH CHECK ADD  CONSTRAINT [FK_Record_Band] FOREIGN KEY([BandID])
REFERENCES [dbo].[Band] ([ID])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Record_Band]') AND parent_object_id = OBJECT_ID(N'[dbo].[Record]'))
ALTER TABLE [dbo].[Record] CHECK CONSTRAINT [FK_Record_Band]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Record_Genre]') AND parent_object_id = OBJECT_ID(N'[dbo].[Record]'))
ALTER TABLE [dbo].[Record]  WITH CHECK ADD  CONSTRAINT [FK_Record_Genre] FOREIGN KEY([GenreID])
REFERENCES [dbo].[Genre] ([ID])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Record_Genre]') AND parent_object_id = OBJECT_ID(N'[dbo].[Record]'))
ALTER TABLE [dbo].[Record] CHECK CONSTRAINT [FK_Record_Genre]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Record_StockStatus]') AND parent_object_id = OBJECT_ID(N'[dbo].[Record]'))
ALTER TABLE [dbo].[Record]  WITH CHECK ADD  CONSTRAINT [FK_Record_StockStatus] FOREIGN KEY([StockStatus])
REFERENCES [dbo].[StockStatus] ([ID])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Record_StockStatus]') AND parent_object_id = OBJECT_ID(N'[dbo].[Record]'))
ALTER TABLE [dbo].[Record] CHECK CONSTRAINT [FK_Record_StockStatus]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Record_Studio]') AND parent_object_id = OBJECT_ID(N'[dbo].[Record]'))
ALTER TABLE [dbo].[Record]  WITH CHECK ADD  CONSTRAINT [FK_Record_Studio] FOREIGN KEY([StudioID])
REFERENCES [dbo].[Studio] ([ID])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Record_Studio]') AND parent_object_id = OBJECT_ID(N'[dbo].[Record]'))
ALTER TABLE [dbo].[Record] CHECK CONSTRAINT [FK_Record_Studio]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_UserDetails_Band]') AND parent_object_id = OBJECT_ID(N'[dbo].[UserDetails]'))
ALTER TABLE [dbo].[UserDetails]  WITH CHECK ADD  CONSTRAINT [FK_UserDetails_Band] FOREIGN KEY([FavBand])
REFERENCES [dbo].[Band] ([ID])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_UserDetails_Band]') AND parent_object_id = OBJECT_ID(N'[dbo].[UserDetails]'))
ALTER TABLE [dbo].[UserDetails] CHECK CONSTRAINT [FK_UserDetails_Band]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_UserDetails_Genre]') AND parent_object_id = OBJECT_ID(N'[dbo].[UserDetails]'))
ALTER TABLE [dbo].[UserDetails]  WITH CHECK ADD  CONSTRAINT [FK_UserDetails_Genre] FOREIGN KEY([FavGenre])
REFERENCES [dbo].[Genre] ([ID])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_UserDetails_Genre]') AND parent_object_id = OBJECT_ID(N'[dbo].[UserDetails]'))
ALTER TABLE [dbo].[UserDetails] CHECK CONSTRAINT [FK_UserDetails_Genre]
GO
