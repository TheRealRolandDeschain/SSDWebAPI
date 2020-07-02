CREATE PROCEDURE [dbo].[spUpdateUserByUsername]
    @UserName NVARCHAR(50), 
    @FirstName NVARCHAR(50), 
    @LastName NVARCHAR(50), 
    @Email NVARCHAR(50), 
    @PasswordHash NVARCHAR(128),
    @PasswordSalt binary(16)
AS
    UPDATE dbo.Users
    SET UserName = @UserName, FirstName = @FirstName, LastName = @LastName, Email = @Email, PasswordHash = @PasswordHash, PasswordSalt = @PasswordSalt
    WHERE UserName = @UserName;
RETURN @@RowCount
