﻿using Hospital.Api.Models;
using Hospital.Api.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Hospital.Api.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class PatientController : ControllerBase
  {
    private readonly IService<Patient> _service;

    public PatientController(IService<Patient> service)
    {
      _service = service;
    }

    [HttpPost("Create")]
    public async Task<IActionResult> Create([FromBody] Patient patient)
    {
      try
      {
        return StatusCode(StatusCodes.Status201Created, await _service.CreateAsync(patient));
      }
      catch (Exception exception)
      {
        return StatusCode(StatusCodes.Status400BadRequest, new { Error = exception.Message });
      }
    }
  }
}
