CREATE TABLE [dbo].[Critics]
( 
	[IdMovie] int not null,
	IdCriticsAuthor int not null,
	Score Float not null, 
    PRIMARY KEY ([idCriticsAuthor], [IdMovie]),
	CONSTRAINT [FK_Critics_ToMovie] FOREIGN KEY (IdMovie) REFERENCES [Movie](IdMovie),
	CONSTRAINT [FK_Critics_ToCriticsAuthor] FOREIGN KEY (IdCriticsAuthor) REFERENCES CriticsAuthor(IdCriticsAuthor)
)
