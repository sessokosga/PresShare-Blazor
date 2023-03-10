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
        _db.LoadData<AuthorModel,dynamic>("presshare.spAuthor_GetAll", new {});

    public async Task<AuthorModel?> GetAuhtor(int id)
    {
        var results = await _db.LoadData<AuthorModel, dynamic>(
            "presshare.spAuthor_Get",
            new { Id = id });
        return results.FirstOrDefault();
    }

    public Task InsertAuthor(AuthorModel author) =>
        _db.SaveData("presshare.spAuthor_Insert", new { author.pseudo,author.email,author.password });

    public Task UpdateAuthorProfile(AuthorModel author) =>
        _db.SaveData("presshare.spAuthor_UpdateProfile", author);
    public Task UpdateAuthorEmail(AuthorModel author) =>
        _db.SaveData("presshare.spAuthor_UpdateEmail", author);
    public Task UpdateAuthorPassword(AuthorModel author) =>
        _db.SaveData("presshare.spAuthor_UpdatePassword", author);


    public Task DeleteAuthor(int id) =>
        _db.SaveData("presshare.spAuthor_Delete", new { Id = id });
}