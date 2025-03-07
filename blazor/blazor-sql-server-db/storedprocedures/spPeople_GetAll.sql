CREATE PROCEDURE [dbo].[spPeople_GetAll]
AS
begin
	select Id, FirstName, LastName, PlayerImage
	from dbo.People;
end
