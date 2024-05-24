using Hospital.Api.Dtos;
using Hospital.Api.Repositories.Interfaces;
using Hospital.Api.Services.Interfaces;

namespace Hospital.Api.Services
{
  public class AuthenticationService : IAuthenticationService
  {
    private readonly IAuthenticationRepository _repository;
    public AuthenticationService(IAuthenticationRepository repository)
    {
      _repository = repository;
    }
    public async Task<UserDto> AutheticateAsync(CredentialsDto credentialsDto)
    {
      var administrator = await _repository.validateAdminAsync(credentialsDto.Email, credentialsDto.Password);
      var patient = await _repository.validatePatientAsync(credentialsDto.Email, credentialsDto.Password);
      var doctor = await _repository.validateDoctorAsync(credentialsDto.Email, credentialsDto.Password);

      if (administrator != null)
      {
        return new UserDto()
        {
          UserId = administrator.AdministratorId,
          Name = administrator.Name,
          Email = administrator.Email,
          Password = administrator.Password,
          Role = Enums.Role.Administrator
        };
      }
      else if (patient != null)
      {
        return new UserDto()
        {
          UserId = patient.PatientId,
          Name = patient.Name,
          Email = patient.Email,
          Password = patient.Password,
          Role = Enums.Role.Patient
        };
      }
      else if (doctor != null)
      {
        return new UserDto()
        {
          UserId = doctor.DoctorId,
          Name = doctor.Name,
          Email = doctor.Email,
          Password = doctor.Password,
          Role = Enums.Role.Doctor
        };
      }
      else if (administrator == null && patient == null && doctor == null)
      {
        throw new Exception("Does not exist or invalid credentials");
      }
      return null;
    }
  }
}
