using PresShare.DataAccess.Lib.Models;

namespace PresShare.DataAccess.Lib.Data;
public interface IAuthorData
{
    Task DeleteUser(int id);
    Task<AuthorModel?> GetUser(int id);
    Task<IEnumerable<AuthorModel>> GetUsers();
    Task InsertUser(AuthorModel user);
    Task UpdateUserEmail(AuthorModel user);
    Task UpdateUserPassword(AuthorModel user);
    Task UpdateUserProfile(AuthorModel user);
}