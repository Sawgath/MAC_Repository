USE [master]
GO
/****** Object:  Database [CODER4_BLOG_WebDB]    Script Date: 18/03/2015 09:04:04 PM ******/
CREATE DATABASE [CODER4_BLOG_WebDB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'CODER4_BLOG_WebDB', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.MAC_SERVER\MSSQL\DATA\CODER4_BLOG_WebDB.mdf' , SIZE = 5120KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'CODER4_BLOG_WebDB_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.MAC_SERVER\MSSQL\DATA\CODER4_BLOG_WebDB_log.ldf' , SIZE = 2048KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [CODER4_BLOG_WebDB] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [CODER4_BLOG_WebDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [CODER4_BLOG_WebDB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [CODER4_BLOG_WebDB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [CODER4_BLOG_WebDB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [CODER4_BLOG_WebDB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [CODER4_BLOG_WebDB] SET ARITHABORT OFF 
GO
ALTER DATABASE [CODER4_BLOG_WebDB] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [CODER4_BLOG_WebDB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [CODER4_BLOG_WebDB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [CODER4_BLOG_WebDB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [CODER4_BLOG_WebDB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [CODER4_BLOG_WebDB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [CODER4_BLOG_WebDB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [CODER4_BLOG_WebDB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [CODER4_BLOG_WebDB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [CODER4_BLOG_WebDB] SET  DISABLE_BROKER 
GO
ALTER DATABASE [CODER4_BLOG_WebDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [CODER4_BLOG_WebDB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [CODER4_BLOG_WebDB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [CODER4_BLOG_WebDB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [CODER4_BLOG_WebDB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [CODER4_BLOG_WebDB] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [CODER4_BLOG_WebDB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [CODER4_BLOG_WebDB] SET RECOVERY FULL 
GO
ALTER DATABASE [CODER4_BLOG_WebDB] SET  MULTI_USER 
GO
ALTER DATABASE [CODER4_BLOG_WebDB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [CODER4_BLOG_WebDB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [CODER4_BLOG_WebDB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [CODER4_BLOG_WebDB] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [CODER4_BLOG_WebDB] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'CODER4_BLOG_WebDB', N'ON'
GO
USE [CODER4_BLOG_WebDB]
GO
/****** Object:  Table [dbo].[Article_tb]    Script Date: 18/03/2015 09:04:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Article_tb](
	[topic_id] [int] IDENTITY(1,1) NOT NULL,
	[user_id] [int] NULL,
	[title] [varchar](max) NULL,
	[Date] [datetime] NULL,
	[picture_loc] [varchar](max) NULL,
	[description] [varchar](max) NULL,
	[count_like] [int] NULL,
 CONSTRAINT [PK_Article_tb] PRIMARY KEY CLUSTERED 
(
	[topic_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Comments_tb]    Script Date: 18/03/2015 09:04:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Comments_tb](
	[comment_id] [int] IDENTITY(1,1) NOT NULL,
	[topic_id] [int] NULL,
	[user_id] [int] NULL,
	[date] [datetime] NULL,
	[comments] [varchar](max) NULL,
 CONSTRAINT [PK_Comments_tb] PRIMARY KEY CLUSTERED 
(
	[comment_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[User]    Script Date: 18/03/2015 09:04:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[User](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[Email] [varchar](50) NOT NULL,
	[Password] [varchar](50) NOT NULL,
	[Type] [varchar](5) NOT NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
USE [master]
GO
ALTER DATABASE [CODER4_BLOG_WebDB] SET  READ_WRITE 
GO
