CREATE PROCEDURE presshare.[spUser_UpdateEmail]
	@Id int,
	@Email nvarchar(255)
	
AS
begin
	update presshare.author
	set a_email = @Email
	where a_id = @Id;
end
