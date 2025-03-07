CREATE TABLE dbo.Chores
(
	[Chore_ID] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Kid_Name] NVARCHAR(50) NULL, 
    [Task] NVARCHAR(100) NULL,
    Is_Complete BIT, 
    Chore_Date DATE
)