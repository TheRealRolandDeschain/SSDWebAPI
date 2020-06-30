CREATE TABLE [dbo].[Users]
(
    [Id] INT NOT NULL PRIMARY KEY, 
    [UserID] INT NOT NULL, 
    [UserName] NVARCHAR(50) NULL, 
    [LastName] NVARCHAR(50) NULL, 
    [FirstName] NVARCHAR(50) NULL, 
    [Email] NVARCHAR(50) NULL
)
