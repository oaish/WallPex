CREATE PROCEDURE [dbo].[spCollections_CreateWithItem]
    @CollectionName VARCHAR(256),
    @CollectionType BIT,
    @UserId VARCHAR(450),
    @ItemId INT,
    @ItemUrl VARCHAR(MAX)
AS
BEGIN
    -- Insert a new record into the Collections table
    INSERT INTO [dbo].[Collections] ([CollectionName], [CollectionType], [UserId])
    VALUES (@CollectionName, @CollectionType, @UserId);

    -- Get the ID of the newly inserted collection
    DECLARE @NewCollectionId INT;
    SET @NewCollectionId = SCOPE_IDENTITY();

    -- Insert a new record into the CollectionItems table
    INSERT INTO [dbo].[CollectionItems] (ItemId, ItemUrl, CollectionId)
    VALUES (@ItemId, @ItemUrl, @NewCollectionId);
END
