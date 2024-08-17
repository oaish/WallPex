CREATE PROCEDURE [dbo].[spCollectionItems_Delete]
    @CollectionItemId INT
AS
BEGIN
    DELETE FROM [dbo].[CollectionItems]
    WHERE [dbo].[CollectionItems].[Id] = @CollectionItemId;
END
