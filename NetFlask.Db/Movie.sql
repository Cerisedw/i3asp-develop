CREATE TABLE [dbo].[Movie]
(
	[IdMovie] INT NOT NULL PRIMARY KEY ,
	Title nvarchar(250) NOT NULL,
	Duration int NOT NULL,
	Picture nvarchar(250) NOT NULL,
	Trailer nvarchar(250) NOT NULL,
	ReleaseDate Date NULL,
	Summary nvarchar(MAX) NOT NULL,
	ShortDescription nvarchar(150) NOT NULL 
)
