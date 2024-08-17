CREATE PROCEDURE [dbo].[spCollections_Update]
    @CollectionName VARCHAR(256),
    @CollectionId INT
AS
BEGIN
    UPDATE [dbo].[Collections]
    SET [dbo].[Collections].[CollectionName] = @CollectionName
    WHERE [dbo].[Collections].[Id] = @CollectionId
END
