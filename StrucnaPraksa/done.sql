IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200116153413_initialCommit')
BEGIN
    CREATE TABLE [Users] (
        [Id] int NOT NULL IDENTITY,
        [Username] nvarchar(max) NULL,
        [Password] nvarchar(max) NULL,
        [role] nvarchar(max) NULL,
        CONSTRAINT [PK_Users] PRIMARY KEY ([Id])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200116153413_initialCommit')
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Password', N'Username', N'role') AND [object_id] = OBJECT_ID(N'[Users]'))
        SET IDENTITY_INSERT [Users] ON;
    INSERT INTO [Users] ([Id], [Password], [Username], [role])
    VALUES (1, N'admin', N'fabijan', N'Admin');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Password', N'Username', N'role') AND [object_id] = OBJECT_ID(N'[Users]'))
        SET IDENTITY_INSERT [Users] OFF;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200116153413_initialCommit')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20200116153413_initialCommit', N'3.1.1');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200124233911_InitialCreate')
BEGIN
    EXEC sp_rename N'[Users].[role]', N'Role', N'COLUMN';
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200124233911_InitialCreate')
BEGIN
    ALTER TABLE [Users] ADD [Token] nvarchar(max) NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200124233911_InitialCreate')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20200124233911_InitialCreate', N'3.1.1');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200127194857_osnovniPodaci')
BEGIN
    CREATE TABLE [OsnovniPodaci] (
        [IdUsera] nvarchar(max) NULL,
        [Termin] datetime2 NOT NULL,
        [Poduzece] nvarchar(max) NULL,
        [NazivMentora] nvarchar(max) NULL
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200127194857_osnovniPodaci')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20200127194857_osnovniPodaci', N'3.1.1');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200127211255_osnovniPodaciIdPodataka')
BEGIN
    DECLARE @var0 sysname;
    SELECT @var0 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[OsnovniPodaci]') AND [c].[name] = N'Termin');
    IF @var0 IS NOT NULL EXEC(N'ALTER TABLE [OsnovniPodaci] DROP CONSTRAINT [' + @var0 + '];');
    ALTER TABLE [OsnovniPodaci] ALTER COLUMN [Termin] datetime2 NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200127211255_osnovniPodaciIdPodataka')
BEGIN
    ALTER TABLE [OsnovniPodaci] ADD [IdPodataka] nvarchar(max) NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200127211255_osnovniPodaciIdPodataka')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20200127211255_osnovniPodaciIdPodataka', N'3.1.1');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200522224531_dnevnikId')
BEGIN
    DECLARE @var1 sysname;
    SELECT @var1 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[OsnovniPodaci]') AND [c].[name] = N'IdPodataka');
    IF @var1 IS NOT NULL EXEC(N'ALTER TABLE [OsnovniPodaci] DROP CONSTRAINT [' + @var1 + '];');
    ALTER TABLE [OsnovniPodaci] ALTER COLUMN [IdPodataka] nvarchar(450) NOT NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200522224531_dnevnikId')
