using Hospital.Api.Dtos;
using Hospital.Api.Models;
using Hospital.Api.Repositories;
using Hospital.Api.Repositories.Interfaces;
using Hospital.Api.Services.Interfaces;
namespace Hospital.Api.Services
{
  public class AppointmentService : IAppointmentService
  {
    private readonly IAppointmentRepository _repository;

    public AppointmentService(IAppointmentRepository repository)
    {
      _repository = repository;
    }

    public async Task<AppointmentDto> CreateAsync(AppointmentDto appointmentDto)
    {
      var entity = new Appointment
      {
        Date = appointmentDto.Date,
        Surgery = appointmentDto.Surgery,
        Diagnostic = appointmentDto.Diagnostic,
        PatientId = appointmentDto?.PatientId,
        DoctorId = appointmentDto.DoctorId
      };

      var appointment = await _repository.CreateAsync(entity);

      if (appointment == null)
      {
        throw new Exception("Appointment not created");
      }

      return new()
      {
        AppointmentId = appointment.AppointmentId,
        Date = appointment.Date,
        Surgery = appointment.Surgery,
        Diagnostic = appointment.Diagnostic,
        PatientId = appointment?.PatientId,
        DoctorId = appointment.DoctorId,
        Doctor = appointmentDto?.Doctor
      };
    }
    public async Task<AppointmentDto> UpdateAsync(AppointmentDto appointmentDto)
    {
      var currentAppointement = await _repository.GetByIdAsync(appointmentDto.AppointmentId);

      if (currentAppointement == null)
      {
        throw new Exception("Appointment not found");
      }

      var entity = new Appointment
      {
        AppointmentId = appointmentDto.AppointmentId,
        Date = appointmentDto.Date,
        Surgery = appointmentDto.Surgery,
        Diagnostic = appointmentDto.Diagnostic,
        PatientId = appointmentDto?.PatientId,
        DoctorId = appointmentDto.DoctorId
      };

      if (!await _repository.UpdateAsync(entity))
      {
        throw new Exception("Appointment not update");
      }

      return appointmentDto;
    }

    public async Task<AppointmentDto> DeleteAsync(int appointmentId)
    {
      var appointment = await _repository.GetByIdAsync(appointmentId);

      if (appointment == null)
      {
        throw new Exception("Appointment not found");
      }

      if (!await _repository.DeleteAsync(appointment))
      {
        throw new Exception("Appointment not delete");
      }

      return new()
      {
        AppointmentId = appointment.AppointmentId,
        Date = appointment.Date,
        Surgery = appointment.Surgery,
        Diagnostic = appointment.Diagnostic,
        PatientId = appointment?.PatientId,
        DoctorId = appointment.DoctorId
      };
    }

    public async Task<IEnumerable<AppointmentDto>> GetAllAsync()
    {
      var appointments = await _repository.GetAllAsync();

      return MapAppointments(appointments);
    }

    public async Task<IEnumerable<AppointmentDto>> GetAppointmentsByAgeAsync(int age)
    {
      DateTime forgetDate = CalculateForgetDate(age);
      var appointments = await _repository.GetAppointmentsByAgeAsync(forgetDate);

      return MapAppointments(appointments);
    }

    private DateTime CalculateForgetDate(int age)
    {
      DateTime currentDate = DateTime.Now;

      if (age > 24 && age < 36)
      {
        return currentDate.AddMonths(2).AddDays(15);
      }
      else if (age > 35 && age < 46)
      {
        return currentDate.AddMonths(1).AddDays(15);
      }
      else if (age > 46)
      {
        return currentDate.AddDays(15);
      }
      else
      {
        return currentDate.AddMonths(3);
      }
    }

    private IEnumerable<AppointmentDto> MapAppointments(IEnumerable<Appointment> appointments)
    {
      return appointments.Select(appointment => new AppointmentDto
      {
        AppointmentId = appointment.AppointmentId,
        Date = appointment.Date,
        Surgery = appointment.Surgery,
        Diagnostic = appointment.Diagnostic,
        Patient = appointment.Patient != null ? new PatientDto
        {
          PatientId = appointment.Patient.PatientId,
          Name = appointment.Patient.Name,
          Age = appointment.Patient.Age,
          Rh = appointment.Patient.Rh,
          Email = appointment.Patient.Email
        } : null,
        Doctor = new DoctorDto
        {
          DoctorId = appointment.Doctor.DoctorId,
          Name = appointment.Doctor.Name,
          Specialization = appointment.Doctor.Specialization,
          Email = appointment.Doctor.Email
        }
      });
    }

    public async Task<AppointmentDto> GetByIdAsync(int appointmentId)
    {
      var appointment = await _repository.GetByIdAsync(appointmentId);

      return new()
      {
        AppointmentId = appointment.AppointmentId,
        Date = appointment.Date,
        Surgery = appointment.Surgery,
        Diagnostic = appointment.Diagnostic,
        PatientId = appointment?.PatientId,
        DoctorId = appointment.DoctorId
      };
    }
  }
}
