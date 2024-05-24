using Hospital.Api.Dtos;
using Hospital.Api.Models;
using Hospital.Api.Services.Interfaces;
using Microsoft.AspNetCore.HttpLogging;
using Microsoft.AspNetCore.Mvc;

namespace Hospital.Api.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class AuthenticationController : ControllerBase
  {
    private readonly IAuthenticationService _service;
    public AuthenticationController(IAuthenticationService service)
    {
      _service = service;
    }

    [HttpPost("Authenticate")]
    public async Task<IActionResult> Authentication([FromBody] CredentialsDto credentialsDto)
    {
      try
      {
        return StatusCode(StatusCodes.Status200OK, await _service.AutheticateAsync(credentialsDto));
      }
      catch (Exception exception)
      {
        ErrorDto errorDto = new ErrorDto(exception.Message);
        return StatusCode(StatusCodes.Status400BadRequest, errorDto);
      }
    }
  }
}
