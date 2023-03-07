CREATE PROCEDURE [presshare].[spUser_Delete]
	@Id int
AS
begin
	delete
	from presshare.author
	where a_id = @Id;
end
