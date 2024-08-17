CREATE PROCEDURE [dbo].[spCollectionItems_Create]
    @ImageId INT,
    @ImageUrl VARCHAR(MAX),
    @CollectionId INT
AS
BEGIN
    INSERT INTO CollectionItems (ImageId, ImageUrl, CollectionId)
    VALUES (@ImageId, @ImageUrl, @CollectionId);
END
