using AutoMapper;
 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Model;
using cleanArchitectureBiblo.ModelDTO;

namespace Application.MapperConfig
{
    public class MapperConfig:Profile
    {
        public MapperConfig()
        {
            CreateMap<LivreDTO,Livre>().ReverseMap();
            CreateMap<AdherentDTO, Adherent>().ReverseMap();

        }
    }
}
