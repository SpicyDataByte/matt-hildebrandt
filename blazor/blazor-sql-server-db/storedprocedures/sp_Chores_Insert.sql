CREATE PROCEDURE [dbo].sp_Chores_Insert

   @Kid_Name NVARCHAR(50),
    @Task NVARCHAR(100),
    @Is_Complete BIT, 
    @Chore_Date DATE
AS
begin
	insert into dbo.Chores (Kid_Name, Task, Is_Complete, Chore_Date)
	values (@Kid_Name, @Task, @Is_Complete, @Chore_Date);
end
