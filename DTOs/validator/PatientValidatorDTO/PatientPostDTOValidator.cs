using ClinicaApi.DTOs.PatientDTOs;
using ClinicaApi.Repositories.Interfaces;
using FluentValidation;

namespace ClinicaApi.DTOs.validator.PatientValidatorDTO
{
    public class PatientPostDTOValidator: AbstractValidator<PatientPostDTO>
    {
        private readonly IPatientRepository _patientRepository;

        public PatientPostDTOValidator(IPatientRepository patientRepository)
        {
            _patientRepository = patientRepository;

            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("O nome é obrigatório.")
                .MinimumLength(3).WithMessage("O nome deve ter no mínimo 3 caracteres.");

            RuleFor(p => p.CPF)
                .NotEmpty().WithMessage("O CPF é obrigatório.")
                .Length(11).WithMessage("O CPF deve ter 11 dígitos.")
                .MustAsync(BeUniqueCPF).WithMessage("O CPF já está cadastrado.");

            RuleFor(p => p.DateOfBirth)
                .NotEmpty().WithMessage("A data de nascimento é obrigatória.")
                .LessThan(DateTime.Now).WithMessage("A data de nascimento deve ser no passado.");

            RuleFor(p => p.Gender)
                .NotEmpty().WithMessage("O CPF é obrigatório.");

        }
        private async Task<bool> BeUniqueCPF(string cpf, CancellationToken cancellationToken)
        {
            return !await _patientRepository.ExistsByCPFAsync(cpf);
        }
        
    }
}