BEGIN
    ALTER TABLE [OsnovniPodaci] ADD CONSTRAINT [PK_OsnovniPodaci] PRIMARY KEY ([IdPodataka]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200522224531_dnevnikId')
BEGIN
    CREATE TABLE [Ankete] (
        [IdAnkete] nvarchar(450) NOT NULL,
        [IdUsera] nvarchar(max) NULL,
        [Godina] datetime2 NOT NULL,
        [Prvo] nvarchar(max) NULL,
        [Drugo] nvarchar(max) NULL,
        [Trece] nvarchar(max) NULL,
        [Cetvrto] nvarchar(max) NULL,
        [Peto] nvarchar(max) NULL,
        [Sesto] nvarchar(max) NULL,
        [Sedmo] nvarchar(max) NULL,
        [Osmo] nvarchar(max) NULL,
        [Deveto] nvarchar(max) NULL,
        [Deseto] nvarchar(max) NULL,
        [Jedanaesto] nvarchar(max) NULL,
        [Dvanaesto] nvarchar(max) NULL,
        CONSTRAINT [PK_Ankete] PRIMARY KEY ([IdAnkete])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200522224531_dnevnikId')
BEGIN
    CREATE TABLE [Dnevnici] (
        [IdDnevnika] nvarchar(450) NOT NULL,
        [IdUsera] nvarchar(max) NULL,
        [FileUrl] nvarchar(max) NULL,
        [Godina] datetime2 NOT NULL,
        CONSTRAINT [PK_Dnevnici] PRIMARY KEY ([IdDnevnika])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200522224531_dnevnikId')
BEGIN
    CREATE TABLE [Izvjesca] (
        [IdIzvjesca] nvarchar(450) NOT NULL,
        [IdUsera] nvarchar(max) NULL,
        [FileUrl] nvarchar(max) NULL,
        [Godina] datetime2 NOT NULL,
        CONSTRAINT [PK_Izvjesca] PRIMARY KEY ([IdIzvjesca])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200522224531_dnevnikId')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20200522224531_dnevnikId', N'3.1.1');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200524220101_anketaAddedKomentari')
BEGIN
    ALTER TABLE [Ankete] ADD [DesetoKomentar] nvarchar(max) NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200524220101_anketaAddedKomentari')
BEGIN
    ALTER TABLE [Ankete] ADD [SedmoKomentar] nvarchar(max) NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200524220101_anketaAddedKomentari')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20200524220101_anketaAddedKomentari', N'3.1.1');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200524223142_AnketaFixTypes')
BEGIN
    DECLARE @var2 sysname;
    SELECT @var2 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Ankete]') AND [c].[name] = N'Prvo');
    IF @var2 IS NOT NULL EXEC(N'ALTER TABLE [Ankete] DROP CONSTRAINT [' + @var2 + '];');
    ALTER TABLE [Ankete] ALTER COLUMN [Prvo] int NOT NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200524223142_AnketaFixTypes')
BEGIN
    DECLARE @var3 sysname;
    SELECT @var3 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Ankete]') AND [c].[name] = N'Drugo');
    IF @var3 IS NOT NULL EXEC(N'ALTER TABLE [Ankete] DROP CONSTRAINT [' + @var3 + '];');
    ALTER TABLE [Ankete] ALTER COLUMN [Drugo] int NOT NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200524223142_AnketaFixTypes')
BEGIN
    DECLARE @var4 sysname;
    SELECT @var4 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Ankete]') AND [c].[name] = N'Cetvrto');
    IF @var4 IS NOT NULL EXEC(N'ALTER TABLE [Ankete] DROP CONSTRAINT [' + @var4 + '];');
    ALTER TABLE [Ankete] ALTER COLUMN [Cetvrto] int NOT NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200524223142_AnketaFixTypes')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20200524223142_AnketaFixTypes', N'3.1.1');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200526154657_addedImePrezimeToUser')
BEGIN
    ALTER TABLE [Users] ADD [Ime] nvarchar(max) NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200526154657_addedImePrezimeToUser')
BEGIN
    ALTER TABLE [Users] ADD [Prezime] nvarchar(max) NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200526154657_addedImePrezimeToUser')
BEGIN
    UPDATE [Users] SET [Ime] = N'Fabijan', [Prezime] = N'Zulj'
    WHERE [Id] = 1;
    SELECT @@ROWCOUNT;

END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200526154657_addedImePrezimeToUser')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20200526154657_addedImePrezimeToUser', N'3.1.1');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200604133417_entitiesValidation')
BEGIN
    DECLARE @var5 sysname;
    SELECT @var5 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Users]') AND [c].[name] = N'Username');
    IF @var5 IS NOT NULL EXEC(N'ALTER TABLE [Users] DROP CONSTRAINT [' + @var5 + '];');
    ALTER TABLE [Users] ALTER COLUMN [Username] nvarchar(max) NOT NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200604133417_entitiesValidation')
BEGIN
    DECLARE @var6 sysname;
    SELECT @var6 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Users]') AND [c].[name] = N'Role');
    IF @var6 IS NOT NULL EXEC(N'ALTER TABLE [Users] DROP CONSTRAINT [' + @var6 + '];');
    ALTER TABLE [Users] ALTER COLUMN [Role] nvarchar(max) NOT NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200604133417_entitiesValidation')
BEGIN
    DECLARE @var7 sysname;
    SELECT @var7 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Users]') AND [c].[name] = N'Prezime');
    IF @var7 IS NOT NULL EXEC(N'ALTER TABLE [Users] DROP CONSTRAINT [' + @var7 + '];');
    ALTER TABLE [Users] ALTER COLUMN [Prezime] nvarchar(max) NOT NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200604133417_entitiesValidation')
