CREATE TABLE [dbo].[Member]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Name] NVARCHAR(30) NULL, 
    [Email] VARCHAR(50) NULL, 
    [Gender] CHAR NULL, 
    [Account] NVARCHAR(30) NULL, 
    [PassWord] NVARCHAR(30) NULL
)
