CREATE PROCEDURE presshare.[spAuthor_Update]
	@Id int,
	@Pseudo nvarchar(20),
	@FirstName nvarchar(20),
	@LastName nvarchar(50),
	@Password nvarchar(255),
	@Email nvarchar(255),
	@Confirmation_Token nvarchar(255)
	
AS
begin
	update presshare.author
	set a_first_name = @FirstName, a_last_name = @LastName, a_pseudo = @Pseudo, a_password = @Password,a_email = @Email, a_confirmation_token = @Confirmation_Token
	where a_id = @Id;
end
