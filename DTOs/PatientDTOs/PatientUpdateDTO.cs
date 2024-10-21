using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClinicaApi.DTOs.AddressDTOs;

namespace ClinicaApi.DTOs.PatientDTOs
{
    public class PatientUpdateDTO
    {
        public string Name { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string CPF { get; set; }
        public string Gender { get; set; }
        public AddressDTO Address { get; set; }
    }
}