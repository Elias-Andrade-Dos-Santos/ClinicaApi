using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClinicaApi.DTOs.AppointmentDTOs
{
    public class AppointmentDTO
    {
        public int PatientId { get; set; }
        public DateTime DateTime { get; set; }
        public required string Description { get; set; }
        public bool IsActive { get; set; }
    }
}