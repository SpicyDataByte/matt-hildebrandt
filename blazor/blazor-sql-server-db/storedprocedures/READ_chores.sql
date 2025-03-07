CREATE PROCEDURE [dbo].READ_chores
AS
begin
	SELECT
		f.Fact_Chore_ID as ID
		,f.Date as ChoreDate
		,k.Kid_Name as KidName
		,c.Chore_Name as Task
		,f.Is_Complete as IsComplete
	FROM 
		fact_chores f
	LEFT JOIN dim_chores c ON f.Chore_ID = c.Chore_ID
	LEFT JOIN dim_kids k ON f.Kid_ID = k.Kid_ID
end