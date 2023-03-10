CREATE PROCEDURE presshare.[spAuthor_GetByPseudo]
	@Pseudo nvarchar(255)
AS
begin
	select
		a_id id,
		a_pseudo pseudo,
		a_first_name first_name,
		a_last_name last_name,
		a_password password,
		a_created_at created_at,
		a_confirmed_at confirmed_at,
		a_confirmation_token confirmation_token,
		a_email email,
		a_reset_token reset_token,
		a_reset_at reset_at,
		a_remember_token remember_token
	from presshare.[author]
	where a_pseudo= @Pseudo;
end
