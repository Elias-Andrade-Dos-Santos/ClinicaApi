using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClinicaApi.DTOs.AppointmentDTOs;
using ClinicaApi.Repositories.Interfaces;
using FluentValidation;

namespace ClinicaApi.DTOs.validator.AppointmentValidatorDTO
{
    public class AppointmentUpdateDTOValidator : AbstractValidator<AppointmentUpdateDTO>
    {
        private readonly IPatientRepository _patientRepository;
        public AppointmentUpdateDTOValidator(IPatientRepository patientRepository)
        {
            _patientRepository = patientRepository;

            // Regra: PatientId é obrigatório e o paciente deve existir
            RuleFor(a => a.PatientId)
                .NotNull().WithMessage("O ID do paciente é obrigatório.")
                .MustAsync(ExistsInDatabase).WithMessage("Paciente não encontrado.");

            // Regra: Data e hora do atendimento deve ser uma data futura
            RuleFor(a => a.DateTime)
                .GreaterThan(DateTime.Now).WithMessage("A data do atendimento deve ser uma data futura.");

            // Regra: Descrição é obrigatória e deve ter no mínimo 10 caracteres
            RuleFor(a => a.Description)
                .NotEmpty().WithMessage("A descrição do atendimento é obrigatória.")
                .MinimumLength(10).WithMessage("A descrição deve ter no mínimo 10 caracteres.");
        }

        private async Task<bool> ExistsInDatabase(int patientId, CancellationToken cancellationToken)
        {
            // Verifica se o paciente existe no banco de dados usando o repositório
            return await _patientRepository.GetByIdAsync(patientId) != null;
        }
        
    }
}