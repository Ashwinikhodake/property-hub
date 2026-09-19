namespace PropertyHub.Application.Features.Authentication.Register;

public interface IPasswordHasher
{
    string Hash(string password);
    bool Verify(string password, string PasswordHash);
}