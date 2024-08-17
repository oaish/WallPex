CREATE PROCEDURE [dbo].[spCollections_Delete]
    @CollectionId VARCHAR(450)
AS
BEGIN
    DELETE FROM [dbo].[Collections] 
    WHERE [dbo].[Collections].[Id] = @CollectionId;
END
