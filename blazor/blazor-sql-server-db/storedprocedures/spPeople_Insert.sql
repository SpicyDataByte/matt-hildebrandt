CREATE PROCEDURE [dbo].[spPeople_Insert]
	@FirstName nvarchar(50),
	@LastName nvarchar(50), 
	@PlayerImage varbinary(max)
AS
begin
	insert into dbo.People (FirstName, LastName, PlayerImage)
	values (@FirstName, @LastName, @PlayerImage);
end
