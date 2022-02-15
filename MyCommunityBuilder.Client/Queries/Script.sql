USE [master]
GO
/****** Object:  Database [communitybuilder]    Script Date: 27/10/2021 7:04:48 pm ******/
CREATE DATABASE [communitybuilder]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'communitybuilder', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\communitybuilder.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'communitybuilder_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\communitybuilder_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [communitybuilder] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [communitybuilder].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [communitybuilder] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [communitybuilder] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [communitybuilder] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [communitybuilder] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [communitybuilder] SET ARITHABORT OFF 
GO
ALTER DATABASE [communitybuilder] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [communitybuilder] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [communitybuilder] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [communitybuilder] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [communitybuilder] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [communitybuilder] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [communitybuilder] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [communitybuilder] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [communitybuilder] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [communitybuilder] SET  ENABLE_BROKER 
GO
ALTER DATABASE [communitybuilder] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [communitybuilder] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [communitybuilder] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [communitybuilder] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [communitybuilder] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [communitybuilder] SET READ_COMMITTED_SNAPSHOT ON 
GO
ALTER DATABASE [communitybuilder] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [communitybuilder] SET RECOVERY FULL 
GO
ALTER DATABASE [communitybuilder] SET  MULTI_USER 
GO
ALTER DATABASE [communitybuilder] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [communitybuilder] SET DB_CHAINING OFF 
GO
ALTER DATABASE [communitybuilder] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [communitybuilder] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [communitybuilder] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [communitybuilder] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'communitybuilder', N'ON'
GO
ALTER DATABASE [communitybuilder] SET QUERY_STORE = OFF
GO
USE [communitybuilder]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 27/10/2021 7:04:49 pm ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[BusinessComments]    Script Date: 27/10/2021 7:04:49 pm ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BusinessComments](
	[BusinessCommentID] [int] IDENTITY(1,1) NOT NULL,
	[BusinessID] [int] NOT NULL,
	[Title] [nvarchar](max) NULL,
	[Comment] [nvarchar](max) NULL,
	[UserID] [nvarchar](max) NULL,
	[PublishDate] [datetime2](7) NULL,
 CONSTRAINT [PK_BusinessComments] PRIMARY KEY CLUSTERED 
(
	[BusinessCommentID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[BusinessCommentSub]    Script Date: 27/10/2021 7:04:49 pm ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BusinessCommentSub](
	[SubCommentID] [int] IDENTITY(1,1) NOT NULL,
	[CommentID] [int] NOT NULL,
	[UserID] [nvarchar](max) NULL,
	[Comment] [nvarchar](max) NULL,
	[PublishDate] [datetime2](7) NOT NULL,
	[Inactive] [bit] NOT NULL,
 CONSTRAINT [PK_BusinessCommentSub] PRIMARY KEY CLUSTERED 
(
	[SubCommentID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Businesses]    Script Date: 27/10/2021 7:04:49 pm ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Businesses](
	[BusinessID] [int] IDENTITY(1,1) NOT NULL,
	[BusinessName] [nvarchar](max) NULL,
	[BusinessAddressStreet] [nvarchar](max) NULL,
	[BusinessAddressSuite] [nvarchar](max) NULL,
	[BusinessAddressCity] [nvarchar](max) NULL,
	[BusinessAddressState] [nvarchar](max) NULL,
	[BusinessAddressZipcode] [nvarchar](max) NULL,
	[BusinessAddressCountry] [nvarchar](max) NULL,
	[SortIndex] [int] NULL,
	[BusinessNumber] [int] NULL,
	[Type] [nvarchar](max) NULL,
	[Visible] [bit] NULL,
	[NumberOfFans] [int] NULL,
	[Description] [nvarchar](max) NULL,
	[Telephone] [nvarchar](max) NULL,
	[Address] [nvarchar](max) NULL,
	[Email] [nvarchar](max) NULL,
	[Website] [nvarchar](max) NULL,
	[Offers] [bit] NULL,
	[SearchTerms] [nvarchar](max) NULL,
	[UserID] [nvarchar](max) NULL,
	[SiteID] [int] NULL,
	[LocallyOwned] [int] NOT NULL,
	[Published] [bit] NULL,
	[PublishDate] [datetime2](7) NULL,
	[PublishedByUserID] [nvarchar](max) NULL,
	[DeactivationDate] [datetime2](7) NULL,
	[Inactive] [bit] NOT NULL,
	[DateAdded] [datetime2](7) NULL,
	[AddedByUserID] [nvarchar](max) NULL,
 CONSTRAINT [PK_Businesses] PRIMARY KEY CLUSTERED 
(
	[BusinessID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[BusinessEvents]    Script Date: 27/10/2021 7:04:49 pm ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BusinessEvents](
	[BusinessID] [int] NOT NULL,
	[EventID] [int] NOT NULL,
 CONSTRAINT [PK_BusinessEvents] PRIMARY KEY CLUSTERED 
(
	[BusinessID] ASC,
	[EventID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[BusinessFiles]    Script Date: 27/10/2021 7:04:49 pm ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BusinessFiles](
	[FileID] [int] IDENTITY(1,1) NOT NULL,
	[BusinessID] [int] NOT NULL,
	[FileURL] [nvarchar](max) NULL,
	[IconURL] [nvarchar](max) NULL,
	[SortIndex] [int] NULL,
	[Title] [nvarchar](max) NULL,
	[Category] [nvarchar](max) NULL,
	[Stamp] [datetime2](7) NULL,
 CONSTRAINT [PK_BusinessFiles] PRIMARY KEY CLUSTERED 
(
	[FileID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Client]    Script Date: 27/10/2021 7:04:49 pm ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Client](
	[ClientID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NULL,
	[Street] [nvarchar](max) NULL,
	[Suite] [nvarchar](max) NULL,
	[City] [nvarchar](max) NULL,
	[State] [nvarchar](max) NULL,
	[Zipcode] [nvarchar](max) NULL,
	[CountryID] [int] NOT NULL,
	[Telephone] [nvarchar](max) NULL,
	[Email] [nvarchar](max) NULL,
	[Website] [nvarchar](max) NULL,
	[DateAdded] [datetime2](7) NOT NULL,
	[AddedByUserID] [nvarchar](max) NULL,
 CONSTRAINT [PK_Client] PRIMARY KEY CLUSTERED 
(
	[ClientID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ClientContacts]    Script Date: 27/10/2021 7:04:49 pm ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ClientContacts](
	[ClientID] [int] NOT NULL,
	[ContactID] [int] NOT NULL,
	[DateAdded] [datetime2](7) NOT NULL,
	[AddedByUserID] [nvarchar](max) NULL,
 CONSTRAINT [PK_ClientContacts] PRIMARY KEY CLUSTERED 
(
	[ClientID] ASC,
	[ContactID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ClientSites]    Script Date: 27/10/2021 7:04:49 pm ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ClientSites](
	[ClientID] [int] NOT NULL,
	[SiteID] [int] NOT NULL,
	[DateAdded] [datetime2](7) NOT NULL,
	[AddedByUserID] [nvarchar](max) NULL,
 CONSTRAINT [PK_ClientSites] PRIMARY KEY CLUSTERED 
(
	[ClientID] ASC,
	[SiteID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Contact]    Script Date: 27/10/2021 7:04:49 pm ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Contact](
	[ContactID] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](max) NULL,
	[LastName] [nvarchar](max) NULL,
	[Title] [nvarchar](max) NULL,
	[SiteID] [nvarchar](max) NULL,
	[UserID] [nvarchar](max) NULL,
	[Comment] [nvarchar](max) NULL,
	[Phone1] [nvarchar](max) NULL,
	[Phone2] [nvarchar](max) NULL,
	[Email1] [nvarchar](max) NULL,
	[Email2] [nvarchar](max) NULL,
	[AddressStreet] [nvarchar](max) NULL,
	[AddressSuite] [nvarchar](max) NULL,
	[AddressCity] [nvarchar](max) NULL,
	[AddressState] [nvarchar](max) NULL,
	[AddressZip] [nvarchar](max) NULL,
	[AddressCountry] [nvarchar](max) NULL,
 CONSTRAINT [PK_Contact] PRIMARY KEY CLUSTERED 
(
	[ContactID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Country]    Script Date: 27/10/2021 7:04:49 pm ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Country](
	[CountryID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NULL,
	[NameLong] [nvarchar](max) NULL,
	[DefaultLanguageID] [int] NOT NULL,
 CONSTRAINT [PK_Country] PRIMARY KEY CLUSTERED 
(
	[CountryID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Events]    Script Date: 27/10/2021 7:04:49 pm ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Events](
	[EventID] [int] IDENTITY(1,1) NOT NULL,
	[VirtualOrPhysical] [nvarchar](max) NULL,
	[VirtualType] [nvarchar](max) NULL,
	[Date] [datetime2](7) NULL,
	[Time] [datetime2](7) NULL,
	[TimeZone] [nvarchar](max) NULL,
	[Location] [nvarchar](max) NULL,
	[Type] [nvarchar](max) NULL,
	[Hyperlink1] [nvarchar](max) NULL,
	[Hyperlink2] [nvarchar](max) NULL,
	[Comment] [nvarchar](max) NULL,
	[DateAdded] [datetime2](7) NULL,
	[AddedByUserID] [nvarchar](max) NULL,
	[Inactive] [bit] NOT NULL,
	[DeactivateOn] [datetime2](7) NULL,
	[DeactivatedByUserID] [nvarchar](max) NULL,
 CONSTRAINT [PK_Events] PRIMARY KEY CLUSTERED 
(
	[EventID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Fans]    Script Date: 27/10/2021 7:04:49 pm ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Fans](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[UserID] [nvarchar](max) NULL,
	[BusinessID] [int] NOT NULL,
	[ThisWeek] [int] NOT NULL,
	[Date] [datetime2](7) NULL,
 CONSTRAINT [PK_Fans] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[FundingPlan]    Script Date: 27/10/2021 7:04:49 pm ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FundingPlan](
	[FundingPlanID] [int] IDENTITY(1,1) NOT NULL,
	[BusinessID] [int] NOT NULL,
	[FundingTypeID] [int] NOT NULL,
	[PlanTerms] [nvarchar](max) NULL,
	[PlanComments] [nvarchar](max) NULL,
	[PlanPublicizeDate] [datetime2](7) NOT NULL,
	[PlanFulfilledDate] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_FundingPlan] PRIMARY KEY CLUSTERED 
(
	[FundingPlanID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[FundingPlanInvestor]    Script Date: 27/10/2021 7:04:49 pm ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FundingPlanInvestor](
	[FundingPlanID] [int] IDENTITY(1,1) NOT NULL,
	[InvestorUserID] [int] NOT NULL,
 CONSTRAINT [PK_FundingPlanInvestor] PRIMARY KEY CLUSTERED 
(
	[FundingPlanID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[FundingType]    Script Date: 27/10/2021 7:04:49 pm ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FundingType](
	[FundingTypeID] [int] IDENTITY(1,1) NOT NULL,
	[Description] [nvarchar](max) NULL,
 CONSTRAINT [PK_FundingType] PRIMARY KEY CLUSTERED 
(
	[FundingTypeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Language]    Script Date: 27/10/2021 7:04:49 pm ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Language](
	[LanguageID] [int] IDENTITY(1,1) NOT NULL,
	[LanguageCode] [nvarchar](max) NULL,
	[LanguageDescription] [nvarchar](max) NULL,
	[DefaultLanguageID] [int] NOT NULL,
 CONSTRAINT [PK_Language] PRIMARY KEY CLUSTERED 
(
	[LanguageID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Localization]    Script Date: 27/10/2021 7:04:49 pm ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Localization](
	[LocalizationID] [int] IDENTITY(1,1) NOT NULL,
	[LanguageID] [int] NOT NULL,
	[SiteID] [int] NOT NULL,
 CONSTRAINT [PK_Localization] PRIMARY KEY CLUSTERED 
(
	[LocalizationID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LocalizationGenericKeyValues]    Script Date: 27/10/2021 7:04:49 pm ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LocalizationGenericKeyValues](
	[KeyValueID] [int] IDENTITY(1,1) NOT NULL,
	[Key] [nvarchar](max) NULL,
	[Value] [nvarchar](max) NULL,
	[LanguageId] [int] NOT NULL,
	[Comment] [nvarchar](max) NULL,
 CONSTRAINT [PK_LocalizationGenericKeyValues] PRIMARY KEY CLUSTERED 
(
	[KeyValueID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LocalizationKeyValues]    Script Date: 27/10/2021 7:04:49 pm ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LocalizationKeyValues](
	[KeyValueID] [int] IDENTITY(1,1) NOT NULL,
	[LocalizationID] [int] NOT NULL,
	[Key] [nvarchar](max) NULL,
	[Value] [nvarchar](max) NULL,
 CONSTRAINT [PK_LocalizationKeyValues] PRIMARY KEY CLUSTERED 
(
	[KeyValueID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Referral]    Script Date: 27/10/2021 7:04:49 pm ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Referral](
	[ReferrerUserID] [nvarchar](450) NOT NULL,
	[ReferredUserID] [nvarchar](450) NOT NULL,
	[DateAdded] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_Referral] PRIMARY KEY CLUSTERED 
(
	[ReferredUserID] ASC,
	[ReferrerUserID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Site]    Script Date: 27/10/2021 7:04:49 pm ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Site](
	[SiteID] [int] IDENTITY(1,1) NOT NULL,
	[Guid] [uniqueidentifier] NOT NULL,
	[Name] [nvarchar](max) NULL,
	[URL] [nvarchar](max) NULL,
	[Comments] [nvarchar](max) NULL,
	[IsMasterSite] [bit] NOT NULL,
	[ParentID] [int] NULL,
	[DefaultLanguageID] [int] NOT NULL,
	[DateAdded] [datetime2](7) NOT NULL,
	[AddedByUserID] [nvarchar](max) NULL,
	[LogoPath] [nvarchar](max) NULL,
	[FacebookURL] [nvarchar](max) NULL,
	[TwitterURL] [nvarchar](max) NULL,
	[YoutubeURL] [nvarchar](max) NULL,
	[InstagramURL] [nvarchar](max) NULL,
 CONSTRAINT [PK_Site] PRIMARY KEY CLUSTERED 
(
	[SiteID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SiteEvents]    Script Date: 27/10/2021 7:04:49 pm ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SiteEvents](
	[SiteID] [int] NOT NULL,
	[EventID] [int] NOT NULL,
 CONSTRAINT [PK_SiteEvents] PRIMARY KEY CLUSTERED 
(
	[SiteID] ASC,
	[EventID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SiteHeader]    Script Date: 27/10/2021 7:04:49 pm ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SiteHeader](
	[SiteHeaderID] [int] IDENTITY(1,1) NOT NULL,
	[Image] [nvarchar](max) NULL,
	[Title] [nvarchar](max) NULL,
	[Text] [nvarchar](max) NULL,
	[DateAdded] [datetime2](7) NULL,
	[DateUpdated] [datetime2](7) NULL,
	[SiteID] [int] NOT NULL,
	[SitePageID] [int] NOT NULL,
 CONSTRAINT [PK_SiteHeader] PRIMARY KEY CLUSTERED 
(
	[SiteHeaderID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SitePage]    Script Date: 27/10/2021 7:04:49 pm ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SitePage](
	[SitePageID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NULL,
 CONSTRAINT [PK_SitePage] PRIMARY KEY CLUSTERED 
(
	[SitePageID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[xStage1]    Script Date: 27/10/2021 7:04:49 pm ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[xStage1](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[LanguageID] [int] NOT NULL,
	[FileName] [nvarchar](max) NULL,
	[Comment] [nvarchar](max) NULL,
	[Key] [nvarchar](max) NULL,
	[Filler] [nvarchar](max) NULL,
	[Comment_OLd] [nvarchar](max) NULL,
	[Value] [nvarchar](max) NULL,
 CONSTRAINT [PK_xStage1] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[xStage2]    Script Date: 27/10/2021 7:04:49 pm ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[xStage2](
	[Stage2ID] [int] IDENTITY(1,1) NOT NULL,
	[Key] [nvarchar](max) NULL,
	[Value] [nvarchar](max) NULL,
	[LanguageID] [int] NOT NULL,
	[Comment] [nvarchar](max) NULL,
 CONSTRAINT [PK_xStage2] PRIMARY KEY CLUSTERED 
(
	[Stage2ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Index [IX_BusinessComments_BusinessID]    Script Date: 27/10/2021 7:04:50 pm ******/
CREATE NONCLUSTERED INDEX [IX_BusinessComments_BusinessID] ON [dbo].[BusinessComments]
(
	[BusinessID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Businesses_SiteID]    Script Date: 27/10/2021 7:04:50 pm ******/
CREATE NONCLUSTERED INDEX [IX_Businesses_SiteID] ON [dbo].[Businesses]
(
	[SiteID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_BusinessFiles_BusinessID]    Script Date: 27/10/2021 7:04:50 pm ******/
CREATE NONCLUSTERED INDEX [IX_BusinessFiles_BusinessID] ON [dbo].[BusinessFiles]
(
	[BusinessID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Fans_BusinessID]    Script Date: 27/10/2021 7:04:50 pm ******/
CREATE NONCLUSTERED INDEX [IX_Fans_BusinessID] ON [dbo].[Fans]
(
	[BusinessID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Localization_LanguageID]    Script Date: 27/10/2021 7:04:50 pm ******/
CREATE NONCLUSTERED INDEX [IX_Localization_LanguageID] ON [dbo].[Localization]
(
	[LanguageID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Localization_SiteID]    Script Date: 27/10/2021 7:04:50 pm ******/
CREATE NONCLUSTERED INDEX [IX_Localization_SiteID] ON [dbo].[Localization]
(
	[SiteID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_LocalizationGenericKeyValues_LanguageId]    Script Date: 27/10/2021 7:04:50 pm ******/
CREATE NONCLUSTERED INDEX [IX_LocalizationGenericKeyValues_LanguageId] ON [dbo].[LocalizationGenericKeyValues]
(
	[LanguageId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_LocalizationKeyValues_LocalizationID]    Script Date: 27/10/2021 7:04:50 pm ******/
CREATE NONCLUSTERED INDEX [IX_LocalizationKeyValues_LocalizationID] ON [dbo].[LocalizationKeyValues]
(
	[LocalizationID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_SiteHeader_SiteID]    Script Date: 27/10/2021 7:04:50 pm ******/
CREATE NONCLUSTERED INDEX [IX_SiteHeader_SiteID] ON [dbo].[SiteHeader]
(
	[SiteID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_SiteHeader_SitePageID]    Script Date: 27/10/2021 7:04:50 pm ******/
CREATE NONCLUSTERED INDEX [IX_SiteHeader_SitePageID] ON [dbo].[SiteHeader]
(
	[SitePageID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[BusinessComments]  WITH CHECK ADD  CONSTRAINT [FK_BusinessComments_Businesses_BusinessID] FOREIGN KEY([BusinessID])
REFERENCES [dbo].[Businesses] ([BusinessID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[BusinessComments] CHECK CONSTRAINT [FK_BusinessComments_Businesses_BusinessID]
GO
ALTER TABLE [dbo].[Businesses]  WITH CHECK ADD  CONSTRAINT [FK_Businesses_Site_SiteID] FOREIGN KEY([SiteID])
REFERENCES [dbo].[Site] ([SiteID])
GO
ALTER TABLE [dbo].[Businesses] CHECK CONSTRAINT [FK_Businesses_Site_SiteID]
GO
ALTER TABLE [dbo].[BusinessFiles]  WITH CHECK ADD  CONSTRAINT [FK_BusinessFiles_Businesses_BusinessID] FOREIGN KEY([BusinessID])
REFERENCES [dbo].[Businesses] ([BusinessID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[BusinessFiles] CHECK CONSTRAINT [FK_BusinessFiles_Businesses_BusinessID]
GO
ALTER TABLE [dbo].[Fans]  WITH CHECK ADD  CONSTRAINT [FK_Fans_Businesses_BusinessID] FOREIGN KEY([BusinessID])
REFERENCES [dbo].[Businesses] ([BusinessID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Fans] CHECK CONSTRAINT [FK_Fans_Businesses_BusinessID]
GO
ALTER TABLE [dbo].[Localization]  WITH CHECK ADD  CONSTRAINT [FK_Localization_Language_LanguageID] FOREIGN KEY([LanguageID])
REFERENCES [dbo].[Language] ([LanguageID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Localization] CHECK CONSTRAINT [FK_Localization_Language_LanguageID]
GO
ALTER TABLE [dbo].[Localization]  WITH CHECK ADD  CONSTRAINT [FK_Localization_Site_SiteID] FOREIGN KEY([SiteID])
REFERENCES [dbo].[Site] ([SiteID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Localization] CHECK CONSTRAINT [FK_Localization_Site_SiteID]
GO
ALTER TABLE [dbo].[LocalizationGenericKeyValues]  WITH CHECK ADD  CONSTRAINT [FK_LocalizationGenericKeyValues_Language_LanguageId] FOREIGN KEY([LanguageId])
REFERENCES [dbo].[Language] ([LanguageID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[LocalizationGenericKeyValues] CHECK CONSTRAINT [FK_LocalizationGenericKeyValues_Language_LanguageId]
GO
ALTER TABLE [dbo].[LocalizationKeyValues]  WITH CHECK ADD  CONSTRAINT [FK_LocalizationKeyValues_Localization_LocalizationID] FOREIGN KEY([LocalizationID])
REFERENCES [dbo].[Localization] ([LocalizationID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[LocalizationKeyValues] CHECK CONSTRAINT [FK_LocalizationKeyValues_Localization_LocalizationID]
GO
ALTER TABLE [dbo].[SiteHeader]  WITH CHECK ADD  CONSTRAINT [FK_SiteHeader_Site_SiteID] FOREIGN KEY([SiteID])
REFERENCES [dbo].[Site] ([SiteID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[SiteHeader] CHECK CONSTRAINT [FK_SiteHeader_Site_SiteID]
GO
ALTER TABLE [dbo].[SiteHeader]  WITH CHECK ADD  CONSTRAINT [FK_SiteHeader_SitePage_SitePageID] FOREIGN KEY([SitePageID])
REFERENCES [dbo].[SitePage] ([SitePageID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[SiteHeader] CHECK CONSTRAINT [FK_SiteHeader_SitePage_SitePageID]
GO
/****** Object:  StoredProcedure [dbo].[spGetBusinessBySiteID]    Script Date: 27/10/2021 7:04:50 pm ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spGetBusinessBySiteID] @SiteID int, @SearchText nvarchar(100) = '' AS BEGIN Begin Try if (@SearchText = '' or @SearchText is null) begin select b.BusinessID, b.BusinessName, b.Type, bf.IconURL from Business b inner join BusinessFile bf on b.BusinessID = bf.BusinessID where b.SiteID = @SiteID and bf.SortIndex = 1 end else begin select distinct b.BusinessID, b.BusinessName, b.Type, bf.IconURL from Business b inner join BusinessFile bf on b.BusinessID = bf.BusinessID where b.SiteID = @SiteID and bf.SortIndex = 1 and(b.BusinessName like '%' + @SearchText + '%' or b.Type like '%' + @SearchText + '%' or b.BusinessNumber like '%' + @SearchText + '%') end End Try Begin Catch End Catch END
GO
/****** Object:  StoredProcedure [dbo].[spGetBusinessFans]    Script Date: 27/10/2021 7:04:50 pm ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create PROCEDURE [dbo].[spGetBusinessFans] AS BEGIN select top 10 b.BusinessName,COUNT(fa.UserID) NumberOfFans, (select Count(fa.UserID) from Fan fa where fa.Date BETWEEN DATEADD(DAY, -7, GETDATE()) AND DATEADD(DAY, 1, GETDATE()) and fa.BusinessID = b.BusinessID) as ThisWeek from Fan fa inner join Business b on b.BusinessID = fa.BusinessID and isnull(b.Inactive, 0) = 0 group by b.BusinessID,b.BusinessName order by NumberOfFans desc END
GO
/****** Object:  StoredProcedure [dbo].[spGetCSSStyleBySitePage]    Script Date: 27/10/2021 7:04:50 pm ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create PROCEDURE [dbo].[spGetCSSStyleBySitePage] @SitePage nvarchar(50) AS BEGIN Begin Try Declare @SitePageID int = (select SitePageID from SitePage where[Name] = @SitePage) Select* from CSS where SitePageID = @SitePageID End Try Begin Catch End Catch END
GO
/****** Object:  StoredProcedure [dbo].[spGetGenericLocalization]    Script Date: 27/10/2021 7:04:50 pm ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROCEDURE[dbo].[spGetGenericLocalization] @LanguageId int AS BEGIN Begin Try select* from LocalizationGenericKeyValues where LanguageId = @LanguageId End Try Begin Catch End Catch END
GO
/****** Object:  StoredProcedure [dbo].[spGetHeaderBySiteIDAndSitePage]    Script Date: 27/10/2021 7:04:50 pm ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create   PROCEDURE [dbo].[spGetHeaderBySiteIDAndSitePage] @SiteID int, @SitePage nvarchar(MAX) AS BEGIN Begin Try Declare @SitePageID int = (Select SitePageID from SitePage where Name = @SitePage) Select * from SiteHeader where SiteID = @SiteID and SitePageID = @SitePageID End Try Begin Catch End Catch END
GO
/****** Object:  StoredProcedure [dbo].[spGetLanguageBySiteID]    Script Date: 27/10/2021 7:04:50 pm ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create PROCEDURE [dbo].[spGetLanguageBySiteID] @SiteID int AS BEGIN Begin Try select la.*, s.DefaultLanguageID from[Language] la with(nolock) inner join Localization lo  with(nolock) on la.LanguageID = lo.LanguageID  inner join Site s with(nolock) on s.SiteID = lo.SiteID where lo.SiteID = @SiteID End Try Begin Catch End Catch END
GO
/****** Object:  StoredProcedure [dbo].[spGetLocalizationBySiteID]    Script Date: 27/10/2021 7:04:50 pm ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create PROCEDURE [dbo].[spGetLocalizationBySiteID] @SiteID int AS BEGIN Begin Try select lo.*, l.LanguageID, l.SiteID, la.LanguageDescription, la.LanguageCode from LocalizationKeyValues lo inner join Localization l on lo.LocalizationID = l.LocalizationID inner join[Language] la on la.LanguageID = l.LanguageID and l.SiteID = @SiteID End Try Begin Catch End Catch END
GO
/****** Object:  StoredProcedure [dbo].[spGetSites]    Script Date: 27/10/2021 7:04:50 pm ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create PROCEDURE [dbo].[spGetSites] AS BEGIN Begin Try select* from[Site] End Try Begin Catch End Catch END
GO
/****** Object:  StoredProcedure [dbo].[spGetTopFans]    Script Date: 27/10/2021 7:04:50 pm ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROCEDURE [dbo].[spGetTopFans] AS BEGIN select top 10 b.BusinessName,COUNT(fa.UserID) NumberOfFans, (select Count(fa.UserID) from Fan fa where fa.Date BETWEEN DATEADD(DAY, -7, GETDATE()) AND DATEADD(DAY, 1, GETDATE()) and fa.BusinessID = b.BusinessID) as ThisWeek from Fan fa inner join Business b on b.BusinessID = fa.BusinessID and isnull(b.Inactive, 0) = 0 group by b.BusinessID,b.BusinessName order by NumberOfFans desc END
GO
USE [master]
GO
ALTER DATABASE [communitybuilder] SET  READ_WRITE 
GO
