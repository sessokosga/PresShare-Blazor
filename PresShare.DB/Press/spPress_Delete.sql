CREATE PROCEDURE [presshare].[spPress_Delete]
	@Id int
AS
begin
	delete
	from presshare.press
	where p_id = @Id;
end
