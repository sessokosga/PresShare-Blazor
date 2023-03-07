CREATE PROCEDURE presshare.[spUser_GetAll]
AS
begin
	select a_id,a_first_name , a_last_name
	from presshare.[author]	
end
