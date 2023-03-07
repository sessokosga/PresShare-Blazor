namespace PresShare.DataAccess.Lib.Data;
using PresShare.DataAccess.Lib.Models;


public interface IPressData
{
    Task DeletePress(int id);
    Task<PressModel?> GetPress(int id);
    Task<IEnumerable<PressModel>> GetPresses();
    Task InsertPress(PressModel press);
    Task UpdatePress(PressModel press);
}