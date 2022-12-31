CREATE PROCEDURE [dbo].[spOrder_GetById]
	@Id int 

as
begin

	set nocount on;

	select [Id], [OrderName], [OrderDate], [FoodId], [Quantity], [Total] 
	from dbo.[Order] 
	where Id = @Id

end