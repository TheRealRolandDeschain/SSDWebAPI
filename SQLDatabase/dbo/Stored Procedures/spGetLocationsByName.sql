CREATE PROCEDURE [dbo].[spGetLocationsByName]
    @Name NVARCHAR(50)

AS
BEGIN
    SELECT Locations.Name, UserName, Description, longitude, latitude, CelestialBodies.Name AS CelestialBody_Name, CelestialBodies.Type AS CelestialBody_Type, CelestialBodies.ImageUrl AS CelestialBody_ImageUrl
    FROM dbo.Locations 
    INNER JOIN dbo.Users ON Users.Id = UserID
    INNER JOIN dbo.CelestialBodies ON CelestialBodies.Id = CelestialBodyID
    WHERE Locations.Name = @Name
END
