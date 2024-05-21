using Hospital.Api.Dtos;
using Hospital.Api.Models;
using Hospital.Api.Repositories.Interfaces;
using Hospital.Api.Services.Interfaces;

namespace Hospital.Api.Services
{
  public class DoctorService : IDoctorService
  {
    private readonly IRepository<Doctor> _repository;

    public DoctorService(IRepository<Doctor> repository)
    {
      _repository = repository;
    }

    public async Task<Doctor> CreateAsync(DoctorDto doctorDto)
    {
      var entity = new Doctor
      {
        Name = doctorDto.Name,
        Specialization = doctorDto.Specialization,
        Email = doctorDto.Email,
        Password = doctorDto.Password,
        RoleId = doctorDto.RoleId
      };

      var doctor = await _repository.CreateAsync(entity);

      if (doctor == null)
      {
        throw new Exception("Doctor not created");
      }

      return doctor;
    }

    public async Task<Doctor> UpdateAsync(Doctor entity)
    {
      var doctor = await _repository.GetByIdAsync(entity.DoctorId);

      if (doctor == null)
      {
        throw new Exception("Doctor not found");
      }

      if(!await _repository.UpdateAsync(entity))
      {
        throw new Exception("Doctor not update");
      }

      return entity;
    }

    public async Task<Doctor> DeleteAsync(int doctorId)
    {
      var doctor = await _repository.GetByIdAsync(doctorId);

      if (doctor == null)
      {
        throw new Exception("Doctor not found");
      }

      if (!await _repository.DeleteAsync(doctor))
      {
        throw new Exception("Doctor not delete");
      }

      return doctor;
    }

    public async Task<IEnumerable<Doctor>> GetAllAsync()
    {
      return await _repository.GetAllAsync();
    }
  }
}
