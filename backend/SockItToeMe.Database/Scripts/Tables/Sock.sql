IF NOT EXISTS(SELECT 1 FROM [dbo].[Sock])
CREATE TABLE [dbo].[Sock](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Description] [varchar](500) NULL,
	[Colour] [nvarchar](25) NULL,
	[Size] [int] NULL,
	[Thickness] [nvarchar](10) NULL,
	[Material] [nvarchar](25) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
