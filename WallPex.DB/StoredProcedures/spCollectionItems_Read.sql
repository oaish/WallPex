CREATE PROCEDURE [dbo].[spCollectionItems_Read]
    @CollectionId INT
AS
BEGIN
    SELECT 
        [Id], [ImageId], [ImageUrl], [CollectionId]
    FROM 
        [dbo].[CollectionItems] 
    WHERE 
        [dbo].[CollectionItems].[CollectionId] = @CollectionId;
END
