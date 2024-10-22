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
    }
}