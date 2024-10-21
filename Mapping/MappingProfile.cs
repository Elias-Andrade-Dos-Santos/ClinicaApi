using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ClinicaApi.DTOs.PatientDTOs;
using ClinicaApi.Models;

namespace ClinicaApi.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<PatientPostDTO, Patient>();
        }
    }
}