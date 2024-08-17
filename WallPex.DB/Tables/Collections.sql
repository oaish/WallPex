CREATE TABLE [dbo].[Collections]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [CollectionName] NCHAR(256) NOT NULL, 
    [CollectionType] BIT NULL,
    [UserId] NVARCHAR(450) NOT NULL
)
