using ClinicaApi.DTOs.PatientDTOs;
using ClinicaApi.Models;

namespace ClinicaApi.Services.Interfaces
{
    public interface IPatientService
    {
        Task AddPatientAsync(PatientPostDTO patientPostDto);
        Task<IEnumerable<PatientDTO>> GetAllPatientsAsync(string name = null, string cpf = null, bool? isActive = null);
        Task<PatientDTO> GetPatientByIdAsync(int id);
        Task UpdatePatientAsync(int id, PatientUpdateDTO patientUpdate);
        Task DeletePatientAsync(int id);
    }
}