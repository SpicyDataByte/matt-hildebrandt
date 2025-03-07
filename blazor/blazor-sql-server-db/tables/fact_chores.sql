CREATE TABLE [dbo].[fact_chores]
(
	[Fact_Chore_ID] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Kid_ID] INT NULL, 
    [Chore_ID] INT NULL, 
    [Date] DATE NULL, 
    [Is_Complete] BIT NULL, 
    CONSTRAINT [FK_fact_chores_dim_kids] FOREIGN KEY (Kid_ID) REFERENCES dbo.dim_kids(Kid_ID),
    CONSTRAINT [FK_fact_chores_dim_chores] FOREIGN KEY (Chore_ID) REFERENCES dbo.dim_chores(Chore_ID)
)
