using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClinicaApi.DTOs.PatientDTOs;
using ClinicaApi.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ClinicaApi.Controllers
{
    [ApiController]
    [Route("api/Patients")]
    public class PatientsController : ControllerBase
    {
        private readonly IPatientService _patientService;
        public PatientsController(IPatientService patientService)
        {
            _patientService = patientService;
        }
        [HttpPost]
        public async Task<ActionResult> AddPatient([FromBody] PatientPostDTO patientPostDto)
        {
            try
            {
                await _patientService.AddPatientAsync(patientPostDto);
                return Ok();
                // return CreatedAtAction(nameof(GetPatientById), new { id = patientPostDto.CPF }, patientPostDto);
            }
            catch (FluentValidation.ValidationException ex)
            {
               var errors = ex.Errors.Select(e => new { Field = e.PropertyName, Error = e.ErrorMessage });
                return BadRequest(new { Errors = errors });
            }
        }
    }
}