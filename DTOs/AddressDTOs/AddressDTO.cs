using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ClinicaApi.DTOs.AddressDTOs
{
    public class AddressDTO
    {
        public string Street { get; set; }
        public string Number { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string PostalCode { get; set; }
        [JsonIgnore]
        public int PatientId { get; set; }
    }
}