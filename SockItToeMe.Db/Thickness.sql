﻿CREATE TABLE [dbo].[Thickness]
(
	[Id] INT NOT NULL, 
    [Description] NVARCHAR(25) NOT NULL
		CONSTRAINT PK_ThicknessId 
PRIMARY KEY CLUSTERED
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
