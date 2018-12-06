CREATE TABLE [dbo].[Livre]
(
	[Id] INT NOT NULL IDENTITY(1,1) PRIMARY KEY, 
    [Titre] NVARCHAR(100) NULL, 
    [Description] NVARCHAR(250) NULL, 
    [DateSortie] DATE NULL, 
    [IdAuteur] INT NULL, 
    [IdGenre] INT NULL, 
    CONSTRAINT [FK_Livre_ToTable] FOREIGN KEY ([IdAuteur]) REFERENCES [Auteur]([Id]), 
    CONSTRAINT [FK_Livre_ToTable_1] FOREIGN KEY ([IdGenre]) REFERENCES [Genre]([Id])
)
