namespace PresShare.DataAccess.Lib.Models;
public class PressModel{
    public int id;
    public string  title {get;set;}
    public string? content {get;set;}
    public string? genre {get;set;}
    public int author_id {get;set;}
    public DateTime created_at {get;set;}
    public DateTime last_modified {get;set;}
}