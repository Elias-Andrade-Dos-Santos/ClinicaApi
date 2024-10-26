using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClinicaApi.DTOs.AppointmentDTOs;
using ClinicaApi.Repositories.Interfaces;
using FluentValidation;

namespace ClinicaApi.DTOs.validator.AppointmentValidatorDTO
{
    public class AppointmentPostDTOValidator : AbstractValidator<AppointmentPostDTO>
    {
        private readonly IPatientRepository _patientRepository;

        public AppointmentPostDTOValidator(IPatientRepository patientRepository)
        {
            _patientRepository = patientRepository;

            RuleFor(a => a.PatientId)
                .NotNull().WithMessage("O ID do paciente é obrigatório.")
                .MustAsync(ExistsInDatabase).WithMessage("Paciente não encontrado.");

            
            RuleFor(a => a.DateTime)
                .LessThanOrEqualTo(DateTime.Now).WithMessage("A data do atendimento deve ser até a data e hora atual.");

            
            RuleFor(a => a.Description)
                .NotEmpty().WithMessage("A descrição do atendimento é obrigatória.")
                .MinimumLength(10).WithMessage("A descrição deve ter no mínimo 10 caracteres.");
        }

        private async Task<bool> ExistsInDatabase(int patientId, CancellationToken cancellationToken)
        {
           
            return await _patientRepository.GetByIdAsync(patientId) != null;
        }
    }
}