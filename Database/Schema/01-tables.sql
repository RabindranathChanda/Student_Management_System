-- ============================================================================
-- 01-tables.sql
-- Baseline schema inferred from SchoolDataSet.xsd (typed dataset)
-- NOTE: Adjust data types & nullability if they differ in the actual database.
-- ============================================================================
USE [School];
GO

SET ANSI_NULLS ON;
SET QUOTED_IDENTIFIER ON;
GO

-- TABLE: Student
IF OBJECT_ID('dbo.Student','U') IS NULL
BEGIN
    CREATE TABLE dbo.Student (
        Student_id     NVARCHAR(255)     NOT NULL,      -- PK (see constraints script)
        Name           NVARCHAR(255)     NULL,
        [Father's_Name] NVARCHAR(255)    NULL,
        Address        NVARCHAR(255)     NULL,
        Phone          NVARCHAR(255)     NULL,          -- Future: normalize to a phone format or separate country code
        Voter_id       NVARCHAR(255)     NULL,
        Class          NVARCHAR(255)     NULL,          -- Future: potential lookup table
        Roll_no        NVARCHAR(255)     NULL,
        Sec            NVARCHAR(255)     NULL,
        Library_Card   NVARCHAR(255)     NULL,
        Bus            NVARCHAR(255)     NULL,
        Photo          IMAGE             NULL           -- Legacy IMAGE type; consider VARBINARY(MAX)
    );
END
GO

-- TABLE: Library
IF OBJECT_ID('dbo.Library','U') IS NULL
BEGIN
    CREATE TABLE dbo.Library (
        Student_id   NVARCHAR(255)  NOT NULL,
        Card_no      NVARCHAR(255)  NULL,
        [Book Name]  NVARCHAR(255)  NOT NULL,
        Issue_date   NVARCHAR(255)  NOT NULL,  -- Future: DATE or DATETIME
        Submit_date  NVARCHAR(255)  NULL,  -- Future: DATE or DATETIME
        Total_fine   NVARCHAR(255)  NULL,  -- Future: DECIMAL(10,2)
        Report       NVARCHAR(255)  NULL
    );
END
GO

-- TABLE: Bus
IF OBJECT_ID('dbo.Bus','U') IS NULL
BEGIN
    CREATE TABLE dbo.Bus (
        Student_id    NVARCHAR(255)  NOT NULL,
        Card_no       NVARCHAR(255)  NULL,
        Install_month NVARCHAR(255)  NOT NULL,  -- Future: could be TINYINT + Year pattern
        Paid_date     NVARCHAR(255)  NULL,  -- Future: DATE
        Total_due     NVARCHAR(255)  NULL   -- Future: DECIMAL(10,2)
    );
END
GO

-- TABLE: Users
IF OBJECT_ID('dbo.Users','U') IS NULL
BEGIN
    CREATE TABLE dbo.Users (
        [First Name] NVARCHAR(255) NULL,
        [Last Name]  NVARCHAR(255) NULL,
        Phone        NVARCHAR(255) NULL,
        User_Type    NVARCHAR(255) NULL,
        UserName     NVARCHAR(255) NOT NULL, -- PK (see constraints script)
        [Password]   NVARCHAR(255) NULL, -- Future: store salted hash, not plaintext
        DP           IMAGE         NULL  -- Future: VARBINARY(MAX)
    );
END
GO

-- Placeholder: Additional tables (if any) should be added above this line.

PRINT '01-tables.sql completed.';
GO
