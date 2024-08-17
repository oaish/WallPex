CREATE PROCEDURE [dbo].[spCollectionItems_Create]
    @ItemId INT,
    @ItemUrl VARCHAR(MAX),
    @CollectionId INT
AS
BEGIN
    INSERT INTO CollectionItems (ItemId, ItemUrl, CollectionId)
    VALUES (@ItemId, @ItemUrl, @CollectionId);
END
