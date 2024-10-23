using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClinicaApi.DTOs.AppointmentDTOs;

namespace ClinicaApi.Services.Interfaces
{
    public interface IAppointmentService
    {
        Task AddAppointmentAsync(AppointmentPostDTO appointmentPostDto);
        Task<IEnumerable<AppointmentDTO>> GetAppointmentsAsync(DateTime? startDate = null, DateTime? endDate = null, int? patientId = null, bool? isActive = null);
        Task UpdateAppointmentAsync(int id, AppointmentUpdateDTO appointmentUpdateDto);
    }
}