CREATE PROCEDURE [dbo].[spGetUserByUsername]
    @UserName NVARCHAR(50)
AS
BEGIN
    SELECT UserName, FirstName, LastName, Email 
    FROM dbo.Users 
    WHERE UserName = @UserName
END
