CREATE PROCEDURE presshare.[spUser_Insert]
	@Pseudo nvarchar(20),
	@Email nvarchar(255),
	@Password nvarchar(255)
AS
begin
	insert into presshare.[author] (a_pseudo, a_email, a_password)
	values (@Pseudo, @Email, @Password);
end
