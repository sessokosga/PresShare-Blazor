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
        _db.LoadData<AuthorModel, dynamic>("presshare.spUser_GetAll", new { });

    public async Task<AuthorModel?> GetUser(int id)
    {
        var results = await _db.LoadData<AuthorModel, dynamic>(
            "presshare.spUser_Get",
            new { Id = id });
        return results.FirstOrDefault();
    }

    public Task InsertUser(AuthorModel user) =>
        _db.SaveData("presshare.spUser_Insert", new { user.pseudo,user.email,user.password });

    public Task UpdateUserProfile(AuthorModel user) =>
        _db.SaveData("presshare.spUser_UpdateProfile", user);
    public Task UpdateUserEmail(AuthorModel user) =>
        _db.SaveData("presshare.spUser_UpdateEmail", user);
    public Task UpdateUserPassword(AuthorModel user) =>
        _db.SaveData("presshare.spUser_UpdatePassword", user);


    public Task DeleteUser(int id) =>
        _db.SaveData("presshare.spUser_Delete", new { Id = id });
}