CREATE PROCEDURE [dbo].[spPeople_Update]
	@Id int,
	@FirstName nvarchar(50),
	@LastName nvarchar(50),
	@PlayerImage varbinary(max)
AS
begin
	update dbo.People
	set FirstName = @FirstName,
		LastName = @LastName,
		PlayerImage = @PlayerImage
	where Id = @Id;
end
