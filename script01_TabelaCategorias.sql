IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;
GO

BEGIN TRANSACTION;
GO

CREATE TABLE [Categorias] (
    [Id] int NOT NULL IDENTITY,
    [Nome] nvarchar(max) NOT NULL,
    [CorBackground] int NOT NULL,
    CONSTRAINT [PK_Categorias] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [Imagem] (
    [Id] int NOT NULL IDENTITY,
    [Nome] nvarchar(max) NOT NULL,
    [CorBackground] nvarchar(max) NOT NULL,
    [CategoriaId] int NULL,
    CONSTRAINT [PK_Imagem] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Imagem_Categorias_CategoriaId] FOREIGN KEY ([CategoriaId]) REFERENCES [Categorias] ([Id])
);
GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'CorBackground', N'Nome') AND [object_id] = OBJECT_ID(N'[Categorias]'))
    SET IDENTITY_INSERT [Categorias] ON;
INSERT INTO [Categorias] ([Id], [CorBackground], [Nome])
VALUES (1, 3, N'Social'),
(2, 2, N'Roupas');
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'CorBackground', N'Nome') AND [object_id] = OBJECT_ID(N'[Categorias]'))
    SET IDENTITY_INSERT [Categorias] OFF;
GO

CREATE INDEX [IX_Imagem_CategoriaId] ON [Imagem] ([CategoriaId]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20250221112153_InicialCreate', N'8.0.8');
GO

COMMIT;
GO

