CREATE PROCEDURE presshare.[spAuthor_Insert]
	@Pseudo nvarchar(20),
	@Email nvarchar(255),
	@Password nvarchar(255),
	@Confirmation_Token nvarchar(255)
AS
begin
	insert into presshare.[author]
		(a_pseudo, a_email, a_password, a_created_at, a_confirmation_token)
	values
		(@Pseudo, @Email, @Password, GETUTCDATE(), @Confirmation_Token);
end