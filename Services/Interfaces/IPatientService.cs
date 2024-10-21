using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClinicaApi.DTOs.PatientDTOs;

namespace ClinicaApi.Services.Interfaces
{
    public interface IPatientService
    {
        Task AddPatientAsync(PatientPostDTO patientPostDto);
    }
}