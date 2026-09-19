using Microsoft.AspNetCore.Identity;
using PropertyHub.Application.Features.Authentication.Register;
using PropertyHub.Domain.Entities;

namespace PropertyHub.Infrastructure.Security;

public class PasswordHasher : IPasswordHasher
{
    private readonly PasswordHasher<User> _passwordHasher = new();
    public string Hash(string password)
    {
        return _passwordHasher.HashPassword(new User(), password);
    }

    public bool Verify(string password, string passwordHash)
    {
        var result = _passwordHasher.VerifyHashedPassword(new User(), passwordHash, password);
        return result != PasswordVerificationResult.Failed;
    }
}