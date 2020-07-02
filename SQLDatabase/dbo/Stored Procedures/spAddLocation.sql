CREATE PROCEDURE [dbo].[spAddLocation]
    @UserName nvarchar(50), 
    @Name nvarchar(50), 
    @Description TEXT, 
    @Longitude FLOAT, 
    @Latitude FLOAT, 
    @CelestialBody_Name NVARCHAR(50), 
    @CelestialBody_Type NVARCHAR(50), 
    @CelestialBody_ImageUrl NVARCHAR(100)
AS
BEGIN
    IF NOT EXISTS(SELECT Name FROM dbo.CelestialBodies WHERE Name = @CelestialBody_Name)
        INSERT INTO dbo.CelestialBodies
        VALUES (@CelestialBody_Name, @CelestialBody_Type, @CelestialBody_ImageUrl)
END
BEGIN
    IF NOT EXISTS(SELECT Name FROM dbo.Locations WHERE Name = @Name)
        INSERT INTO dbo.Locations
        VALUES (@Name, (SELECT Id FROM dbo.Users WHERE UserName = @UserName), @Description, @Longitude, @Latitude, (SELECT Id FROM dbo.CelestialBodies WHERE Name = @CelestialBody_Name))
END
RETURN 0
