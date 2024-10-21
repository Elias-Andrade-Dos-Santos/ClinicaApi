using ClinicaApi.DTOs.PatientDTOs;
using FluentValidation;

namespace ClinicaAPI.DTOs.validator.PatientValidatorDTO
{
    public class PatientUpdateDTOValidator : AbstractValidator<PatientUpdateDTO>
    {

        public PatientUpdateDTOValidator()
        {

            // Regra de validação: Nome é obrigatório e deve ter pelo menos 3 caracteres
            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("O nome é obrigatório.")
                .MinimumLength(3).WithMessage("O nome deve ter no mínimo 3 caracteres.");

            // Regra de validação: CPF é obrigatório, formato correto, e deve ser único (não duplicado)
            RuleFor(p => p.CPF)
                .NotEmpty().WithMessage("O CPF é obrigatório.")
                .Length(11).WithMessage("O CPF deve ter 11 dígitos.");

            // Regra de validação: Data de Nascimento é obrigatória e deve ser uma data válida
            RuleFor(p => p.DateOfBirth)
                .NotEmpty().WithMessage("A data de nascimento é obrigatória.")
                .LessThan(DateTime.Now).WithMessage("A data de nascimento deve ser no passado.");
        }
    }
}