using Hospital.Api.Dtos;
using Hospital.Api.Models;
using Hospital.Api.Repositories.Interfaces;
using Hospital.Api.Services.Interfaces;

namespace Hospital.Api.Services
{
  public class PatientService : IService<PatientDto>
  {
    private readonly IPatientRepository _repository;

    public PatientService(IPatientRepository repository)
    {
      _repository = repository;
    }

    public async Task<PatientDto> CreateAsync(PatientDto patientDto)
    {
      if (await _repository.EmailExistsAsync(patientDto.Email))
      {
        throw new Exception("Email already exists");
      }

      var entity = new Patient
      {
        Name = patientDto.Name,
        Age = patientDto.Age,
        Rh = patientDto.Rh,
        Email = patientDto.Email,
        Password = patientDto.Password
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
        Password = patient.Password
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
        Password = patientDto.Password
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
        Password = patient.Password
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
            Email = appointment.Doctor.Email
          }
        }).ToList() : null
      }); 
    }

    public async Task<PatientDto?> GetByIdWithDetailsAsync(int patientId)
    {
      var patient = await _repository.GetByIdWithDetailsAsync(patientId);

      if (patient == null)
      {
        return null;
      }

      return new PatientDto
      {
        PatientId = patient.PatientId,
        Name = patient.Name,
        Age = patient.Age,
        Rh = patient.Rh,
        Email = patient.Email,
        Password = patient.Password,
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
            Email = appointment.Doctor.Email
          }
        }).ToList() : null
      };
    }


  }
}
