using PresShare.DataModel.Lib;

namespace PresShare.DataAccess.Lib.Data;
public interface IAuthorData
{
    Task DeleteAuthor(int id);
    Task<AuthorModel?> GetAuhtor(int id);
    Task<AuthorModel?> GetAuhtorByEmail(string email);
    Task<AuthorModel?> GetAuhtorByPseudo(string pseudo);
    Task<IEnumerable<AuthorModel>> GetAuthors();
    Task InsertAuthor(AuthorModel author);
    Task UpdateAuthor(AuthorModel author);

}