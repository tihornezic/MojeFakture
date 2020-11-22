using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using MojeFakture.Dtos;
using MojeFakture.Models;

namespace MojeFakture.App_Start
{
    public class MappingProfile : Profile
    {
        
        public MappingProfile()
        {
            // Domain to Dto
            Mapper.CreateMap<Faktura, FakturaDto>();
            Mapper.CreateMap<Stavka, StavkaDto>();
            Mapper.CreateMap<Porez, PorezDto>();
            Mapper.CreateMap<Stavka, StavkaDtoDto>();

            // Dto to Domain
            Mapper.CreateMap<FakturaDto, Faktura>()
                .ForMember(f => f.Id, opt => opt.Ignore());

            Mapper.CreateMap<StavkaDto, Stavka>()
                .ForMember(s => s.Id, opt => opt.Ignore());
        }
    }
}