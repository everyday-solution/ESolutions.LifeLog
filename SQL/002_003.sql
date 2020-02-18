use [esolutions.livelog]
go

begin transaction updatedb_003


/****** Object:  Table [dbo].[Manufacturers]    Script Date: 04/12/2010 20:02:45 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Manufacturers](
	[Guid] [uniqueidentifier] ROWGUIDCOL  NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_Manufacturers] PRIMARY KEY CLUSTERED 
(
	[Guid] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[Manufacturers] ADD  CONSTRAINT [DF_Manufacturers_Guid]  DEFAULT (newid()) FOR [Guid]
GO

USE [ESolutions.LiveLog]
GO

/****** Object:  Table [dbo].[Aliment]    Script Date: 04/12/2010 20:57:46 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Aliment](
	[Guid] [uniqueidentifier] ROWGUIDCOL  NOT NULL,
	[ManufacturerGuid] [uniqueidentifier] NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[PackageSize] [float] NOT NULL,
	[CalorificValueKJ] [float] NOT NULL,
	[CalorificValueKCAL] [float] NOT NULL,
	[Protein] [float] NOT NULL,
	[Carbohydrates] [float] NOT NULL,
	[Fat] [float] NOT NULL,
 CONSTRAINT [PK_Aliment] PRIMARY KEY CLUSTERED 
(
	[Guid] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[Aliment] ADD  CONSTRAINT [DF_Aliment_Guid]  DEFAULT (newid()) FOR [Guid]
GO


USE [ESolutions.LiveLog]
GO

/****** Object:  Table [dbo].[Ingestions]    Script Date: 04/12/2010 22:15:20 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Ingestions](
	[Guid] [uniqueidentifier] ROWGUIDCOL  NOT NULL,
	[UserGuid] [uniqueidentifier] NOT NULL,
	[Timestamp] [datetime] NOT NULL,
	[AlimentGuid] [uniqueidentifier] NOT NULL,
	[Amount] [float] NOT NULL,
 CONSTRAINT [PK_Ingestions] PRIMARY KEY CLUSTERED 
(
	[Guid] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[Ingestions] ADD  CONSTRAINT [DF_Ingestions_Guid]  DEFAULT (newid()) FOR [Guid]
GO



commit transaction updatedb_003