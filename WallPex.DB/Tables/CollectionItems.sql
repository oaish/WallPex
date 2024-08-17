CREATE TABLE [dbo].[CollectionItems]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [ItemId] INT NULL, 
    [ItemUrl] VARCHAR(MAX) NULL, 
    [CollectionId] INT NULL, 
    CONSTRAINT [FK_CollectionItems_ToCollections] 
    FOREIGN KEY ([CollectionId]) 
    REFERENCES [Collections]([Id]) 
    ON DELETE CASCADE
)
