﻿USE [master]
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
