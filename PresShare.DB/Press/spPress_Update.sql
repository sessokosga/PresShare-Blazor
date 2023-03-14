CREATE PROCEDURE presshare.[spPress_Update]
	@Id int,
	@Title nvarchar(255),
	@Content nvarchar(max),
	@Genre nvarchar(4)
AS
begin
	update presshare.press
	set p_title = @Title, p_content = @Content, p_genre=@Genre, p_last_modified=GETUTCDATE()
	where p_id = @Id;
end
