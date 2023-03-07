CREATE PROCEDURE presshare.[spPress_Insert]
	@Title nvarchar(255),
	@Content nvarchar(max),
	@Genre nvarchar(4),
	@AuthorId int
AS
begin
	insert into presshare.press(p_title,p_content,p_genre,p_author_id)
	values (@Title,@Content, @Genre,@AuthorId);
end
