CREATE PROCEDURE [dbo].UPDATE_chores
    @Id INT,              -- Match the ChoreModel property name (Id)
    @IsComplete BIT      -- Match the ChoreModel property name (IsComplete)
AS
BEGIN
    UPDATE dbo.fact_chores
    SET 
        Is_Complete = @IsComplete
    WHERE Fact_Chore_ID  = @Id;
END
