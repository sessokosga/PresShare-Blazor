CREATE PROCEDURE presshare.[spPress_Insert]
	@Title nvarchar(255),
	@Content nvarchar(max),
	@Genre nvarchar(4),
	@Author_Id int
AS
begin
	insert into presshare.press
		(
		p_title,
		p_content,
		p_genre,
		p_author_id,
		p_created_at
		)
	values
		(@Title, @Content, @Genre, @Author_Id, GETUTCDATE());
end
