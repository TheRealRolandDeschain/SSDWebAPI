CREATE PROCEDURE [dbo].[spAddUser]
    @UserName NVARCHAR(50), 
    @FirstName NVARCHAR(50), 
    @LastName NVARCHAR(50), 
    @Email NVARCHAR(50), 
    @PasswordHash NVARCHAR(128),
    @PasswordSalt binary(16)
AS
    IF NOT EXISTS(SELECT UserName, FirstName, LastName FROM dbo.Users WHERE UserName = @UserName OR FirstName = @FirstName OR LastName = @LastName)
        INSERT INTO dbo.Users(UserName, FirstName, LastName, Email, PasswordHash, PasswordSalt) VALUES (@UserName, @FirstName, @LastName, @Email, @PasswordHash, @PasswordSalt)
RETURN @@RowCount
