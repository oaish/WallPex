CREATE PROCEDURE [dbo].[spCollectionItems_ReadOne]
    @CollectionItemId INT
AS
BEGIN
    SELECT 
        [Id], [ItemId], [ItemUrl], [CollectionId]
    FROM 
        [dbo].[CollectionItems] 
    WHERE 
        [dbo].[CollectionItems].[Id] = @CollectionItemId;
END
