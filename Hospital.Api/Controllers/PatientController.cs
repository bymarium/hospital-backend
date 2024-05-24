using Hospital.Api.Dtos;
using Hospital.Api.Models;
using Hospital.Api.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Hospital.Api.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class PatientController : ControllerBase
  {
    private readonly IService<PatientDto> _service;

    public PatientController(IService<PatientDto> service)
    {
      _service = service;
    }

    [HttpPost("Create")]
    public async Task<IActionResult> Create([FromBody] PatientDto patientDto)
    {
      try
      {
        return StatusCode(StatusCodes.Status201Created, await _service.CreateAsync(patientDto));
      }
      catch (Exception exception)
      {
        ErrorDto errorDto = new ErrorDto(exception.Message);
        return StatusCode(StatusCodes.Status400BadRequest, errorDto);
      }
    }

    [HttpPut("Update")]
    public async Task<IActionResult> Update([FromBody] PatientDto patientDto)
    {
      try
      {
        return StatusCode(StatusCodes.Status200OK, await _service.UpdateAsync(patientDto));
      }
      catch (Exception exception)
      {
        ErrorDto errorDto = new ErrorDto(exception.Message);
        return StatusCode(StatusCodes.Status400BadRequest, errorDto);
      }
    }

    [HttpDelete("Delete")]
    public async Task<IActionResult> Delete(int patientId)
    {
      try
      {
        return StatusCode(StatusCodes.Status200OK, await _service.DeleteAsync(patientId));
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
    public async Task<IActionResult> GetById(int patientId)
    {
      return StatusCode(StatusCodes.Status200OK, await _service.GetByIdWithDetailsAsync(patientId));
    }
  }
}
