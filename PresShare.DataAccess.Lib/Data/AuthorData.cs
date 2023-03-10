using PresShare.DataAccess.Lib.DbAccess;
using PresShare.DataAccess.Lib.Models;

namespace PresShare.DataAccess.Lib.Data;

public class AuthorData : IAuthorData
{
    private readonly ISqlDataAccess _db;

    public AuthorData(ISqlDataAccess db)
    {
        _db = db;
    }

    public Task<IEnumerable<AuthorModel>> GetAuthors() =>
        _db.LoadData<AuthorModel, dynamic>("presshare.spAuthor_GetAll", new { });

    public async Task<AuthorModel?> GetAuhtor(int id)
    {
        var results = await _db.LoadData<AuthorModel, dynamic>(
            "presshare.spAuthor_Get",
            new { Id = id });
        return results.FirstOrDefault();
    }

    public async Task<AuthorModel?> GetAuhtorByEmail(string email)
    {
        var results = await _db.LoadData<AuthorModel, dynamic>(
            "presshare.spAuthor_GetByEmail",
            new { Email = email });
        return results.FirstOrDefault();
    }
    public async Task<AuthorModel?> GetAuhtorByPseudo(string pseudo)
    {
        var results = await _db.LoadData<AuthorModel, dynamic>(
            "presshare.spAuthor_GetByPseudo",
            new { Pseudo = pseudo });
        return results.FirstOrDefault();
    }

    public Task InsertAuthor(AuthorModel author)
    {
        return _db.SaveData("presshare.spAuthor_Insert", new { author.pseudo, author.email, author.password, author.confirmation_token });
    }

    public Task UpdateAuthor(AuthorModel author) =>
        _db.SaveData("presshare.spAuthor_Update", new
        {
            Id = author.id,
            Pseudo = author.pseudo,
            FirstName = author.first_name,
            LastName = author.last_name,
            Email = author.email,
            Confirmation_Token = author.confirmation_token,
            Password = author.password
        });

    public Task DeleteAuthor(int id) =>
        _db.SaveData("presshare.spAuthor_Delete", new { Id = id });
}