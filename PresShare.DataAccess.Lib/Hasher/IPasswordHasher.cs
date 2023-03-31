namespace PresShare.DataAccess.Lib.Hasher;

public interface IPasswordHasher
{
    string Hash(string pasword);
    bool Verify(string passwordHash, string inputPassword);
}