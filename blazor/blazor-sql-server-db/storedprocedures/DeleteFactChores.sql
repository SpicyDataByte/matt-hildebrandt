CREATE PROCEDURE [dbo].[DeleteFactChores]
   @ChoreDate DATE
AS
BEGIN
	DELETE FROM [dbo].[Fact_Chores]
	WHERE Date = @ChoreDate;
END;

