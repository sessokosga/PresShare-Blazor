CREATE PROCEDURE presshare.[spPress_GetAll]
AS
begin
	select p_id id, p_author_id author_id, p_content content, p_created_at created_At, p_genre genre, p_title title, p_last_modified last_modified
	from presshare.[press]
end
