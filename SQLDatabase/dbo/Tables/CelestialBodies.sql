CREATE TABLE [dbo].[CelestialBodies]
(
    [Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Name] NVARCHAR(50) NOT NULL, 
    [Type] NVARCHAR(50) NOT NULL, 
    [ImageUrl] NVARCHAR(100) NULL
)
