using PresShare.DataAccess.Lib.DbAccess;
using PresShare.DataModel.Lib;

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
    public Task<IEnumerable<PressModel>> GetPressesByGenre(string genre) =>
        _db.LoadData<PressModel, dynamic>("presshare.spPress_GetAllByGenre", new { Genre = genre });

        public Task<IEnumerable<PressModel>> FindPress(string key) =>
        _db.LoadData<PressModel, dynamic>("presshare.spPress_Find", new { Key=key });

        
    public Task<IEnumerable<PressModel>> GetPressByGenre(string genre, int limit) =>
        _db.LoadData<PressModel, dynamic>("presshare.spPress_GetByGenre", new { Genre = genre, Limit = limit });
public Task<IEnumerable<PressModel>> GetLatest(int limit)=>
        _db.LoadData<PressModel, dynamic>("presshare.spPress_GetLatest", new { Limit = limit });
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
        _db.SaveData("presshare.spPress_Update", new { press.id, press.title, press.content, press.genre });

    public Task DeletePress(int id) =>
        _db.SaveData("presshare.spPress_Delete", new { Id = id });
}