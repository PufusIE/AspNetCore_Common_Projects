CREATE PROCEDURE [dbo].[spOrder_UpdateName]
	@Id int,
	@OrderName nvarchar(50)

as
begin 
	
	set nocount on;

	update dbo.[Order] 
	set OrderName = @OrderName
	where Id = @Id

end