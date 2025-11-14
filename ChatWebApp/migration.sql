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

CREATE TABLE [Messages] (
    [Id] int NOT NULL IDENTITY,
    [User] nvarchar(max) NOT NULL,
    [Text] nvarchar(max) NOT NULL,
    [CreatedAt] datetime2 NOT NULL,
    [SentimentScore] float NULL,
    [Sentiment] int NOT NULL,
    CONSTRAINT [PK_Messages] PRIMARY KEY ([Id])
);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20251114151822_InitialCreate', N'8.0.10');
GO

COMMIT;
GO

