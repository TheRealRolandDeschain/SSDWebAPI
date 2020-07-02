CREATE PROCEDURE [dbo].[spDeleteLocationByName]
    @Name NVARCHAR(50)
AS
    DELETE FROM dbo.Locations
    WHERE Name = @Name
RETURN @@RowCount