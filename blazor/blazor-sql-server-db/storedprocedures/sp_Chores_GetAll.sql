CREATE PROCEDURE
[dbo].sp_Chores_GetAll
AS
begin
	SELECT
	Chore_ID as Id
	,Task
	,Kid_Name as KidName
	,Is_Complete as IsComplete
	,Chore_Date as ChoreDate
	from dbo.Chores;
end