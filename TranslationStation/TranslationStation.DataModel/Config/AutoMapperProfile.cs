using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using TranslationStation.DataModel.Models.API;
using TranslationStation.DataModel.Models.EF;

namespace TranslationStation.DataModel.Config
{
    public class AutoMapperProfile : Profile
    {
            public AutoMapperProfile()
            {
                CreateMap<Translation, TranslationDto>().ReverseMap();
            }
    }
}
