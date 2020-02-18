use [esolutions.livelog]

alter table BodyMeasures add LeftUpperArm float not null default 0
alter table BodyMeasures add RightUpperArm float not null default 0
alter table BodyMeasures add LeftUpperLeg float not null default 0
alter table BodyMeasures add RightUpperLeg float not null default 0

CREATE TABLE [dbo].[Pictures](
	[Guid] [uniqueidentifier] NOT NULL,
	[Data] [varbinary](max) NOT NULL,
 CONSTRAINT [PK_Pictures] PRIMARY KEY CLUSTERED 
(
	[Guid] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[BodyMeasurePictures](
	[Guid] [uniqueidentifier] NOT NULL,
	[BodyMeasureGuid] [uniqueidentifier] NOT NULL,
	[PictureGuid] [uniqueidentifier] NOT NULL,
	[SortOrder] [int] NOT NULL,
 CONSTRAINT [PK_BodyMeasurePictures] PRIMARY KEY CLUSTERED 
(
	[Guid] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[BodyMeasurePictures]  WITH CHECK ADD  CONSTRAINT [FK_BodyMeasurePictures_BodyMeasures] FOREIGN KEY([BodyMeasureGuid])
REFERENCES [dbo].[BodyMeasures] ([Guid])
GO

ALTER TABLE [dbo].[BodyMeasurePictures] CHECK CONSTRAINT [FK_BodyMeasurePictures_BodyMeasures]
GO

ALTER TABLE [dbo].[BodyMeasurePictures]  WITH CHECK ADD  CONSTRAINT [FK_BodyMeasurePictures_Pictures] FOREIGN KEY([PictureGuid])
REFERENCES [dbo].[Pictures] ([Guid])
GO

ALTER TABLE [dbo].[BodyMeasurePictures] CHECK CONSTRAINT [FK_BodyMeasurePictures_Pictures]
GO

DROP TABLE Ingestions
GO
drop table aliment
go
drop table manufacturers
go

CREATE TABLE [dbo].[Ingestions](
	[Guid] [uniqueidentifier] NOT NULL,
	[UserGuid] [uniqueidentifier] NOT NULL,
	[Date] [datetime] NOT NULL,
	[PictureGuid] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_Ingestions] PRIMARY KEY CLUSTERED 
(
	[Guid] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[Ingestions]  WITH CHECK ADD  CONSTRAINT [FK_Ingestions_Pictures] FOREIGN KEY([PictureGuid])
REFERENCES [dbo].[Pictures] ([Guid])
GO

ALTER TABLE [dbo].[Ingestions] CHECK CONSTRAINT [FK_Ingestions_Pictures]
GO

ALTER TABLE [dbo].[Ingestions]  WITH CHECK ADD  CONSTRAINT [FK_Ingestions_Users] FOREIGN KEY([UserGuid])
REFERENCES [dbo].[Users] ([Guid])
GO

ALTER TABLE [dbo].[Ingestions] CHECK CONSTRAINT [FK_Ingestions_Users]
GO


