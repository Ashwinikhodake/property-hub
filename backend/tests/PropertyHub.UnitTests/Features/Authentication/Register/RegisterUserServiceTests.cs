using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;
using Moq;
using PropertyHub.Application.Features.Authentication.Register;
using PropertyHub.Domain.Entities;
using PropertyHub.Domain.Enums;

namespace PropertyHub.UnitTests.Features.Authentication.Register;

public class RegisterUserServiceTests
{
    [Fact]
    public async Task Register_withValidRequest_CreatesCustomer()
    {
        var userRepositoryMock = new Mock<IUserRepository>();
        var passwordHasherMock = new Mock<IPasswordHasher>();

        userRepositoryMock.Setup(x => x.GetByEmailAsync(It.IsAny<string>(), It.IsAny<CancellationToken>())).ReturnsAsync((User?)null);
        passwordHasherMock.Setup(x => x.Hash(It.IsAny<string>())).Returns("Hashed-password");

        var request = new RegisterUserRequest
        {
            FirstName = "Ashwini",
            LastName = "K",
            Email = "ash@gmail.com",
            Password = "Test@12345",
        };

        var service = new RegisterUserService(
            userRepositoryMock.Object,
            passwordHasherMock.Object
        );
        var result = await service.RegisterAsync(request);

        Assert.Equal("Ashwini", result.FirstName);
        Assert.Equal("K", result.LastName);
        Assert.Equal("ash@gmail.com", result.Email);
        Assert.Equal("Customer", result.Role);

        passwordHasherMock.Verify(x => x.Hash("Test@12345"), Times.Once);
        userRepositoryMock.Verify(x => x.AddAsync(It.Is<User>(u => u.Email == "ash@gmail.com" && u.Role == UserRole.Customer && u.PasswordHash == "Hashed-password"), It.IsAny<CancellationToken>()), Times.Once);
    }

    [Fact]
    public async Task Register_WithExistingEmail_ThrowException()
    {
        var userRepositoryMock = new Mock<IUserRepository>();
        var passwordHasherMock = new Mock<IPasswordHasher>();

        var existingUser = new User
        {
            Id = Guid.NewGuid(),
            Email = "ash@gmail.com",
            FirstName = "Existing",
            LastName = "User",
            Role = UserRole.Customer,
        };

        userRepositoryMock.Setup(x => x.GetByEmailAsync(It.IsAny<string>(), It.IsAny<CancellationToken>())).ReturnsAsync(existingUser);

        var request = new RegisterUserRequest
        {
            FirstName = "Ashwini",
            LastName = "K",
            Email = "ash@gmail.com",
            Password = "Test@12345"
        };

        var service = new RegisterUserService(userRepositoryMock.Object, passwordHasherMock.Object);
        await Assert.ThrowsAsync<InvalidOperationException>(() => service.RegisterAsync(request));
    }

    [Fact]
    public async Task Register_WithValidPassword_HashesPassword()
    {
        var userRepositoryMock = new Mock<IUserRepository>();
        var passwordHasherMock = new Mock<IPasswordHasher>();

        userRepositoryMock.Setup(x => x.GetByEmailAsync(It.IsAny<string>(), It.IsAny<CancellationToken>())).ReturnsAsync((User?)null);
        passwordHasherMock.Setup(x => x.Hash(It.IsAny<string>())).Returns("hashed - password");

        var request = new RegisterUserRequest
        {
            FirstName = "Ashwini",
            LastName = "K",
            Email = "hash-test@gmail.com",
            Password = "Secret@123"
        };

        var service = new RegisterUserService(userRepositoryMock.Object, passwordHasherMock.Object);

        await service.RegisterAsync(request);
        passwordHasherMock.Verify(x => x.Hash("Secret@123"), Times.Once);
    }

    [Fact]
    public async Task Register_WithUppercaseAndWithspaceEmail_NormalizesEmail()
    {
        var userRepositoryMock = new Mock<IUserRepository>();
        var passwordHasherMock = new Mock<IPasswordHasher>();

        userRepositoryMock.Setup(x => x.GetByEmailAsync(It.IsAny<string>(), It.IsAny<CancellationToken>())).ReturnsAsync((User?)null);
        passwordHasherMock.Setup(x => x.Hash(It.IsAny<string>())).Returns("hashed - password");

        var request = new RegisterUserRequest
        {
            FirstName = "Ashwini",
            LastName = "K",
            Email = "ASH@GMAIL.COM",
            Password = "Test@12345"
        };

        var service = new RegisterUserService(
            userRepositoryMock.Object,
            passwordHasherMock.Object
        );

        var result = await service.RegisterAsync(request);

        Assert.Equal("ash@gmail.com", result.Email);
        userRepositoryMock.Verify(x => x.GetByEmailAsync("ash@gmail.com", It.IsAny<CancellationToken>()), Times.Once);

    }


}