CREATE PROCEDURE [dbo].[spCollections_ReadOne]
    @CollectionId INT
AS
BEGIN
    SELECT 
        [C].[Id], 
        [C].[CollectionName], 
        [C].[CollectionType], 
        [C].[UserId], 
        [CI].[ItemUrl]
    FROM 
        [dbo].[Collections] C
    LEFT JOIN 
        (SELECT 
             [CI].[CollectionId], 
             [CI].[ItemUrl],
             ROW_NUMBER() OVER (PARTITION BY [CI].[CollectionId] ORDER BY [CI].[ItemUrl] ASC) AS RowNum
         FROM [dbo].[CollectionItems] CI
        ) CI
    ON C.Id = CI.CollectionId AND CI.RowNum = 1
    WHERE 
        C.Id = @CollectionId;
END
