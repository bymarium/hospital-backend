﻿using Hospital.Api.Dtos;
using Hospital.Api.Models;
using Hospital.Api.Repositories.Interfaces;
using Hospital.Api.Services.Interfaces;

namespace Hospital.Api.Services
{
  public class DoctorService : IService<DoctorDto>
  {
    private readonly IRepository<Doctor> _repository;

    public DoctorService(IRepository<Doctor> repository)
    {
      _repository = repository;
    }

    public async Task<DoctorDto> CreateAsync(DoctorDto doctorDto)
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

      return new()
      {
        DoctorId = doctor.DoctorId,
        Name = doctor.Name,
        Specialization = doctor.Specialization,
        Email = doctor.Email,
        Password = doctor.Password,
        RoleId = doctor.RoleId
      };
    }

    public async Task<DoctorDto> UpdateAsync(DoctorDto doctorDto)
    {
      var currentDoctor = await _repository.GetByIdAsync(doctorDto.DoctorId);

      if (currentDoctor == null)
      {
        throw new Exception("Doctor not found");
      }

      var entity = new Doctor
      {
        DoctorId = doctorDto.DoctorId,
        Name = doctorDto.Name,
        Specialization = doctorDto.Specialization,
        Email = doctorDto.Email,
        Password = doctorDto.Password,
        RoleId = doctorDto.RoleId
      };

      if (!await _repository.UpdateAsync(entity))
      {
        throw new Exception("Doctor not update");
      }

      return doctorDto;
    }

    public async Task<DoctorDto> DeleteAsync(int doctorId)
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

      return new()
      {
        DoctorId = doctor.DoctorId,
        Name = doctor.Name,
        Specialization = doctor.Specialization,
        Email = doctor.Email,
        Password = doctor.Password,
        RoleId = doctor.RoleId
      };
    }

    public async Task<IEnumerable<DoctorDto>> GetAllAsync()
    {
      var doctors = await _repository.GetAllAsync();

      return doctors.Select(doctor => new DoctorDto
      {
        DoctorId = doctor.DoctorId,
        Name = doctor.Name,
        Specialization = doctor.Specialization,
        Email = doctor.Email,
        Password = doctor.Password,
        RoleId = doctor.RoleId,
        Appointments = doctor.Appointments != null ? doctor.Appointments.Select(appointment => new AppointmentDto
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
            Email = appointment.Patient.Email,
            RoleId = appointment.Patient.RoleId
          } : null
        }).ToList() : null
    });
    }

    public async Task<DoctorDto> GetByIdAsync(int doctorId)
    {
      var doctor = await _repository.GetByIdAsync(doctorId);

      return new()
      {
        DoctorId = doctor.DoctorId,
        Name = doctor.Name,
        Specialization = doctor.Specialization,
        Email = doctor.Email,
        Password = doctor.Password,
        RoleId = doctor.RoleId
      };
    }
  }
}
