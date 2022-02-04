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

            // Domain to DTO
            CreateMap<Customer, CustomerDto>()
                .ForMember(c => c.Id, opt => opt.Ignore());
            CreateMap<Movie, MovieDto>()
                .ForMember(m => m.Id, opt => opt.Ignore());
            CreateMap<MembershipType, MembershipTypeDto>();

            // DTO to domain
            CreateMap<CustomerDto, Customer>();
            CreateMap<MovieDto, Movie>();

        }
    }
}