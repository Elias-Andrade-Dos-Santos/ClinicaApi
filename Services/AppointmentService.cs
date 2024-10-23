using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ClinicaApi.DTOs.AppointmentDTOs;
using ClinicaApi.Models;
using ClinicaApi.Repositories.Interfaces;
using ClinicaApi.Services.Interfaces;
using ClinicaAPI.Exceptions;
using FluentValidation;

namespace ClinicaApi.Services
{
    public class AppointmentService : IAppointmentService
    {
        private readonly IAppointmentRepository _appointmentRepository;
        private readonly IValidator<AppointmentPostDTO> _validatorPost;
        private readonly IValidator<AppointmentUpdateDTO> _validatorUpdate;
        private readonly IMapper _mapper;

        public AppointmentService(IAppointmentRepository appointmentRepository,IValidator<AppointmentPostDTO> validatorPost,IValidator<AppointmentUpdateDTO> validatorUpdate, IMapper mapper)
        {
             _appointmentRepository = appointmentRepository;
             _validatorPost = validatorPost;
             _validatorUpdate = validatorUpdate;
             _mapper = mapper;
        }
        public async Task AddAppointmentAsync(AppointmentPostDTO appointmentPostDto)
        {
            var validationResult = await _validatorPost.ValidateAsync(appointmentPostDto);
            if (!validationResult.IsValid)
                throw new ValidationException(validationResult.Errors);
            
            var appointment = _mapper.Map<Appointment>(appointmentPostDto);
            appointment.IsActive = true;
            await _appointmentRepository.AddAsync(appointment);
        }

        public async Task DeleteAppointmentAsync(int id)
        {
            var appointment = await _appointmentRepository.GetByIdAsync(id);
            if (appointment == null)
                throw new NotFoundException("Atendimento não encontrado");
            await _appointmentRepository.DeleteAsync(id);

        }

        public async Task<IEnumerable<AppointmentDTO>> GetAppointmentsAsync(DateTime? startDate = null, DateTime? endDate = null, int? patientId = null, bool? isActive = null)
        {
            var appointments = await _appointmentRepository.GetAllAsync();

            if (startDate.HasValue && endDate.HasValue)
            {
                appointments = appointments.Where(a => a.DateTime >= startDate.Value && a.DateTime <= endDate.Value);
            }
            if (patientId.HasValue)
            {
                appointments = appointments.Where(a => a.PatientId == patientId.Value);
            }
            if (isActive.HasValue)
            {
                appointments = appointments.Where(a => a.IsActive == isActive.Value);
            }

            return appointments.Select(a => _mapper.Map<AppointmentDTO>(a));
        }


        public async Task UpdateAppointmentAsync(int id, AppointmentUpdateDTO appointmentUpdateDto)
        {
            var appointment = await _appointmentRepository.GetByIdAsync(id);
            if (appointment == null)
                throw new NotFoundException("Atendimento não encontrado");

            var validationResult = await _validatorUpdate.ValidateAsync(appointmentUpdateDto);
            if (!validationResult.IsValid)
                throw new ValidationException(validationResult.Errors);

            appointment.PatientId = appointment.PatientId = appointmentUpdateDto.PatientId != 0 ? appointmentUpdateDto.PatientId : appointment.PatientId;
            appointment.DateTime = appointmentUpdateDto.DateTime;
            appointment.Description = appointmentUpdateDto.Description;

            await _appointmentRepository.UpdateAsync(appointment);
        }
    }
}