CREATE PROCEDURE [dbo].[InsertFactChores]
   @ChoreDate DATE
AS
BEGIN
    INSERT INTO [dbo].[fact_chores] (
        [Kid_ID],
        [Chore_ID],
        [Date],
        [Is_Complete]
    )
    SELECT 
        k.Kid_ID,
        c.Chore_ID,
        --CAST(GETDATE() AS DATE) AS [Date],
        @ChoreDate AS [Date], 
        0 AS [Is_Complete]
    FROM [dbo].[dim_kids] k
    LEFT JOIN [dbo].[dim_chores] c
    ON 1=1
END;
