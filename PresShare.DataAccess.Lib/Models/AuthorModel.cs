namespace PresShare.DataAccess.Lib.Models;

public class AuthorModel{
    public int id{get;set;}
    public required string pseudo{get;set;}
    public string? first_name{get;set;}
    public string? last_name{get;set;}
    public required string password {get;set;}
    public DateTime? created_at  {get;set;}
    public DateTime? confirmed_at  {get;set;}
    public string? confirmation_token {get;set;}
    public required string email {get;set;}
    public string? reset_token {get;set;}
    public DateTime? reset_at {get;set;}
    public string? remember_token {get;set;}
}