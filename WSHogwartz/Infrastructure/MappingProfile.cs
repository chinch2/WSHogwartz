using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WSHogwartz.Domain.Models;
using WSHogwartz.Dtos;
using WSHogwartz.Repository.Models;

namespace WSHogwartz.Infrastructure
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<ApplicationDto, ApplicationDomain>();
            CreateMap<ApplicationDomain, ApplicationDto>();
            CreateMap<CreateApplicationDto, ApplicationDomain>();
            CreateMap<ApplicationDomain, CreateApplicationDto>();
            CreateMap<UpdateApplicationDto, ApplicationDomain>();
            CreateMap<ApplicationDomain, UpdateApplicationDto>();
            CreateMap<ApplicationDomain, Application>();
            CreateMap<Application, ApplicationDomain>();
        }
    }
}
