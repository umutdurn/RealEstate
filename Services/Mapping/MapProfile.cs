using AutoMapper;
using Core.DTOs;
using Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Mapping
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            CreateMap<RealEstate, RealEstateDto>().ReverseMap();
        }
    }
}
