CREATE TABLE [dbo].[CollectionItems]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [ImageId] INT NULL, 
    [ImageUrl] VARCHAR(MAX) NULL, 
    [CollectionId] INT NULL, 
    CONSTRAINT [FK_CollectionItems_ToCollections] 
    FOREIGN KEY ([CollectionId]) 
    REFERENCES [Collections]([Id]) 
    ON DELETE CASCADE
)
