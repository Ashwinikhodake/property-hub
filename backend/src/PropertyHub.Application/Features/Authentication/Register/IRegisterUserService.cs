
namespace PropertyHub.Application.Features.Authentication.Register;

public interface IRegisterUserService
{
    Task<RegisterUserResponse> RegisterAsync(RegisterUserRequest request, CancellationToken cancellationToken = default);
}