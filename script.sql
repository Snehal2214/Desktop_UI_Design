USE [master]
GO
/****** Object:  Database [Data_details]    Script Date: 16-10-2024 18:12:48 ******/
CREATE DATABASE [Data_details]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Data_details', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.SQLEXPRESS\MSSQL\DATA\Data_details.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Data_details_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.SQLEXPRESS\MSSQL\DATA\Data_details_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [Data_details] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Data_details].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Data_details] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Data_details] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Data_details] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Data_details] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Data_details] SET ARITHABORT OFF 
GO
ALTER DATABASE [Data_details] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [Data_details] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Data_details] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Data_details] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Data_details] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Data_details] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Data_details] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Data_details] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Data_details] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Data_details] SET  ENABLE_BROKER 
GO
ALTER DATABASE [Data_details] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Data_details] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Data_details] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Data_details] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Data_details] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Data_details] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Data_details] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Data_details] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [Data_details] SET  MULTI_USER 
GO
ALTER DATABASE [Data_details] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Data_details] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Data_details] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Data_details] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Data_details] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [Data_details] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [Data_details] SET QUERY_STORE = ON
GO
ALTER DATABASE [Data_details] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [Data_details]
GO
/****** Object:  Table [dbo].[Details]    Script Date: 16-10-2024 18:12:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Details](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[Company_Name] [varchar](20) NOT NULL,
	[Phone_No] [int] NOT NULL,
	[Email] [varchar](30) NOT NULL,
	[Address] [varchar](100) NOT NULL,
	[City] [varchar](25) NOT NULL,
	[State] [varchar](25) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Login]    Script Date: 16-10-2024 18:12:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Login](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Username] [varchar](20) NOT NULL,
	[Password] [varchar](10) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  StoredProcedure [dbo].[Check_Login]    Script Date: 16-10-2024 18:12:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[Check_Login]
(
@Username nvarchar(20),
@Password nvarchar(20)
)
as
begin
    SELECT COUNT(1)
    FROM Login
    WHERE UserName = @Username
      AND Password = @Password;
END
GO
/****** Object:  StoredProcedure [dbo].[insertDetails]    Script Date: 16-10-2024 18:12:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[insertDetails]
@Name NVARCHAR(100),
@Company_Name NVARCHAR(200),
@Phone_No NVARCHAR(20),
@Email NVARCHAR(100),
@Address NVARCHAR(300),
@City NVARCHAR(100),
@State NVARCHAR(50)
AS
insert into Details values(@Name, @Company_Name,@Phone_No,@Email,@Address,@City,@State);
GO
USE [master]
GO
ALTER DATABASE [Data_details] SET  READ_WRITE 
GO
