USE [master]
GO
/****** Object:  Database [MyNotes]    Script Date: 6/2/2020 18:49:48 ******/
CREATE DATABASE [MyNotes]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'MyNotes', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\MyNotes.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'MyNotes_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\MyNotes_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [MyNotes] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [MyNotes].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [MyNotes] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [MyNotes] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [MyNotes] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [MyNotes] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [MyNotes] SET ARITHABORT OFF 
GO
ALTER DATABASE [MyNotes] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [MyNotes] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [MyNotes] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [MyNotes] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [MyNotes] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [MyNotes] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [MyNotes] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [MyNotes] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [MyNotes] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [MyNotes] SET  DISABLE_BROKER 
GO
ALTER DATABASE [MyNotes] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [MyNotes] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [MyNotes] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [MyNotes] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [MyNotes] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [MyNotes] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [MyNotes] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [MyNotes] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [MyNotes] SET  MULTI_USER 
GO
ALTER DATABASE [MyNotes] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [MyNotes] SET DB_CHAINING OFF 
GO
ALTER DATABASE [MyNotes] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [MyNotes] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [MyNotes] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [MyNotes] SET QUERY_STORE = OFF
GO
USE [MyNotes]
GO
/****** Object:  Table [dbo].[Notes]    Script Date: 6/2/2020 18:49:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Notes](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[UserID] [int] NOT NULL,
	[Title] [varchar](50) NOT NULL,
	[Category] [varchar](50) NOT NULL,
	[NoteDescription] [varchar](1500) NOT NULL,
	[Importance] [varchar](15) NOT NULL,
	[DateCreated] [datetime] NOT NULL,
	[Favorite] [int] NOT NULL,
	[Active] [int] NOT NULL,
 CONSTRAINT [PK_Notes] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 6/2/2020 18:49:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Username] [varchar](50) NOT NULL,
	[Password] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  StoredProcedure [dbo].[usp_Data_BringUserID]    Script Date: 6/2/2020 18:49:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_Data_BringUserID]

	@Username varchar(50)

AS
BEGIN

SELECT ID FROM Users WHERE Username = @Username

END
GO
/****** Object:  StoredProcedure [dbo].[usp_Data_CreateNote]    Script Date: 6/2/2020 18:49:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_Data_CreateNote]
	
	@UserID int,
	@Title varchar (50),
	@Category varchar(50),
	@NoteDescription varchar(1500),
	@Importance varchar(15),
	@ActualDate datetime,
	@Favorite int

AS
BEGIN

	INSERT INTO Notes (UserID, Title, Category, NoteDescription, Importance, DateCreated, Favorite, Active)
	VALUES (@UserID, @Title, @Category, @NoteDescription, @Importance, @ActualDate, @Favorite, '1')

	SELECT @@IDENTITY AS ID
END
GO
/****** Object:  StoredProcedure [dbo].[usp_Data_CreateUser]    Script Date: 6/2/2020 18:49:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_Data_CreateUser]
	
	@Username varchar(75),
	@Password varchar(40)

AS
BEGIN

	INSERT INTO Users (Username, Password)
	VALUES (@Username, @Password)

	SELECT @@IDENTITY AS ID
END
GO
/****** Object:  StoredProcedure [dbo].[usp_Data_DeleteNote]    Script Date: 6/2/2020 18:49:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[usp_Data_DeleteNote]

	@NoteID int

AS
BEGIN
	
	UPDATE Notes SET Active = 0 WHERE ID = @NoteID

	SELECT @@ROWCOUNT AS RowsAffected

END
GO
/****** Object:  StoredProcedure [dbo].[usp_Data_GetAllDeletedNotes]    Script Date: 6/2/2020 18:49:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_Data_GetAllDeletedNotes]
	
	@UserID int

AS 
BEGIN 

	SELECT ID, Title, Category, NoteDescription, Importance, DateCreated
	FROM Notes
	WHERE ((Active = 0) AND (UserID = @UserID))

END
GO
/****** Object:  StoredProcedure [dbo].[usp_Data_GetAllFavoriteNotes]    Script Date: 6/2/2020 18:49:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_Data_GetAllFavoriteNotes]
	
	@UserID int

AS 
BEGIN 

	SELECT ID, Title, Category, NoteDescription, Importance, DateCreated
	FROM Notes
	WHERE ((Active = 1) AND (UserID = @UserID) AND (Favorite = 1))

END
GO
/****** Object:  StoredProcedure [dbo].[usp_Data_GetAllNotes]    Script Date: 6/2/2020 18:49:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_Data_GetAllNotes]
	
	@UserID int

AS 
BEGIN 

	SELECT ID, Title, Category, NoteDescription, Importance, DateCreated
	FROM Notes
	WHERE ((Active = 1) AND UserID = @UserID)

END
GO
/****** Object:  StoredProcedure [dbo].[usp_Data_GetTotalDeletedNotes]    Script Date: 6/2/2020 18:49:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_Data_GetTotalDeletedNotes]

	@UserID int

AS
BEGIN

	SELECT SUM(1) FROM Notes WHERE ((Active = 0) AND (UserID = @UserID))

-- Esto está en prueba, realmente no sé si funciona bien.
--SELECT max(ID) FROM Notes WHERE ((Active = 1) AND (UserID = @UserID))

--SELECT Id FROM Notes WHERE ((Id = (SELECT max(Id) FROM Notes) AND Active = 0) AND Active = 0)

END

GO
/****** Object:  StoredProcedure [dbo].[usp_Data_GetTotalFavoriteNotes]    Script Date: 6/2/2020 18:49:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_Data_GetTotalFavoriteNotes]

	@UserID int

AS
BEGIN

	SELECT SUM(1) FROM Notes WHERE ((Active = 1) AND (UserID = @UserID) AND (Favorite = 1))

-- Esto está en prueba, realmente no sé si funciona bien.
--SELECT max(ID) FROM Notes WHERE ((Active = 1) AND (UserID = @UserID))

--SELECT Id FROM Notes WHERE ((Id = (SELECT max(Id) FROM Notes) AND Active = 1) AND Active = 1)

END

GO
/****** Object:  StoredProcedure [dbo].[usp_Data_GetTotalNotes]    Script Date: 6/2/2020 18:49:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_Data_GetTotalNotes]

	@UserID int

AS
BEGIN

	SELECT SUM(1) FROM Notes WHERE ((Active = 1) AND (UserID = @UserID))

-- Esto está en prueba, realmente no sé si funciona bien.
--SELECT max(ID) FROM Notes WHERE ((Active = 1) AND (UserID = @UserID))

--SELECT Id FROM Notes WHERE ((Id = (SELECT max(Id) FROM Notes) AND Active = 1) AND Active = 1)

END

GO
/****** Object:  StoredProcedure [dbo].[usp_Data_GetTotalUsersCreated]    Script Date: 6/2/2020 18:49:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_Data_GetTotalUsersCreated]

AS
BEGIN

	SELECT SUM(1) FROM Users

-- Esto está en prueba, realmente no sé si funciona bien.
--SELECT max(ID) FROM Notes WHERE ((Active = 1) AND (UserID = @UserID))

--SELECT Id FROM Notes WHERE ((Id = (SELECT max(Id) FROM Notes) AND Active = 0) AND Active = 0)

END

GO
/****** Object:  StoredProcedure [dbo].[usp_Data_IsFavorite]    Script Date: 6/2/2020 18:49:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_Data_IsFavorite]

	@NoteID int

AS
BEGIN

	SELECT ID FROM Notes WHERE ((ID = @NoteID) AND (Favorite = 1))
	SELECT @@IDENTITY
END
GO
/****** Object:  StoredProcedure [dbo].[usp_Data_LoadDeletedNotesByPage]    Script Date: 6/2/2020 18:49:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_Data_LoadDeletedNotesByPage]

	@UserID int,
	@ActualPage int

AS 
BEGIN

	SELECT ID, Title, Category, NoteDescription, Importance, DateCreated
	FROM Notes
	WHERE ((Active = 0) AND (UserID = @UserID))
	ORDER BY ID
	OFFSET (@ActualPage - 1) * 100 ROWS
	FETCH NEXT 100 ROWS ONLY

END
GO
/****** Object:  StoredProcedure [dbo].[usp_Data_LoadFavoriteNotesByPage]    Script Date: 6/2/2020 18:49:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_Data_LoadFavoriteNotesByPage]

	@UserID int,
	@ActualPage int

AS 
BEGIN

	SELECT ID, Title, Category, NoteDescription, Importance, DateCreated
	FROM Notes
	WHERE ((Active = 1) AND (UserID = @UserID) AND (Favorite = 1))
	ORDER BY ID
	OFFSET (@ActualPage - 1) * 100 ROWS
	FETCH NEXT 100 ROWS ONLY

END
GO
/****** Object:  StoredProcedure [dbo].[usp_Data_LoadNotesByPage]    Script Date: 6/2/2020 18:49:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_Data_LoadNotesByPage]

	@UserID int,
	@ActualPage int

AS 
BEGIN

	SELECT ID, Title, Category, NoteDescription, Importance, DateCreated
	FROM Notes
	WHERE ((Active = 1) AND (UserID = @UserID))
	ORDER BY ID
	OFFSET (@ActualPage - 1) * 100 ROWS
	FETCH NEXT 100 ROWS ONLY

END
GO
/****** Object:  StoredProcedure [dbo].[usp_Data_ModifyNote]    Script Date: 6/2/2020 18:49:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_Data_ModifyNote]
	
	@ID int,
	@Title varchar (50),
	@Category varchar(50),
	@NoteDescription varchar(1500),
	@Importance varchar(15),
	@Favorite int

AS
BEGIN

	UPDATE Notes SET
		Title=@Title,
		Category=@Category,
		NoteDescription=@NoteDescription,
		Importance=@Importance,
		Favorite=@Favorite
		WHERE ID = @ID

SELECT @@ROWCOUNT AS RowsAffected
END
GO
/****** Object:  StoredProcedure [dbo].[usp_Data_NotFavoriteAnymore]    Script Date: 6/2/2020 18:49:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[usp_Data_NotFavoriteAnymore]

	@NoteID int

AS
BEGIN
	
	UPDATE Notes SET Favorite = 0 WHERE ID = @NoteID

	SELECT @@ROWCOUNT AS RowsAffected

END
GO
/****** Object:  StoredProcedure [dbo].[usp_Data_RestoreNote]    Script Date: 6/2/2020 18:49:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_Data_RestoreNote]
	
	@NoteID int

AS
BEGIN

	UPDATE Notes SET Active = 1 WHERE ID = @NoteID

SELECT @@ROWCOUNT AS RowsAffected
END
GO
/****** Object:  StoredProcedure [dbo].[usp_Data_UserExists]    Script Date: 6/2/2020 18:49:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_Data_UserExists]

	@Username varchar(50)

AS
BEGIN

	SELECT ID FROM Users WHERE Username = @Username
	SELECT @@IDENTITY
END
GO
/****** Object:  StoredProcedure [dbo].[usp_Data_VerifyLogin]    Script Date: 6/2/2020 18:49:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_Data_VerifyLogin]

	@Username varchar(50),
	@Password varchar(50)

AS
BEGIN

	SELECT ID FROM Users WHERE ((Username = @Username) AND (Password = @Password))
	SELECT @@IDENTITY
END
GO
USE [master]
GO
ALTER DATABASE [MyNotes] SET  READ_WRITE 
GO
