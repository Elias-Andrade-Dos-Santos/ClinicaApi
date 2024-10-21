using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClinicaApi.DTOs.PatientDTOs;
using ClinicaApi.Services.Interfaces;

namespace ClinicaApi.Services
{
    public class PatientService : IPatientService
    {
        public Task AddPatientAsync(PatientPostDTO patientPostDto)
        {
            throw new NotImplementedException();
        }
    }
}