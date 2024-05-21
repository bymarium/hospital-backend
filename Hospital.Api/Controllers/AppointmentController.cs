using Hospital.Api.Dtos;
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
  }
}
