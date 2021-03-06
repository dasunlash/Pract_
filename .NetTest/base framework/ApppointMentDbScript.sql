USE [master]
GO
/****** Object:  Database [Appoinment_Db]    Script Date: 8/21/2020 9:53:47 PM ******/
CREATE DATABASE [Appoinment_Db]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Appoinment_Db', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\Appoinment_Db.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Appoinment_Db_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\Appoinment_Db_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [Appoinment_Db] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Appoinment_Db].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Appoinment_Db] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Appoinment_Db] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Appoinment_Db] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Appoinment_Db] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Appoinment_Db] SET ARITHABORT OFF 
GO
ALTER DATABASE [Appoinment_Db] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [Appoinment_Db] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Appoinment_Db] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Appoinment_Db] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Appoinment_Db] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Appoinment_Db] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Appoinment_Db] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Appoinment_Db] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Appoinment_Db] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Appoinment_Db] SET  ENABLE_BROKER 
GO
ALTER DATABASE [Appoinment_Db] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Appoinment_Db] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Appoinment_Db] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Appoinment_Db] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Appoinment_Db] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Appoinment_Db] SET READ_COMMITTED_SNAPSHOT ON 
GO
ALTER DATABASE [Appoinment_Db] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Appoinment_Db] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [Appoinment_Db] SET  MULTI_USER 
GO
ALTER DATABASE [Appoinment_Db] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Appoinment_Db] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Appoinment_Db] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Appoinment_Db] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Appoinment_Db] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [Appoinment_Db] SET QUERY_STORE = OFF
GO
USE [Appoinment_Db]
GO
/****** Object:  User [developer]    Script Date: 8/21/2020 9:53:47 PM ******/
CREATE USER [developer] FOR LOGIN [developer] WITH DEFAULT_SCHEMA=[dbo]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 8/21/2020 9:53:47 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__EFMigrationsHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Appointment]    Script Date: 8/21/2020 9:53:47 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Appointment](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Date] [datetime2](7) NOT NULL,
	[Description] [varchar](200) NULL,
	[CreatedBy] [int] NOT NULL,
	[CreatedDate] [datetime2](7) NOT NULL,
	[ModifiedBy] [int] NULL,
	[ModifiedDate] [datetime2](7) NULL,
	[AppointedUserId] [int] NOT NULL,
	[Name] [varchar](200) NULL,
 CONSTRAINT [PK_Appointment] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Permission]    Script Date: 8/21/2020 9:53:47 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Permission](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](100) NULL,
	[IsActive] [bit] NOT NULL,
 CONSTRAINT [PK_Permission] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Role]    Script Date: 8/21/2020 9:53:47 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Role](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](100) NULL,
	[IsActive] [int] NOT NULL,
 CONSTRAINT [PK_Role] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[RolePermission]    Script Date: 8/21/2020 9:53:47 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RolePermission](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[RoleId] [int] NOT NULL,
	[PermissionId] [int] NOT NULL,
 CONSTRAINT [PK_RolePermission] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[User]    Script Date: 8/21/2020 9:53:47 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserName] [varchar](100) NULL,
	[Password] [varchar](100) NULL,
	[IsActive] [bit] NOT NULL,
	[RoleId] [int] NOT NULL,
	[Name] [varchar](100) NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20200821125455_init1', N'3.1.7')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20200821130023_init2', N'3.1.7')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20200821130448_init4', N'3.1.7')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20200821130557_init9', N'3.1.7')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20200821143525_init10', N'3.1.7')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20200821145233_init15', N'3.1.7')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20200821152000_init19', N'3.1.7')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20200821152256_init187', N'3.1.7')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20200821153137_init1865', N'3.1.7')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20200821154321_init18653', N'3.1.7')
SET IDENTITY_INSERT [dbo].[Appointment] ON 

