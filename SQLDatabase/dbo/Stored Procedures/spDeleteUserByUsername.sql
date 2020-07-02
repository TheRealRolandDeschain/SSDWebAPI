CREATE PROCEDURE [dbo].[spDeleteUserByUsername]
    @UserName NVARCHAR(50)

AS
BEGIN
    UPDATE dbo.Locations
    SET UserID = NULL
    WHERE UserID = (SELECT Id FROM dbo.Users WHERE UserName = @UserName)
END
    DELETE FROM dbo.Users
    WHERE UserName = @UserName
RETURN @@RowCount