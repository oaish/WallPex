CREATE PROCEDURE [dbo].[spCollections_Create]
    @CollectionName VARCHAR(256),
    @CollectionType BIT,
    @UserId VARCHAR(450)
AS
BEGIN
    INSERT INTO [dbo].[Collections] ([CollectionName], [CollectionType], [UserId])
    VALUES (@CollectionName, @CollectionType, @UserId);
END