BEGIN
    DECLARE @var8 sysname;
    SELECT @var8 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Users]') AND [c].[name] = N'Password');
    IF @var8 IS NOT NULL EXEC(N'ALTER TABLE [Users] DROP CONSTRAINT [' + @var8 + '];');
    ALTER TABLE [Users] ALTER COLUMN [Password] nvarchar(max) NOT NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200604133417_entitiesValidation')
BEGIN
    DECLARE @var9 sysname;
    SELECT @var9 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Users]') AND [c].[name] = N'Ime');
    IF @var9 IS NOT NULL EXEC(N'ALTER TABLE [Users] DROP CONSTRAINT [' + @var9 + '];');
    ALTER TABLE [Users] ALTER COLUMN [Ime] nvarchar(max) NOT NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200604133417_entitiesValidation')
BEGIN
    DECLARE @var10 sysname;
    SELECT @var10 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[OsnovniPodaci]') AND [c].[name] = N'Termin');
    IF @var10 IS NOT NULL EXEC(N'ALTER TABLE [OsnovniPodaci] DROP CONSTRAINT [' + @var10 + '];');
    ALTER TABLE [OsnovniPodaci] ALTER COLUMN [Termin] datetime2 NOT NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200604133417_entitiesValidation')
BEGIN
    DECLARE @var11 sysname;
    SELECT @var11 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[OsnovniPodaci]') AND [c].[name] = N'Poduzece');
    IF @var11 IS NOT NULL EXEC(N'ALTER TABLE [OsnovniPodaci] DROP CONSTRAINT [' + @var11 + '];');
    ALTER TABLE [OsnovniPodaci] ALTER COLUMN [Poduzece] nvarchar(max) NOT NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200604133417_entitiesValidation')
BEGIN
    DECLARE @var12 sysname;
    SELECT @var12 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[OsnovniPodaci]') AND [c].[name] = N'NazivMentora');
    IF @var12 IS NOT NULL EXEC(N'ALTER TABLE [OsnovniPodaci] DROP CONSTRAINT [' + @var12 + '];');
    ALTER TABLE [OsnovniPodaci] ALTER COLUMN [NazivMentora] nvarchar(max) NOT NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200604133417_entitiesValidation')
BEGIN
    DECLARE @var13 sysname;
    SELECT @var13 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[OsnovniPodaci]') AND [c].[name] = N'IdUsera');
    IF @var13 IS NOT NULL EXEC(N'ALTER TABLE [OsnovniPodaci] DROP CONSTRAINT [' + @var13 + '];');
    ALTER TABLE [OsnovniPodaci] ALTER COLUMN [IdUsera] nvarchar(max) NOT NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200604133417_entitiesValidation')
BEGIN
    ALTER TABLE [OsnovniPodaci] ADD [studij] nvarchar(max) NOT NULL DEFAULT N'';
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200604133417_entitiesValidation')
BEGIN
    DECLARE @var14 sysname;
    SELECT @var14 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Izvjesca]') AND [c].[name] = N'IdUsera');
    IF @var14 IS NOT NULL EXEC(N'ALTER TABLE [Izvjesca] DROP CONSTRAINT [' + @var14 + '];');
    ALTER TABLE [Izvjesca] ALTER COLUMN [IdUsera] nvarchar(max) NOT NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200604133417_entitiesValidation')
BEGIN
    DECLARE @var15 sysname;
    SELECT @var15 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Izvjesca]') AND [c].[name] = N'FileUrl');
    IF @var15 IS NOT NULL EXEC(N'ALTER TABLE [Izvjesca] DROP CONSTRAINT [' + @var15 + '];');
    ALTER TABLE [Izvjesca] ALTER COLUMN [FileUrl] nvarchar(max) NOT NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200604133417_entitiesValidation')
BEGIN
    DECLARE @var16 sysname;
    SELECT @var16 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Dnevnici]') AND [c].[name] = N'IdUsera');
    IF @var16 IS NOT NULL EXEC(N'ALTER TABLE [Dnevnici] DROP CONSTRAINT [' + @var16 + '];');
    ALTER TABLE [Dnevnici] ALTER COLUMN [IdUsera] nvarchar(max) NOT NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200604133417_entitiesValidation')
BEGIN
    DECLARE @var17 sysname;
    SELECT @var17 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Dnevnici]') AND [c].[name] = N'FileUrl');
    IF @var17 IS NOT NULL EXEC(N'ALTER TABLE [Dnevnici] DROP CONSTRAINT [' + @var17 + '];');
    ALTER TABLE [Dnevnici] ALTER COLUMN [FileUrl] nvarchar(max) NOT NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200604133417_entitiesValidation')
