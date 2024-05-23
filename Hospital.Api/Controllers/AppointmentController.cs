using Hospital.Api.Dtos;
using Hospital.Api.Models;
using Hospital.Api.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Hospital.Api.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class AppointmentController : ControllerBase
  {
    private readonly IAppointmentService _service;

    public AppointmentController(IAppointmentService service)
    {
      _service = service;
    }

    [HttpPost("Create")]
    public async Task<IActionResult> Create([FromBody] AppointmentDto appointmentDto)
    {
      try
      {
        return StatusCode(StatusCodes.Status201Created, await _service.CreateAsync(appointmentDto));
      }
      catch (Exception exception)
      {
        ErrorDto errorDto = new ErrorDto(exception.Message);
        return StatusCode(StatusCodes.Status400BadRequest, errorDto);
      }
    }

    [HttpPut("Update")]
    public async Task<IActionResult> Update([FromBody] AppointmentDto appointmentDto)
    {
      try
      {
        return StatusCode(StatusCodes.Status200OK, await _service.UpdateAsync(appointmentDto));
      }
      catch (Exception exception)
      {
        ErrorDto errorDto = new ErrorDto(exception.Message);
        return StatusCode(StatusCodes.Status400BadRequest, errorDto);
      }
    }

    [HttpDelete("Delete")]
    public async Task<IActionResult> Delete(int appointmentId)
    {
      try
      {
        return StatusCode(StatusCodes.Status200OK, await _service.DeleteAsync(appointmentId));
      }
      catch (Exception exception)
      {
        ErrorDto errorDto = new ErrorDto(exception.Message);
        return StatusCode(StatusCodes.Status400BadRequest, errorDto);
      }
    }

    [HttpGet("GetAll")]
    public async Task<IActionResult> GetAll()
    {
      return StatusCode(StatusCodes.Status200OK, await _service.GetAllAsync());
    }

    [HttpGet("GetById")]
    public async Task<IActionResult> GetById(int appointmentId)
    {
      return StatusCode(StatusCodes.Status200OK, await _service.GetByIdAsync(appointmentId));
    }

    [HttpGet("GetByAge")]
    public async Task<IActionResult> GetByAge(int age)
    {
      try
      {
        var appointments = await _service.GetAppointmentsByAgeAsync(age);
        return StatusCode(StatusCodes.Status200OK, appointments);
      }
      catch (Exception exception)
      {
        ErrorDto errorDto = new ErrorDto(exception.Message);
        return StatusCode(StatusCodes.Status400BadRequest, errorDto);
      }
    }
  }
}
