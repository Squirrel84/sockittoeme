GO
SET ANSI_NULLS, ANSI_PADDING, ANSI_WARNINGS, ARITHABORT, CONCAT_NULL_YIELDS_NULL, QUOTED_IDENTIFIER ON;

SET NUMERIC_ROUNDABORT OFF;

USE [SockItToeMe];


GO
IF EXISTS (SELECT 1
           FROM   [master].[dbo].[sysdatabases]
           WHERE  [name] = N'SockItToeMe')
    BEGIN
        ALTER DATABASE [SockItToeMe]
            SET QUERY_STORE (CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 367)) 
            WITH ROLLBACK IMMEDIATE;
    END


GO
USE [master]
GO
CREATE LOGIN [SockItLogin] WITH PASSWORD=N'sockIt123', DEFAULT_DATABASE=[SockItToeMe], CHECK_EXPIRATION=OFF, CHECK_POLICY=OFF
GO
USE [SockItToeMe]
GO
CREATE USER [SockItLogin] FOR LOGIN [SockItLogin]
GO
USE [SockItToeMe]
GO
ALTER ROLE [db_datareader] ADD MEMBER [SockItLogin]
GO
USE [SockItToeMe]
GO
ALTER ROLE [db_datawriter] ADD MEMBER [SockItLogin]
GO

GO
PRINT N'Creating [dbo].[Material]...';


GO
CREATE TABLE [dbo].[Material] (
    [Id]   INT           NOT NULL,
    [Description] NVARCHAR (25) NOT NULL,
    CONSTRAINT [PK_MaterialId] PRIMARY KEY CLUSTERED ([Id] ASC) ON [PRIMARY]
) ON [PRIMARY];


GO
PRINT N'Creating [dbo].[Size]...';


GO
CREATE TABLE [dbo].[Size] (
    [Id]   INT           NOT NULL,
    [Description] NVARCHAR (25) NOT NULL,
    CONSTRAINT [PK_SizeId] PRIMARY KEY CLUSTERED ([Id] ASC) ON [PRIMARY]
) ON [PRIMARY];


GO
PRINT N'Creating [dbo].[Sock]...';


GO
CREATE TABLE [dbo].[Sock] (
    [Id]          INT           IDENTITY (1, 1) NOT NULL,
    [Description] VARCHAR (500) NULL,
    [Colour]      VARCHAR (9)   NULL,
    [SizeId]      INT           NULL,
    [ThicknessId] INT           NULL,
    [MaterialId]  INT           NULL,
    CONSTRAINT [PK_SockId] PRIMARY KEY CLUSTERED ([Id] ASC) ON [PRIMARY]
) ON [PRIMARY];


GO
PRINT N'Creating [dbo].[Thickness]...';


GO
CREATE TABLE [dbo].[Thickness] (
    [Id]   INT           NOT NULL,
    [Description] NVARCHAR (25) NOT NULL,
    CONSTRAINT [PK_ThicknessId] PRIMARY KEY CLUSTERED ([Id] ASC) ON [PRIMARY]
) ON [PRIMARY];


GO
PRINT N'Update complete.';


GO
