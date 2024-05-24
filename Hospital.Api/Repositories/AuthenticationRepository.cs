using Hospital.Api.Models;
using Hospital.Api.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Hospital.Api.Repositories
{
  public class AuthenticationRepository : IAuthenticationRepository
  {
    private readonly IDatabase _database;

    public AuthenticationRepository(IDatabase database)
    {
      _database = database;
    }

    public async Task<Administrator?> validateAdminAsync(string email, string password)
    {
      return await _database.Administrator.FirstOrDefaultAsync(administrator => administrator.Email.Equals(email) && administrator.Password.Equals(password));
    }

    public async Task<Patient?> validatePatientAsync(string email, string password)
    {
      return await _database.Patient.FirstOrDefaultAsync(patient => patient.Email.Equals(email) && patient.Password.Equals(password));
    }

    public async Task<Doctor?> validateDoctorAsync(string email, string password)
    {
      return await _database.Doctor.FirstOrDefaultAsync(doctor => doctor.Email.Equals(email) && doctor.Password.Equals(password));
    }
  }
}
