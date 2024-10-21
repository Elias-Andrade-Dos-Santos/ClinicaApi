using ClinicaApi.DTOs.PatientDTOs;

namespace ClinicaApi.Services.Interfaces
{
    public interface IPatientService
    {
        Task AddPatientAsync(PatientPostDTO patientPostDto);
        Task<IEnumerable<PatientDTO>> GetAllPatientsAsync(string name = null, string cpf = null, bool? isActive = null);
    }
}