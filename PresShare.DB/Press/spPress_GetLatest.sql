CREATE PROCEDURE presshare.[spPress_GetLatest]
	@Limit int
AS
begin
	select top (@Limit) p_id id, p_author_id author_id, p_content content, p_created_at created_At, p_genre genre, p_title title, p_last_modified last_modified
	from presshare.[press] order by p_last_modified desc
end
