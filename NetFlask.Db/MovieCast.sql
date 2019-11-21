CREATE TABLE [dbo].[MovieCast]
(
	[IdCast] INT NOT NULL ,
	idMovie int not null, 
    CONSTRAINT [PK_MovieCast] PRIMARY KEY ([IdCast], [idMovie]),
	CONSTRAINT [FK_MovieCast_ToMovie] FOREIGN KEY (IdMovie) REFERENCES [Movie](IdMovie),
	CONSTRAINT [FK_MovieCast_ToCast] FOREIGN KEY (IdCast) REFERENCES [Cast](IdCast)
)
