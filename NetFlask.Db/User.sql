CREATE TABLE [dbo].[User]
(
	[IdUser] INT NOT NULL identity(1,1) PRIMARY KEY,
	FirstName nvarchar(50) not null,
	LastName nvarchar(50) not null
)
