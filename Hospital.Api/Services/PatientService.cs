using Hospital.Api.Dtos;
using Hospital.Api.Models;
using Hospital.Api.Repositories.Interfaces;
using Hospital.Api.Services.Interfaces;

namespace Hospital.Api.Services
{
  public class PatientService : IService<PatientDto>
  {
    private readonly IRepository<Patient> _repository;

    public PatientService(IRepository<Patient> repository)
    {
      _repository = repository;
    }

    public async Task<PatientDto> CreateAsync(PatientDto patientDto)
    {
      var entity = new Patient
      {
        Name = patientDto.Name,
        Age = patientDto.Age,
        Rh = patientDto.Rh,
        Email = patientDto.Email,
        Password = patientDto.Password,
        RoleId = patientDto.RoleId
      };

      var patient = await _repository.CreateAsync(entity);

      if (patient == null)
      {
        throw new Exception("Patient not created");
      }

      return new()
      {
        PatientId = patient.PatientId,
        Name = patient.Name,
        Age = patient.Age,
        Rh = patient.Rh,
        Email = patient.Email,
        Password = patient.Password,
        RoleId = patient.RoleId
      };
    }
    public async Task<PatientDto> UpdateAsync(PatientDto patientDto)
    {
      var patient = await _repository.GetByIdAsync(patientDto.PatientId);

      if (patient == null)
      {
        throw new Exception("Patient not found");
      }

      var entity = new Patient
      {
        PatientId = patientDto.PatientId,
        Name = patientDto.Name,
        Age = patientDto.Age,
        Rh = patientDto.Rh,
        Email = patientDto.Email,
        Password = patientDto.Password,
        RoleId = patientDto.RoleId
      };

      if (!await _repository.UpdateAsync(entity))
      {
        throw new Exception("Patient not update");
      }

      return patientDto;
    }

    public async Task<PatientDto> DeleteAsync(int patientId)
    {
      var patient = await _repository.GetByIdAsync(patientId);

      if (patient == null)
      {
        throw new Exception("Patient not found");
      }

      if (!await _repository.DeleteAsync(patient))
      {
        throw new Exception("Patient not delete");
      }

      return new()
      {
        PatientId = patient.PatientId,
        Name = patient.Name,
        Age = patient.Age,
        Rh = patient.Rh,
        Email = patient.Email,
        Password = patient.Password,
        RoleId = patient.RoleId
      };
    }

    public async Task<IEnumerable<PatientDto>> GetAllAsync()
    {
      var patients = await _repository.GetAllAsync();

      return patients.Select(patient => new PatientDto
      {
        PatientId = patient.PatientId,
        Name = patient.Name,
        Age = patient.Age,
        Rh = patient.Rh,
        Email = patient.Email,
        Password = patient.Password,
        RoleId = patient.RoleId,
        Appointments = patient.Appointments != null ? patient.Appointments.Select(appointment => new AppointmentDto
        {
          AppointmentId = appointment.AppointmentId,
          Date = appointment.Date,
          Surgery = appointment.Surgery,
          Diagnostic = appointment.Diagnostic,
          Doctor = new DoctorDto
          {
            DoctorId = appointment.Doctor.DoctorId,
            Name = appointment.Doctor.Name,
            Specialization = appointment.Doctor.Specialization,
            Email = appointment.Doctor.Email,
            RoleId = appointment.Doctor.RoleId
          }
        }).ToList() : null
      }); 
    }

    public async Task<PatientDto> GetByIdAsync(int patientId)
    {
      var patient = await _repository.GetByIdAsync(patientId);

      return new()
      {
        PatientId = patient.PatientId,
        Name = patient.Name,
        Age = patient.Age,
        Rh = patient.Rh,
        Email = patient.Email,
        Password = patient.Password,
        RoleId = patient.RoleId,
      };
    }
  }
}
