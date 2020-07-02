CREATE TABLE [dbo].[Locations]
(
    [Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Name] NVARCHAR(50) NOT NULL,
    [UserID] INT NULL, 
    [Description] TEXT NULL, 
    [longitude] FLOAT NOT NULL, 
    [latitude] FLOAT NOT NULL, 
    [CelestialBodyID] INT NOT NULL, 
    CONSTRAINT [FK_Locations_Users] FOREIGN KEY (UserID) REFERENCES [Users]([Id]), 
    CONSTRAINT [FK_Locations_CelestialBodies] FOREIGN KEY ([CelestialBodyID]) REFERENCES [CelestialBodies]([Id])
)
