USE [master]
GO
/****** Object:  Database [Mblog]    Script Date: 2016/04/15 11:21:04 ******/
CREATE DATABASE [Mblog]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Mblog', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.SQLEXPRESS\MSSQL\DATA\Mblog.mdf' , SIZE = 5120KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'Mblog_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.SQLEXPRESS\MSSQL\DATA\Mblog_log.ldf' , SIZE = 2048KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [Mblog] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Mblog].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Mblog] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Mblog] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Mblog] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Mblog] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Mblog] SET ARITHABORT OFF 
GO
ALTER DATABASE [Mblog] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Mblog] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [Mblog] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Mblog] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Mblog] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Mblog] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Mblog] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Mblog] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Mblog] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Mblog] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Mblog] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Mblog] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Mblog] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Mblog] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Mblog] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Mblog] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Mblog] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Mblog] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Mblog] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [Mblog] SET  MULTI_USER 
GO
ALTER DATABASE [Mblog] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Mblog] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Mblog] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Mblog] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
USE [Mblog]
GO
/****** Object:  Table [dbo].[dt_AccountInfo]    Script Date: 2016/04/15 11:21:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[dt_AccountInfo](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Account] [nvarchar](50) NOT NULL,
	[Password] [varchar](50) NOT NULL,
	[Email] [nvarchar](100) NOT NULL,
	[Status] [int] NOT NULL,
	[CreateTime] [datetime] NOT NULL,
	[NickName] [nvarchar](50) NULL,
	[Description] [nvarchar](200) NULL,
	[Avatar] [varchar](50) NULL,
	[LastLoginIP] [varchar](15) NULL,
 CONSTRAINT [PK_dt_Id] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[dt_ActionInfo]    Script Date: 2016/04/15 11:21:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[dt_ActionInfo](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[AccountId] [int] NOT NULL,
	[ActionType] [int] NOT NULL,
	[CreateTime] [datetime] NOT NULL,
	[IP] [varchar](20) NOT NULL,
 CONSTRAINT [PK_dt_Action] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[dt_ArticleInfo]    Script Date: 2016/04/15 11:21:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[dt_ArticleInfo](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](100) NOT NULL,
	[Content] [text] NOT NULL,
	[CreateBy] [int] NOT NULL,
	[CreateTime] [datetime] NOT NULL,
	[Status] [int] NOT NULL,
	[ReadCount] [int] NOT NULL,
	[ViewEnable] [int] NOT NULL,
	[ReplyCount] [int] NOT NULL,
	[LastReadTime] [nchar](10) NULL,
 CONSTRAINT [PK_dt_Article] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[dt_BookInfo]    Script Date: 2016/04/15 11:21:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[dt_BookInfo](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[BookName] [nvarchar](100) NOT NULL,
	[Author] [nvarchar](50) NOT NULL,
	[Publisher] [nvarchar](100) NOT NULL,
	[publishTime] [date] NOT NULL,
	[Price] [decimal](18, 2) NOT NULL,
	[Status] [int] NOT NULL,
	[Category] [int] NOT NULL,
	[CreateTime] [datetime] NOT NULL,
	[ImageUrl] [varchar](50) NOT NULL,
	[Level] [int] NOT NULL,
 CONSTRAINT [PK_dt_BookInfo] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[dt_ReadingList]    Script Date: 2016/04/15 11:21:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[dt_ReadingList](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[AccountId] [int] NOT NULL,
	[BookId] [int] NOT NULL,
	[CreateTime] [datetime] NOT NULL,
	[ReadStatus] [int] NOT NULL,
	[Status] [int] NOT NULL,
	[PredictReadTimeBegin] [datetime] NULL,
	[PredictReadTimeEnd] [datetime] NULL,
	[ReadTimeBegin] [datetime] NULL,
	[ReadTimeEnd] [datetime] NULL,
	[Category] [nchar](10) NOT NULL,
	[Proportion] [int] NOT NULL,
 CONSTRAINT [PK_dt_ReadingList] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[dt_ReadingNotes]    Script Date: 2016/04/15 11:21:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[dt_ReadingNotes](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[BookId] [nchar](10) NOT NULL,
	[AccountId] [int] NOT NULL,
	[CreateTime] [datetime] NOT NULL,
	[Status] [int] NOT NULL,
	[Title] [nvarchar](200) NOT NULL,
	[Content] [ntext] NOT NULL,
	[ReadCount] [int] NOT NULL,
	[AgreeCount] [int] NOT NULL,
	[AgainstCount] [int] NOT NULL,
	[IsPublic] [bit] NOT NULL,
	[ModifyTime] [datetime] NULL,
 CONSTRAINT [PK_dt_ReadingNotes] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
ALTER TABLE [dbo].[dt_AccountInfo] ADD  CONSTRAINT [DF_dt_Account_Status]  DEFAULT ((0)) FOR [Status]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'主键' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'dt_AccountInfo', @level2type=N'COLUMN',@level2name=N'Id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'账号 唯一' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'dt_AccountInfo', @level2type=N'COLUMN',@level2name=N'Account'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'密码 MD5加密' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'dt_AccountInfo', @level2type=N'COLUMN',@level2name=N'Password'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'注册邮箱 唯一' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'dt_AccountInfo', @level2type=N'COLUMN',@level2name=N'Email'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'状态 [0]未激活 [1]正常 [2]禁用 ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'dt_AccountInfo', @level2type=N'COLUMN',@level2name=N'Status'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'dt_AccountInfo', @level2type=N'COLUMN',@level2name=N'CreateTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'昵称' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'dt_AccountInfo', @level2type=N'COLUMN',@level2name=N'NickName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'自我介绍' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'dt_AccountInfo', @level2type=N'COLUMN',@level2name=N'Description'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'头像地址' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'dt_AccountInfo', @level2type=N'COLUMN',@level2name=N'Avatar'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'上次登录IP' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'dt_AccountInfo', @level2type=N'COLUMN',@level2name=N'LastLoginIP'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'主键' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'dt_ActionInfo', @level2type=N'COLUMN',@level2name=N'Id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'用户' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'dt_ActionInfo', @level2type=N'COLUMN',@level2name=N'AccountId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'操作类型' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'dt_ActionInfo', @level2type=N'COLUMN',@level2name=N'ActionType'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'添加时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'dt_ActionInfo', @level2type=N'COLUMN',@level2name=N'CreateTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'IP地址' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'dt_ActionInfo', @level2type=N'COLUMN',@level2name=N'IP'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'主键' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'dt_ReadingList', @level2type=N'COLUMN',@level2name=N'Id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'用户Id' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'dt_ReadingList', @level2type=N'COLUMN',@level2name=N'AccountId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'书籍Id' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'dt_ReadingList', @level2type=N'COLUMN',@level2name=N'BookId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'dt_ReadingList', @level2type=N'COLUMN',@level2name=N'CreateTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'读书状态 [0]未读 [1]正在阅读 [2]已读' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'dt_ReadingList', @level2type=N'COLUMN',@level2name=N'ReadStatus'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'状态 [0]正常 [1]删除' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'dt_ReadingList', @level2type=N'COLUMN',@level2name=N'Status'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'计划阅读开始时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'dt_ReadingList', @level2type=N'COLUMN',@level2name=N'PredictReadTimeBegin'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'计划阅读结束时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'dt_ReadingList', @level2type=N'COLUMN',@level2name=N'PredictReadTimeEnd'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'实际阅读开始时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'dt_ReadingList', @level2type=N'COLUMN',@level2name=N'ReadTimeBegin'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'实际阅读结束时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'dt_ReadingList', @level2type=N'COLUMN',@level2name=N'ReadTimeEnd'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'分类' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'dt_ReadingList', @level2type=N'COLUMN',@level2name=N'Category'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'进度' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'dt_ReadingList', @level2type=N'COLUMN',@level2name=N'Proportion'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'主键' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'dt_ReadingNotes', @level2type=N'COLUMN',@level2name=N'Id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'图书Id' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'dt_ReadingNotes', @level2type=N'COLUMN',@level2name=N'BookId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'账号Id' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'dt_ReadingNotes', @level2type=N'COLUMN',@level2name=N'AccountId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'添加时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'dt_ReadingNotes', @level2type=N'COLUMN',@level2name=N'CreateTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'状态 [0]正常 [1]删除' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'dt_ReadingNotes', @level2type=N'COLUMN',@level2name=N'Status'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'标题' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'dt_ReadingNotes', @level2type=N'COLUMN',@level2name=N'Title'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'内容' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'dt_ReadingNotes', @level2type=N'COLUMN',@level2name=N'Content'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'浏览次数' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'dt_ReadingNotes', @level2type=N'COLUMN',@level2name=N'ReadCount'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'赞同数' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'dt_ReadingNotes', @level2type=N'COLUMN',@level2name=N'AgreeCount'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'反对数' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'dt_ReadingNotes', @level2type=N'COLUMN',@level2name=N'AgainstCount'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'是否公开可见' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'dt_ReadingNotes', @level2type=N'COLUMN',@level2name=N'IsPublic'
GO
USE [master]
GO
ALTER DATABASE [Mblog] SET  READ_WRITE 
GO
