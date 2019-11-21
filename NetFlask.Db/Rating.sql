CREATE TABLE [dbo].[Rating]
(
	[IdMovie] INT NOT NULL , 
    [IdUser] INT NOT NULL, 
    [Score] FLOAT NOT NULL, 
    [DateRating] DATE NOT NULL, 
    CONSTRAINT [PK_Rating] PRIMARY KEY ([IdUser], [IdMovie]),
	CONSTRAINT [FK_Rating_ToMovie] FOREIGN KEY (IdMovie) REFERENCES [Movie](IdMovie),
	CONSTRAINT [FK_Rating_ToUser] FOREIGN KEY (IdUser) REFERENCES [User](IdUser)
)
