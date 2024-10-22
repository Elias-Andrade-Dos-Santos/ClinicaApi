using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ClinicaApi.DTOs.AppointmentDTOs;
using ClinicaApi.Models;
using ClinicaApi.Repositories.Interfaces;
using ClinicaApi.Services.Interfaces;
using FluentValidation;

namespace ClinicaApi.Services
{
    public class AppointmentService : IAppointmentService
    {
        private readonly IAppointmentRepository _appointmentRepository;
        private readonly IValidator<AppointmentPostDTO> _validatorPost;
        private readonly IMapper _mapper;

        public AppointmentService(IAppointmentRepository appointmentRepository,IValidator<AppointmentPostDTO> validatorPost, IMapper mapper)
        {
             _appointmentRepository = appointmentRepository;
             _validatorPost = validatorPost;
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
    }
}