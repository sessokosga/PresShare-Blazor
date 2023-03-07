CREATE PROCEDURE presshare.[spPress_GetAll]
AS
begin
	select p_author_id author, p_content, p_created_at, p_genre,p_title 
	from presshare.[press]
end
