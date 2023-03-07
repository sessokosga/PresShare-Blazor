CREATE PROCEDURE presshare.[spUser_Get]
	@Id int
AS
begin
	select a_id,a_first_name , a_last_name
	from presshare.[author]
	where a_id = @Id;
end
