using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using MVCVidly.DTOs;
using MVCVidly.Models;

namespace MVCVidly.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // CreateMap is a generic method from AutoMapper that takes 2 parameters: source and target
            CreateMap<Customer, CustomerDto>()
                .ForMember(c => c.Id, opt => opt.Ignore());
            CreateMap<CustomerDto, Customer>();
            CreateMap<Movie, MovieDto>()
                .ForMember(m => m.Id, opt => opt.Ignore());
            CreateMap<MovieDto, Movie>();

        }
    }
}