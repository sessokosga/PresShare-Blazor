namespace PresShare.DataAccess.Lib.Data;
using PresShare.DataModel.Lib;


public interface IPressData
{
    Task DeletePress(int id);
    Task<PressModel?> GetPress(int id);
    Task<IEnumerable<PressModel>> GetPresses();
    Task InsertPress(PressModel press);
    Task UpdatePress(PressModel press);
    public Task<IEnumerable<PressModel>> GetPressesByGenre(string genre);

    public Task<IEnumerable<PressModel>> GetPressByGenre(string genre, int limit);

}