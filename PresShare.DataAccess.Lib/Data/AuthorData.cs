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

    public Task<IEnumerable<AuthorModel>> GetUsers() =>
        _db.LoadData<AuthorModel, dynamic>("dbo.spUser_GetAll", new { });

    public async Task<AuthorModel?> GetUser(int id)
    {
        var results = await _db.LoadData<AuthorModel, dynamic>(
            "dbo.spUser_Get",
            new { Id = id });
        return results.FirstOrDefault();
    }

    public Task InsertUser(AuthorModel user) =>
        _db.SaveData("dbo.spUser_Insert", new { user.first_name, user.last_name });

    public Task UpdateUser(AuthorModel user) =>
        _db.SaveData("dbo.spUser_Update", user);

    public Task DeleteUser(int id) =>
        _db.SaveData("dbo.spUser_Delete", new { Id = id });
}