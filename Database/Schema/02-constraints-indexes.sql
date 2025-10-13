-- ============================================================================
-- 02-constraints-indexes.sql
-- Adds primary keys / foreign keys inferred from dataset usage.
-- Adjust if actual database uses different keys.
-- ============================================================================
USE [School];
GO

-- PRIMARY KEYS ----------------------------------------------------------------
IF NOT EXISTS (SELECT 1 FROM sys.key_constraints WHERE name = 'PK_Student')
BEGIN
    ALTER TABLE dbo.Student ADD CONSTRAINT PK_Student PRIMARY KEY CLUSTERED (Student_id) WITH (IGNORE_DUP_KEY = OFF);
END
GO

IF NOT EXISTS (SELECT 1 FROM sys.key_constraints WHERE name = 'PK_Users')
BEGIN
    ALTER TABLE dbo.Users ADD CONSTRAINT PK_Users PRIMARY KEY CLUSTERED (UserName) WITH (IGNORE_DUP_KEY = OFF);
END
GO

-- Composite keys (adjust if surrogate keys exist in real schema)
IF NOT EXISTS (SELECT 1 FROM sys.key_constraints WHERE name = 'PK_Library')
BEGIN
    ALTER TABLE dbo.Library ADD CONSTRAINT PK_Library PRIMARY KEY CLUSTERED (Student_id, [Book Name], Issue_date);
END
GO

IF NOT EXISTS (SELECT 1 FROM sys.key_constraints WHERE name = 'PK_Bus')
BEGIN
    ALTER TABLE dbo.Bus ADD CONSTRAINT PK_Bus PRIMARY KEY CLUSTERED (Student_id, Install_month);
END
GO

-- FOREIGN KEYS -----------------------------------------------------------------
-- NOTE: These assume Student.Student_id is the parent key.
IF NOT EXISTS (SELECT 1 FROM sys.foreign_keys WHERE name = 'FK_Library_Student')
BEGIN
    ALTER TABLE dbo.Library ADD CONSTRAINT FK_Library_Student FOREIGN KEY (Student_id)
        REFERENCES dbo.Student (Student_id) ON UPDATE NO ACTION ON DELETE NO ACTION;
END
GO

IF NOT EXISTS (SELECT 1 FROM sys.foreign_keys WHERE name = 'FK_Bus_Student')
BEGIN
    ALTER TABLE dbo.Bus ADD CONSTRAINT FK_Bus_Student FOREIGN KEY (Student_id)
        REFERENCES dbo.Student (Student_id) ON UPDATE NO ACTION ON DELETE NO ACTION;
END
GO

-- INDEXES (Add performance indexes here as needed) -----------------------------
-- Example placeholder (commented out):
-- CREATE NONCLUSTERED INDEX IX_Student_Class_Roll ON dbo.Student (Class, Roll_no);

PRINT '02-constraints-indexes.sql completed.';
GO
