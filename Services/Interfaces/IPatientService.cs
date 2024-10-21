using ClinicaApi.DTOs.PatientDTOs;

namespace ClinicaApi.Services.Interfaces
{
    public interface IPatientService
    {
        Task AddPatientAsync(PatientPostDTO patientPostDto);
    }
}