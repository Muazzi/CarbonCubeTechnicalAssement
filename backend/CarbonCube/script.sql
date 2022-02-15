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

CREATE TABLE [MedicalClaims] (
    [MedicalClaimId] int NOT NULL IDENTITY,
    [ICDCode] nvarchar(max) NULL,
    [Diagnoses] nvarchar(max) NULL,
    [Value] float NOT NULL,
    CONSTRAINT [PK_MedicalClaims] PRIMARY KEY ([MedicalClaimId])
);
GO

CREATE TABLE [Patients] (
    [PatientId] int NOT NULL IDENTITY,
    [FullName] nvarchar(max) NULL,
    [MedicalAidName] nvarchar(max) NULL,
    [MedicalAidNumber] int NOT NULL,
    [Email] nvarchar(max) NULL,
    [MedicalClaimId] int NOT NULL,
    CONSTRAINT [PK_Patients] PRIMARY KEY ([PatientId]),
    CONSTRAINT [FK_Patients_MedicalClaims_MedicalClaimId] FOREIGN KEY ([MedicalClaimId]) REFERENCES [MedicalClaims] ([MedicalClaimId]) ON DELETE CASCADE
);
GO

CREATE INDEX [IX_Patients_MedicalClaimId] ON [Patients] ([MedicalClaimId]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20220207190451_Initial', N'5.0.13');
GO

COMMIT;
GO

