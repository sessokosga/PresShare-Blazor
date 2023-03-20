CREATE PROCEDURE presshare.[spPress_Find]
	@Key varchar(200)
AS
begin
	select p_id id, p_author_id author_id, p_content content, p_created_at created_At, p_genre genre, p_title title, p_last_modified last_modified
	from presshare.[press]
	WHERE p_title LIKE '%'+@Key+ '%' OR p_content LIKE '%'+@Key+ '%'
end
