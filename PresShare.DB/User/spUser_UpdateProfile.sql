CREATE PROCEDURE presshare.[spUser_UpdateProfile]
	@Id int,
	@Pseudo nvarchar(20),
	@FirstName nvarchar(20),
	@LastName nvarchar(50)
	
AS
begin
	update presshare.author
	set a_first_name = @FirstName, a_last_name = @LastName, a_pseudo = @Pseudo
	where a_id = @Id;
end
