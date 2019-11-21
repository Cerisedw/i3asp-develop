CREATE TABLE [dbo].[CrewMovie]
(
	[IdMovie] INT NOT NULL ,
	IdCrew int NOT NULL, 
    CONSTRAINT [PK_CrewMovie] PRIMARY KEY ([IdMovie], IdCrew) ,
	CONSTRAINT [FK_CrewMovie_ToMovie] FOREIGN KEY (IdMovie) REFERENCES [Movie](IdMovie),
	CONSTRAINT [FK_CrewMovie_ToCrew] FOREIGN KEY (IdCrew) REFERENCES Crew(IdCrew)
)
