using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClinicaApi.Models
{
    public class Patient
    {
        public int Id { get; set; }
        public  string Name { get; set; }
        public  DateTime DateOfBirth { get; set; }
        public  string CPF { get; set; }
        public  string Gender { get; set; }
        public Address Address { get; set; }
        public bool IsActive { get; set; }

    }
}