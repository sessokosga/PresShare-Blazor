namespace PresShare.DataAccess.Lib.Models;
using System;

public class AuthorModel
{
    public int id { get; set; }
    public string ?pseudo { get; set; }
    public string? first_name { get; set; }
    public string? last_name { get; set; }
    public string ?password { get; set; }
    public DateTime? created_at { get; set; }
    public DateTime? confirmed_at { get; set; }
    public string confirmation_token { get; set; }
    public string email { get; set; }
    public string? reset_token { get; set; }
    public DateTime? reset_at { get; set; }
    public string? remember_token { get; set; }
}