CREATE PROCEDURE [dbo].[spFood_GetAll]
as	
begin

	set nocount on;

	select [Id], [Title], [Description], [Price] 
	from dbo.Food

end
