CREATE TABLE [dbo].[Utilisateur]
(
	[Id] INT NOT NULL IDENTITY(1,1) PRIMARY KEY, 
    [NomUtilisateur] NVARCHAR(50) NULL, 
    [MotDePasse] NVARCHAR(250) NULL
)
