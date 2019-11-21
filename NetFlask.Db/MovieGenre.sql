CREATE TABLE [dbo].[MovieGenre]
(
	[IdMovie] INT NOT NULL,
	IdGenre int NOT NULL, 
    CONSTRAINT [PK_MovieGenre] PRIMARY KEY ([IdMovie], [IdGenre]), 
    CONSTRAINT [FK_MovieGenre_ToMovie] FOREIGN KEY (IdMovie) REFERENCES [Movie](IdMovie),
	CONSTRAINT [FK_MovieGenre_ToGenre] FOREIGN KEY (IdGenre) REFERENCES [Genre](IdGenre)
)
