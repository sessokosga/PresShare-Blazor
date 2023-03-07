CREATE PROCEDURE presshare.[spPress_Get]
	@Id int
AS
begin
	select p_author_id author, p_content, p_created_at, p_genre,p_title 
	from presshare.[press]
	where p_id = @Id;
end
