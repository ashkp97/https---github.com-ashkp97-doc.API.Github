using Microsoft.AspNetCore.Identity.Data;

public interface IAuthenticationService
{
    public Task<LoginResponseDto> Login(LoginRequestDto loginRequest);
}