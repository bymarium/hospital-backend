using Hospital.Api.Dtos;
using Hospital.Api.Models;
using Hospital.Api.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Hospital.Api.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class DoctorController : ControllerBase
  {
    private readonly IService<DoctorDto> _service;

    public DoctorController (IService<DoctorDto> service)
    {
      _service = service;
    }

    [HttpPost("Create")]
    public async Task<IActionResult> Create([FromBody] DoctorDto doctorDto)
    {
      try
      {
        return StatusCode(StatusCodes.Status201Created, await _service.CreateAsync(doctorDto));
      }
      catch (Exception exception)
      {
        return StatusCode(StatusCodes.Status404NotFound, new { Error = exception.Message });
      }
    }

    [HttpPut("Update")]
    public async Task<IActionResult> Update([FromBody] DoctorDto doctorDto)
    {
      try
      {
        return StatusCode(StatusCodes.Status200OK, await _service.UpdateAsync(doctorDto));
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

    [HttpGet("GetById")]
    public async Task<IActionResult> GetById(int doctorId)
    {
      return StatusCode(StatusCodes.Status200OK, await _service.GetByIdAsync(doctorId));
    }
  }
}
