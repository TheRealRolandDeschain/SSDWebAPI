CREATE PROCEDURE [dbo].spGetSaltByUserName
    @UserName nvarchar(50)
AS
BEGIN
    SELECT PasswordSalt
    FROM dbo.Users
    WHERE UserName = @UserName
END