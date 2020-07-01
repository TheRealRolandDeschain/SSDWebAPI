CREATE PROCEDURE [dbo].[spAuthorizeUser]
    @UserName nvarchar(50),
    @PasswordHash nvarchar(128)
AS
BEGIN
    SELECT UserName FROM dbo.Users WHERE UserName = @UserName AND PasswordHash = @PasswordHash
END
