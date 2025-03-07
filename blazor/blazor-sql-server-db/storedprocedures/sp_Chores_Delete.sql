CREATE PROCEDURE [dbo].[sp_Chores_Delete]
	@Id int
AS
begin
	delete
	from dbo.Chores
	where Chore_ID = @Id;
end
