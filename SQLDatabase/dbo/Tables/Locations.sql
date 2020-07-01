CREATE TABLE [dbo].[Locations]
(
    [Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [UserID] INT NOT NULL, 
    [Description] TEXT NULL, 
    [longitude] FLOAT NOT NULL, 
    [latitude] FLOAT NOT NULL, 
    [CelestialBodyID] INT NOT NULL, 
    CONSTRAINT [FK_Locations_Users] FOREIGN KEY (UserID) REFERENCES [Users]([ID]), 
    CONSTRAINT [FK_Locations_CelestialBodies] FOREIGN KEY ([CelestialBodyID]) REFERENCES [CelestialBodies]([ID])
)
