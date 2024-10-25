using AutoMapper;
using ClinicaApi.DTOs.AddressDTOs;
using ClinicaApi.DTOs.PatientDTOs;
using ClinicaApi.Models;
using ClinicaApi.Repositories.Interfaces;
using ClinicaApi.Services.Interfaces;
using ClinicaAPI.Exceptions;
using FluentValidation;

namespace ClinicaApi.Services
{
    public class PatientService : IPatientService
    {
        private readonly IPatientRepository _patientRepository;
        private readonly IValidator<PatientPostDTO> _validatorPost;
         private readonly IValidator<PatientUpdateDTO> _validatorUpdate;
        private readonly IAddressRepository _addressRepository;
        private readonly IMapper _mapper;
        public PatientService(IPatientRepository patientRepository,IAddressRepository addressRepository,IValidator<PatientPostDTO> validatorPost,IValidator<PatientUpdateDTO> validatorUpdate,IMapper mapper)
        {
            _patientRepository = patientRepository;
            _addressRepository = addressRepository; 
            _validatorPost = validatorPost;
            _validatorUpdate = validatorUpdate;
            _mapper = mapper;  
        }
        public async Task AddPatientAsync(PatientPostDTO patientPostDto)
        {

            var validationResult = await _validatorPost.ValidateAsync(patientPostDto);
            if (!validationResult.IsValid)
            {
                
                throw new ValidationException(validationResult.Errors);
            }

            var patient = _mapper.Map<Patient>(patientPostDto);

            patient.IsActive = true;

            await _patientRepository.AddAsync(patient);

            var newPatientId = patient.Id;

            if (patientPostDto.Address != null)
            {
                
                var address = _mapper.Map<Address>(patientPostDto.Address);
                address.PatientId = newPatientId; 
                
                await _addressRepository.AddAsync(address);
            }
        }

        public async Task DeletePatientAsync(int id)
        {
            var patient = await _patientRepository.GetByIdAsync(id);
            if (patient == null)
                throw new NotFoundException("Paciente não encontrado");
                
            await _patientRepository.DeleteAsync(id);
        }

        public async Task<IEnumerable<PatientDTO>> GetAllPatientsAsync(string name = null, string cpf = null, bool? isActive = null)
        {
            var patients = await _patientRepository.GetAllAsync();
            
            if (!string.IsNullOrEmpty(name))
            {
                patients = patients.Where(p => p.Name.Contains(name, StringComparison.OrdinalIgnoreCase));
            }
            if (!string.IsNullOrEmpty(cpf))
            {
                 patients = patients.Where(p => p.CPF == cpf);
            }
            if (isActive.HasValue)
            {
                patients = patients.Where(p => p.IsActive == isActive.Value);
            }

            return patients.Select(a => _mapper.Map<PatientDTO>(a));
        }

        public async Task<PatientDTO> GetPatientByIdAsync(int id)
        {
            var patient = await _patientRepository.GetByIdAsync(id);
            if (patient == null)
                throw new NotFoundException("Paciente não encontrado");

            return new PatientDTO
            {
                Id = patient.Id,
                Name = patient.Name,
                DateOfBirth = patient.DateOfBirth,
                CPF = patient.CPF,
                Gender = patient.Gender,
                Address = _mapper.Map<AddressDTO>(patient.Address),
                IsActive = patient.IsActive
            };

        }

        public async Task InactivatePatientAsync(int id)
        {
            var patient = await _patientRepository.GetByIdAsync(id);
            
            if (patient == null)
                throw new NotFoundException("Paciente não encontrado");
            patient.IsActive = false; 

            await _patientRepository.UpdateAsync(patient);
        }

        public async Task UpdatePatientAsync(int id, PatientUpdateDTO patientUpdate)
        {
            var patient = await _patientRepository.GetByIdAsync(id);
            if (patient == null)
            throw new NotFoundException("Paciente não encontrado");

            var validationResult = await _validatorUpdate.ValidateAsync(patientUpdate);
            if (!validationResult.IsValid)
            {
                throw new ValidationException(validationResult.Errors);
            }

            patient.Name = patientUpdate.Name;
            patient.DateOfBirth = patientUpdate.DateOfBirth;
            patient.CPF = patientUpdate.CPF;
            patient.Gender = patientUpdate.Gender;
            patient.Address = _mapper.Map<Address>(patientUpdate.Address);

            await _patientRepository.UpdateAsync(patient);
        }
    }
}