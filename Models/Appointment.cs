using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClinicaApi.Models
{
    public class Appointment
    {
        public int Id { get; set; }
        public int PatientId { get; set; }
        public Patient Patient { get; set; }
        public DateTime DateTime { get; set; } 
        public string Description { get; set; }
        public bool IsActive { get; set; }
    }
}