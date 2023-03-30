using PresShare.DataModel.Lib;

namespace PresShare.Website.Authentication;

public interface IMyAuthenticationService
{
    Task<AuthorModel> Login(AuthenticatinoAuthorModel userForAuthenticaton, bool remember);
    Task Logout();
}