BEGIN
    DECLARE @var18 sysname;
    SELECT @var18 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Ankete]') AND [c].[name] = N'Trece');
    IF @var18 IS NOT NULL EXEC(N'ALTER TABLE [Ankete] DROP CONSTRAINT [' + @var18 + '];');
    ALTER TABLE [Ankete] ALTER COLUMN [Trece] nvarchar(max) NOT NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200604133417_entitiesValidation')
BEGIN
    DECLARE @var19 sysname;
    SELECT @var19 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Ankete]') AND [c].[name] = N'Sesto');
    IF @var19 IS NOT NULL EXEC(N'ALTER TABLE [Ankete] DROP CONSTRAINT [' + @var19 + '];');
    ALTER TABLE [Ankete] ALTER COLUMN [Sesto] nvarchar(max) NOT NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200604133417_entitiesValidation')
BEGIN
    DECLARE @var20 sysname;
    SELECT @var20 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Ankete]') AND [c].[name] = N'Sedmo');
    IF @var20 IS NOT NULL EXEC(N'ALTER TABLE [Ankete] DROP CONSTRAINT [' + @var20 + '];');
    ALTER TABLE [Ankete] ALTER COLUMN [Sedmo] nvarchar(max) NOT NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200604133417_entitiesValidation')
BEGIN
    DECLARE @var21 sysname;
    SELECT @var21 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Ankete]') AND [c].[name] = N'Peto');
    IF @var21 IS NOT NULL EXEC(N'ALTER TABLE [Ankete] DROP CONSTRAINT [' + @var21 + '];');
    ALTER TABLE [Ankete] ALTER COLUMN [Peto] nvarchar(max) NOT NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200604133417_entitiesValidation')
BEGIN
    DECLARE @var22 sysname;
    SELECT @var22 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Ankete]') AND [c].[name] = N'Osmo');
    IF @var22 IS NOT NULL EXEC(N'ALTER TABLE [Ankete] DROP CONSTRAINT [' + @var22 + '];');
    ALTER TABLE [Ankete] ALTER COLUMN [Osmo] nvarchar(max) NOT NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200604133417_entitiesValidation')
BEGIN
    DECLARE @var23 sysname;
    SELECT @var23 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Ankete]') AND [c].[name] = N'Jedanaesto');
    IF @var23 IS NOT NULL EXEC(N'ALTER TABLE [Ankete] DROP CONSTRAINT [' + @var23 + '];');
    ALTER TABLE [Ankete] ALTER COLUMN [Jedanaesto] nvarchar(max) NOT NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200604133417_entitiesValidation')
BEGIN
    DECLARE @var24 sysname;
    SELECT @var24 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Ankete]') AND [c].[name] = N'IdUsera');
    IF @var24 IS NOT NULL EXEC(N'ALTER TABLE [Ankete] DROP CONSTRAINT [' + @var24 + '];');
    ALTER TABLE [Ankete] ALTER COLUMN [IdUsera] nvarchar(max) NOT NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200604133417_entitiesValidation')
BEGIN
    DECLARE @var25 sysname;
    SELECT @var25 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Ankete]') AND [c].[name] = N'Dvanaesto');
    IF @var25 IS NOT NULL EXEC(N'ALTER TABLE [Ankete] DROP CONSTRAINT [' + @var25 + '];');
    ALTER TABLE [Ankete] ALTER COLUMN [Dvanaesto] nvarchar(max) NOT NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200604133417_entitiesValidation')
BEGIN
    DECLARE @var26 sysname;
    SELECT @var26 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Ankete]') AND [c].[name] = N'Deveto');
    IF @var26 IS NOT NULL EXEC(N'ALTER TABLE [Ankete] DROP CONSTRAINT [' + @var26 + '];');
    ALTER TABLE [Ankete] ALTER COLUMN [Deveto] nvarchar(max) NOT NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200604133417_entitiesValidation')
BEGIN
    DECLARE @var27 sysname;
    SELECT @var27 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Ankete]') AND [c].[name] = N'Deseto');
    IF @var27 IS NOT NULL EXEC(N'ALTER TABLE [Ankete] DROP CONSTRAINT [' + @var27 + '];');
    ALTER TABLE [Ankete] ALTER COLUMN [Deseto] nvarchar(max) NOT NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200604133417_entitiesValidation')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20200604133417_entitiesValidation', N'3.1.1');
END;

GO

