CREATE PROCEDURE [dbo].[spGetLocationsByArea]
    @LongLeft FLOAT, 
    @LongRight FLOAT, 
    @LatTop FLOAT, 
    @LatBottom FLOAT
AS
BEGIN
    SELECT Locations.Name, UserName, Description, longitude, latitude, CelestialBodies.Name AS CelestialBody_Name, CelestialBodies.Type AS CelestialBody_Type, CelestialBodies.ImageUrl AS CelestialBody_ImageUrl
    FROM dbo.Locations 
    INNER JOIN dbo.Users ON Users.Id = UserID
    INNER JOIN dbo.CelestialBodies ON CelestialBodies.Id = CelestialBodyID
    WHERE latitude <=  @LatTop AND latitude >= @LatBottom AND longitude >= @LongLeft AND longitude <= @LongRight
END
