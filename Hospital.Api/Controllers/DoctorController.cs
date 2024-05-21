using Hospital.Api.Models;
using Hospital.Api.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Hospital.Api.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class DoctorController : ControllerBase
  {
    private readonly IService<Doctor> _service;

    public DoctorController(IService<Doctor> service)
    {
      _service = service;
    }

    [HttpPost("Create")]
    public async Task<IActionResult> Create()
    {
      try
      {
        return StatusCode(StatusCodes.Status201Created, await _service.CreateAsync());
      }
      catch (Exception exception)
      {
        return StatusCode(StatusCodes.Status404NotFound, new { Error = exception.Message });
      }
    }

    [HttpPut("Update")]
    public async Task<IActionResult> Update([FromBody] Doctor doctor)
    {
      try
      {
        return StatusCode(StatusCodes.Status200OK, await _service.UpdateAsync(doctor));
      }
      catch (Exception exception)
      {
        return StatusCode(StatusCodes.Status400BadRequest, new { Error = exception.Message });
      }
    }

    [HttpDelete("Delete")]
    public async Task<IActionResult> Delete(int doctorId)
    {
      try
      {
        return StatusCode(StatusCodes.Status200OK, await _service.DeleteAsync(doctorId));
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
