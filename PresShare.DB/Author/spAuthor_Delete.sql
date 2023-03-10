CREATE PROCEDURE [presshare].[spAuthor_Delete]
	@Id int
AS
begin
	delete
	from presshare.author
	where a_id = @Id;
end
