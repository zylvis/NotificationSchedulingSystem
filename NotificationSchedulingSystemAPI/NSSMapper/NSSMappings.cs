using AutoMapper;
using NotificationSchedulingSystemAPI.Models;
using NotificationSchedulingSystemAPI.Models.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NotificationSchedulingSystemAPI.NSSMapper
{
    public class NSSMappings : Profile
    {
        public NSSMappings()
        {
            CreateMap<Company, CompanyDto>().ReverseMap();
        }
    }
}
