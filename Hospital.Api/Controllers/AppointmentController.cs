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
        return StatusCode(StatusCodes.Status404NotFound, new { Error = exception.Message });
      }
    }

    [HttpPut("Update")]
    public async Task<IActionResult> Update([FromBody] Appointment appointment)
    {
      try
      {
        return StatusCode(StatusCodes.Status200OK, await _service.UpdateAsync(appointment));
      }
      catch (Exception exception)
      {
        return StatusCode(StatusCodes.Status400BadRequest, new { Error = exception.Message });
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
        return StatusCode(StatusCodes.Status400BadRequest, new { Error = exception.Message });
      }
    }

    [HttpGet("GetAll")]
    public async Task<IActionResult> GetAll()
    {
      return StatusCode(StatusCodes.Status200OK, await _service.GetAllAsync());
    }
  }
}
