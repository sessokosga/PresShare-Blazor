using PresShare.DataAccess.Lib.DbAccess;
using PresShare.DataAccess.Lib.Models;

namespace PresShare.DataAccess.Lib.Data;

public class PressData : IPressData
{
    private readonly ISqlDataAccess _db;

    public PressData(ISqlDataAccess db)
    {
        _db = db;
    }

    public Task<IEnumerable<PressModel>> GetPresses() =>
        _db.LoadData<PressModel, dynamic>("presshare.spPress_GetAll", new { });

    public async Task<PressModel?> GetPress(int id)
    {
        var results = await _db.LoadData<PressModel, dynamic>(
            "presshare.spPress_Get",
            new { Id = id });
        return results.FirstOrDefault();
    }

    public Task InsertPress(PressModel press) =>
        _db.SaveData("presshare.spPress_Insert", new { press.title, press.content, press.genre, press.author_id });

    public Task UpdatePress(PressModel press) =>
        _db.SaveData("presshare.spPress_Update", press);

    public Task DeletePress(int id) =>
        _db.SaveData("presshare.spPress_Delete", new { Id = id });
}