CREATE PROCEDURE [dbo].[spCollectionItems_ReadMany]
    @CollectionId INT
AS
BEGIN
    SELECT 
        [Id], [ItemId], [ItemUrl], [CollectionId]
    FROM 
        [dbo].[CollectionItems] 
    WHERE 
        [dbo].[CollectionItems].[CollectionId] = @CollectionId;
END
