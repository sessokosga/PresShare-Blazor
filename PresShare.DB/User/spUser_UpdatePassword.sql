CREATE PROCEDURE presshare.[spUser_UpdatePassword]
	@Id int,
	@Password nvarchar(255)
	
AS
begin
	update presshare.author
	set a_email = @Password
	where a_id = @Id;
end
