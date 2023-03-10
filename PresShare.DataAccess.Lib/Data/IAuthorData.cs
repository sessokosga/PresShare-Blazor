using PresShare.DataAccess.Lib.Models;

namespace PresShare.DataAccess.Lib.Data;
public interface IAuthorData
{
    Task DeleteAuthor(int id);
    Task<AuthorModel?> GetAuhtor(int id);
    Task<IEnumerable<AuthorModel>> GetAuthors();
    Task InsertAuthor(AuthorModel author);
    Task UpdateAuthorEmail(AuthorModel author);
    Task UpdateAuthorPassword(AuthorModel author);
    Task UpdateAuthorProfile(AuthorModel author);
}