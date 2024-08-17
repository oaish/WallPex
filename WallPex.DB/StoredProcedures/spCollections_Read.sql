CREATE PROCEDURE [dbo].[spCollections_Read]
    @UserId VARCHAR(450)
AS
BEGIN
    SELECT 
        [C].[Id], 
        [C].[CollectionName], 
        [C].[CollectionType], 
        [C].[UserId], 
        (
            SELECT TOP 1 [CI].[ImageUrl] 
            FROM [dbo].[CollectionItems] CI 
            WHERE CI.CollectionId = C.Id 
        ) AS ImageUrl
    FROM 
        [dbo].[Collections] C
    WHERE 
        C.UserId = @UserId;
END
