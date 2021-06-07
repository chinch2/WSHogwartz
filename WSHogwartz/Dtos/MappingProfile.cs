using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WSHogwartz.Models;

namespace WSHogwartz.Dtos
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Application, ApplicationDto>();
            CreateMap<ApplicationDto, Application>();
            CreateMap<Application, CreateApplicationDto>();
            CreateMap<CreateApplicationDto, Application>();
            CreateMap<Application, UpdateApplicationDto>();
            CreateMap<UpdateApplicationDto, Application>();
        }
    }
}
