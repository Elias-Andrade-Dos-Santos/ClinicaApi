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
    }
}