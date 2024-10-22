using ClinicaApi.DTOs.AppointmentDTOs;
using ClinicaApi.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ClinicaApi.Controllers
{
    [ApiController]
    [Route("api/Appointments")]
    public class AppointmentsController : ControllerBase
    {
        private readonly IAppointmentService _appointmentService;
        public AppointmentsController(IAppointmentService appointmentService)
        {
            _appointmentService = appointmentService;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AppointmentDTO>>> GetAppointments([FromQuery] DateTime? startDate = null, [FromQuery] DateTime? endDate = null, [FromQuery] int? patientId = null, [FromQuery] bool? isActive = null)
        {
            var appointments = await _appointmentService.GetAppointmentsAsync(startDate, endDate, patientId, isActive);
            return Ok(appointments);
        }

        [HttpPost]
        public async Task<ActionResult> AddAppointment([FromBody] AppointmentPostDTO appointmentDto)
        {
            try
            {
                await _appointmentService.AddAppointmentAsync(appointmentDto);
                return Ok();
            }
            catch (FluentValidation.ValidationException ex)
            {
                
               var errors = ex.Errors.Select(e => new { Field = e.PropertyName, Error = e.ErrorMessage });
                return BadRequest(new { Errors = errors });
            }
        }
    }
}