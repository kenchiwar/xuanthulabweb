
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

CREATE TABLE [TblCourse] (
    [CouId] int NOT NULL IDENTITY,
    [CouName] nvarchar(50) NULL,
    [CouSemester] nvarchar(50) NULL,
    CONSTRAINT [PK__TblCours__E2AFE31AF4A72054] PRIMARY KEY ([CouId])
);
GO

CREATE TABLE [TblStudent] (
    [StuId] int NOT NULL IDENTITY,
    [StuPass] nvarchar(50) NULL,
    [StuAdress] nvarchar(50) NULL,
    [StuPhone] nvarchar(50) NULL,
    [StuEmail] nvarchar(50) NULL,
    [StuName] nvarchar(50) NULL,
    [deptId] int NULL,
    CONSTRAINT [PK__TblStude__6CDFAB955FD867BA] PRIMARY KEY ([StuId])
);
GO

CREATE TABLE [TblExam] (
    [ExamId] int NOT NULL IDENTITY,
    [ExamName] nvarchar(50) NULL,
    [ExamMark] float NULL,
    [ExamDate] date NULL,
    [StuId] int NULL,
    [CouId] int NULL,
    [Comment] text NULL,
    [MarkPass] int NULL,
    CONSTRAINT [PK__TblExam__297521C7EA735100] PRIMARY KEY ([ExamId]),
    CONSTRAINT [FK_TblExam_TblStudent] FOREIGN KEY ([StuId]) REFERENCES [TblStudent] ([StuId]),
    CONSTRAINT [Fk_TblExam_TblCourse] FOREIGN KEY ([CouId]) REFERENCES [TblCourse] ([CouId])
);
GO

CREATE INDEX [IX_TblExam_CouId] ON [TblExam] ([CouId]);
GO

CREATE INDEX [IX_TblExam_StuId] ON [TblExam] ([StuId]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20230320104631_Chan', N'7.0.4');
GO

COMMIT;
GO

