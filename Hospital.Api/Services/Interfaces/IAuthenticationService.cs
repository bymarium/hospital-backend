using Hospital.Api.Dtos;

namespace Hospital.Api.Services.Interfaces
{
  public interface IAuthenticationService
  {
    Task<UserDto> AutheticateAsync(CredentialsDto credentialsDto);
  }
}
