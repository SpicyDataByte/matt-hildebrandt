CREATE PROCEDURE [dbo].[sp_Chores_Update]
    @Id INT,              -- Match the ChoreModel property name (Id)
    @KidName NVARCHAR(50), -- Match the ChoreModel property name (KidName)
    @Task NVARCHAR(100),  -- Match the ChoreModel property name (Task)
    @IsComplete BIT,      -- Match the ChoreModel property name (IsComplete)
    @ChoreDate DATE       -- Match the ChoreModel property name (ChoreDate)
AS
BEGIN
    UPDATE dbo.Chores
    SET 
        Kid_Name    = @KidName,
        Task        = @Task,
        Is_Complete = @IsComplete,
        Chore_Date  = @ChoreDate    
    WHERE Chore_ID  = @Id;
END
