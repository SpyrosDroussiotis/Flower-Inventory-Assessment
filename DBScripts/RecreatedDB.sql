USE [master]
GO
/****** Object:  Database [FlowerInventoryAssessment]    Script Date: 6/16/2025 12:18:35 PM ******/
CREATE DATABASE [FlowerInventoryAssessment]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'FlowerInventoryAssessment', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.SQLEXPRESS\MSSQL\DATA\FlowerInventoryAssessment.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'FlowerInventoryAssessment_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.SQLEXPRESS\MSSQL\DATA\FlowerInventoryAssessment_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [FlowerInventoryAssessment] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [FlowerInventoryAssessment].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [FlowerInventoryAssessment] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [FlowerInventoryAssessment] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [FlowerInventoryAssessment] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [FlowerInventoryAssessment] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [FlowerInventoryAssessment] SET ARITHABORT OFF 
GO
ALTER DATABASE [FlowerInventoryAssessment] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [FlowerInventoryAssessment] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [FlowerInventoryAssessment] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [FlowerInventoryAssessment] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [FlowerInventoryAssessment] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [FlowerInventoryAssessment] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [FlowerInventoryAssessment] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [FlowerInventoryAssessment] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [FlowerInventoryAssessment] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [FlowerInventoryAssessment] SET  DISABLE_BROKER 
GO
ALTER DATABASE [FlowerInventoryAssessment] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [FlowerInventoryAssessment] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [FlowerInventoryAssessment] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [FlowerInventoryAssessment] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [FlowerInventoryAssessment] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [FlowerInventoryAssessment] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [FlowerInventoryAssessment] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [FlowerInventoryAssessment] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [FlowerInventoryAssessment] SET  MULTI_USER 
GO
ALTER DATABASE [FlowerInventoryAssessment] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [FlowerInventoryAssessment] SET DB_CHAINING OFF 
GO
ALTER DATABASE [FlowerInventoryAssessment] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [FlowerInventoryAssessment] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [FlowerInventoryAssessment] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [FlowerInventoryAssessment] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [FlowerInventoryAssessment] SET QUERY_STORE = ON
GO
ALTER DATABASE [FlowerInventoryAssessment] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [FlowerInventoryAssessment]
GO
/****** Object:  Table [dbo].[Category]    Script Date: 6/16/2025 12:18:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Category](
	[CategoryID] [int] IDENTITY(1,1) NOT NULL,
	[NameOfCategory] [nvarchar](100) NOT NULL,
	[Description] [nvarchar](500) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[CategoryID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Flower]    Script Date: 6/16/2025 12:18:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Flower](
	[FlowerID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
	[CategoryID] [int] NOT NULL,
	[Price] [decimal](10, 2) NOT NULL,
	[Color] [nvarchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[FlowerID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 6/16/2025 12:18:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[Username] [nvarchar](10) NOT NULL,
	[Password] [varchar](12) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Username] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Flower]  WITH CHECK ADD FOREIGN KEY([CategoryID])
REFERENCES [dbo].[Category] ([CategoryID])
GO
/****** Object:  StoredProcedure [dbo].[AddCategory]    Script Date: 6/16/2025 12:18:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create Procedure [dbo].[AddCategory]
@NameOfCategory NVARCHAR(100),
@Description NVARCHAR(500)
As
BEGIN
 Insert into Category(NameOfCategory, Description)
	Values (@NameOfCategory,@Description)
END;
GO
/****** Object:  StoredProcedure [dbo].[AddFlower]    Script Date: 6/16/2025 12:18:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create Procedure [dbo].[AddFlower]
 @CategoryID INT,
 @Name NVARCHAR(100),
 @Color NVARCHAR(50),
 @Price DECIMAL(10,2)
 AS
 BEGIN
 Insert into Flower(Name,CategoryID,Price,Color)
	Values (@Name,@CategoryID,@Price,@Color)
END;
GO
/****** Object:  StoredProcedure [dbo].[Authentication]    Script Date: 6/16/2025 12:18:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create Procedure [dbo].[Authentication]
 @Username NVARCHAR(10),
 @Password VARCHAR(12)
 AS
 BEGIN
 SELECT *
 FROM Users
 WHERE @Username=Username AND @Password=Password
 END;
GO
/****** Object:  StoredProcedure [dbo].[DeleteCategory]    Script Date: 6/16/2025 12:18:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create procedure [dbo].[DeleteCategory]
@CategoryID INT
AS
BEGIN 
DELETE FROM Category
 WHERE @CategoryID=CategoryID
 END;
GO
/****** Object:  StoredProcedure [dbo].[DeleteFlower]    Script Date: 6/16/2025 12:18:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create procedure [dbo].[DeleteFlower]
@FlowerID INT
AS
BEGIN 
DELETE FROM Flower
 WHERE @FlowerID=FlowerID
 END;
GO
/****** Object:  StoredProcedure [dbo].[EditCategory]    Script Date: 6/16/2025 12:18:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create Procedure [dbo].[EditCategory]
@NameOfCategory NVARCHAR(100),
@Description NVARCHAR(500),
@CategoryID INT
As
BEGIN
 UPDATE Category
 SET 
  NameofCategory=@NameofCategory,
  Description=@Description
  WHERE
  CategoryID=@CategoryID
END;
GO
/****** Object:  StoredProcedure [dbo].[EditFlower]    Script Date: 6/16/2025 12:18:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create Procedure [dbo].[EditFlower]
@FlowerID INT,
@Name NVARCHAR(100),
@CategoryID INT,
@Price DECIMAL(10,2),
@Color NVARCHAR(50)
As
BEGIN
 UPDATE Flower
 SET 
  Name=@Name,
  CategoryID=@CategoryID,
  Price=@Price,
  Color=@Color
  WHERE
  FlowerID=@FlowerID
END;
GO
/****** Object:  StoredProcedure [dbo].[GetAllCategories]    Script Date: 6/16/2025 12:18:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create Procedure [dbo].[GetAllCategories]
As
BEGIN
SELECT *
FROM Category
END;
GO
/****** Object:  StoredProcedure [dbo].[GetAllFlowersOfCategory]    Script Date: 6/16/2025 12:18:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create Procedure [dbo].[GetAllFlowersOfCategory]
 @CategoryID INT
 AS
 BEGIN
 SELECT *
 FROM Flower
 WHERE @CategoryID=CategoryID
 END;
GO
/****** Object:  StoredProcedure [dbo].[GetCategory]    Script Date: 6/16/2025 12:18:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create Procedure [dbo].[GetCategory]
@CategoryID INT
AS
BEGIN
SELECT *
FROM Category
WHERE @CategoryID=CategoryID
END
GO
/****** Object:  StoredProcedure [dbo].[GetFlower]    Script Date: 6/16/2025 12:18:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create Procedure [dbo].[GetFlower]
@FlowerID INT
AS
BEGIN
Select *
FROM Flower
WHERE @FlowerID=FlowerID
END;
GO
/****** Object:  StoredProcedure [dbo].[SearchCategoryByName]    Script Date: 6/16/2025 12:18:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
  Create procedure [dbo].[SearchCategoryByName]
 @Name NVARCHAR(100)
 AS
 BEGIN
 SELECT *
 FROM Category
 WHERE NameOfCategory  LIKE '%' + @Name + '%'
 END;
GO
/****** Object:  StoredProcedure [dbo].[SearchFlowerByName]    Script Date: 6/16/2025 12:18:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
 Create procedure [dbo].[SearchFlowerByName]
 @Name NVARCHAR(100)
 AS
 BEGIN
 SELECT *
 FROM Flower
 WHERE Name  LIKE '%' + @Name + '%'
 END;
GO
/****** Object:  StoredProcedure [dbo].[SortAscCategories]    Script Date: 6/16/2025 12:18:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create Procedure [dbo].[SortAscCategories]
 As
 Begin
 Select *
 From Category
 ORDER BY NameOfCategory ASC
 END
GO
/****** Object:  StoredProcedure [dbo].[SortAscNameFlowers]    Script Date: 6/16/2025 12:18:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
 CREATE Procedure [dbo].[SortAscNameFlowers]
   @CategoryID INT
 As
 Begin
 Select *
 From Flower
 Where @CategoryID=CategoryID
 ORDER BY Name Asc
 END
GO
/****** Object:  StoredProcedure [dbo].[SortAscPriceFlowers]    Script Date: 6/16/2025 12:18:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[SortAscPriceFlowers]
@CategoryID INT
 As
 Begin
 Select *
 From Flower
 Where @CategoryID=CategoryID
 ORDER BY Price Asc
 END
GO
/****** Object:  StoredProcedure [dbo].[SortDescCategories]    Script Date: 6/16/2025 12:18:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
 Create Procedure [dbo].[SortDescCategories]
 As
 Begin
 Select *
 From Category
 ORDER BY NameOfCategory DESC
 END
GO
/****** Object:  StoredProcedure [dbo].[SortDescNameFlowers]    Script Date: 6/16/2025 12:18:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[SortDescNameFlowers]
  @CategoryID INT
 As
 Begin
 Select *
 From Flower
  Where @CategoryID=CategoryID
 ORDER BY Name DESC
 END
GO
/****** Object:  StoredProcedure [dbo].[SortDescPriceFlowers]    Script Date: 6/16/2025 12:18:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[SortDescPriceFlowers]
@CategoryID INT
 As
 Begin
 Select *
 From Flower
 Where @CategoryID=CategoryID
 ORDER BY Price DESC
 END
GO
USE [master]
GO
ALTER DATABASE [FlowerInventoryAssessment] SET  READ_WRITE 
GO