INSERT [dbo].[Appointment] ([Id], [Date], [Description], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [AppointedUserId], [Name]) VALUES (7, CAST(N'2020-08-21T00:00:00.0000000' AS DateTime2), N'Meet Doctor', 0, CAST(N'2020-08-21T21:49:47.9928941' AS DateTime2), NULL, NULL, 2, N'Masha Vithanage')
INSERT [dbo].[Appointment] ([Id], [Date], [Description], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [AppointedUserId], [Name]) VALUES (8, CAST(N'2020-08-21T00:00:00.0000000' AS DateTime2), N'Meet Manager', 0, CAST(N'2020-08-21T21:50:01.7114354' AS DateTime2), NULL, NULL, 2, N'Masha Vithanage')
INSERT [dbo].[Appointment] ([Id], [Date], [Description], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [AppointedUserId], [Name]) VALUES (9, CAST(N'2020-08-21T00:00:00.0000000' AS DateTime2), N'Meet President', 0, CAST(N'2020-08-21T21:50:32.8025366' AS DateTime2), NULL, NULL, 2, N'Sunil Nanayakakra')
INSERT [dbo].[Appointment] ([Id], [Date], [Description], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [AppointedUserId], [Name]) VALUES (10, CAST(N'2020-08-21T00:00:00.0000000' AS DateTime2), N'Meet Minister', 0, CAST(N'2020-08-21T21:52:07.4018535' AS DateTime2), NULL, NULL, 3, N'Manel Marasinghe')
SET IDENTITY_INSERT [dbo].[Appointment] OFF
SET IDENTITY_INSERT [dbo].[Role] ON 

INSERT [dbo].[Role] ([Id], [Name], [IsActive]) VALUES (2, N'CompanyUser', 1)
INSERT [dbo].[Role] ([Id], [Name], [IsActive]) VALUES (3, N'PublicUser', 1)
SET IDENTITY_INSERT [dbo].[Role] OFF
SET IDENTITY_INSERT [dbo].[User] ON 

INSERT [dbo].[User] ([Id], [UserName], [Password], [IsActive], [RoleId], [Name]) VALUES (1, N'Dasun', N'12345', 1, 2, N'Dasun Lakshan')
INSERT [dbo].[User] ([Id], [UserName], [Password], [IsActive], [RoleId], [Name]) VALUES (2, N'Madura', N'12345', 1, 3, N'Madura Vithanage')
INSERT [dbo].[User] ([Id], [UserName], [Password], [IsActive], [RoleId], [Name]) VALUES (3, N'Manel', N'12345', 1, 3, N'Manel Marasinghe')
SET IDENTITY_INSERT [dbo].[User] OFF
/****** Object:  Index [IX_Appointment_AppointedUserId]    Script Date: 8/21/2020 9:53:48 PM ******/
CREATE NONCLUSTERED INDEX [IX_Appointment_AppointedUserId] ON [dbo].[Appointment]
(
	[AppointedUserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_RolePermission_PermissionId]    Script Date: 8/21/2020 9:53:48 PM ******/
CREATE NONCLUSTERED INDEX [IX_RolePermission_PermissionId] ON [dbo].[RolePermission]
(
	[PermissionId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_RolePermission_RoleId]    Script Date: 8/21/2020 9:53:48 PM ******/
CREATE NONCLUSTERED INDEX [IX_RolePermission_RoleId] ON [dbo].[RolePermission]
(
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_User_RoleId]    Script Date: 8/21/2020 9:53:48 PM ******/
CREATE NONCLUSTERED INDEX [IX_User_RoleId] ON [dbo].[User]
(
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Appointment] ADD  DEFAULT ((0)) FOR [AppointedUserId]
GO
ALTER TABLE [dbo].[Permission] ADD  DEFAULT (CONVERT([bit],(0))) FOR [IsActive]
GO
ALTER TABLE [dbo].[User] ADD  DEFAULT ((0)) FOR [RoleId]
GO
ALTER TABLE [dbo].[Appointment]  WITH CHECK ADD  CONSTRAINT [FK_Appointment_User_AppointedUserId] FOREIGN KEY([AppointedUserId])
REFERENCES [dbo].[User] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Appointment] CHECK CONSTRAINT [FK_Appointment_User_AppointedUserId]
GO
ALTER TABLE [dbo].[RolePermission]  WITH CHECK ADD  CONSTRAINT [FK_RolePermission_Permission_PermissionId] FOREIGN KEY([PermissionId])
REFERENCES [dbo].[Permission] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[RolePermission] CHECK CONSTRAINT [FK_RolePermission_Permission_PermissionId]
GO
ALTER TABLE [dbo].[RolePermission]  WITH CHECK ADD  CONSTRAINT [FK_RolePermission_Role_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[Role] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[RolePermission] CHECK CONSTRAINT [FK_RolePermission_Role_RoleId]
GO
ALTER TABLE [dbo].[User]  WITH CHECK ADD  CONSTRAINT [FK_User_Role_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[Role] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[User] CHECK CONSTRAINT [FK_User_Role_RoleId]
GO
USE [master]
GO
ALTER DATABASE [Appoinment_Db] SET  READ_WRITE 
GO
