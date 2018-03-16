using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Mappers
{
    public class AutoMapperConfig
    {
        public static void RegistrarMapeamento()
        {
            Mapper.Initialize(_ => {
                _.AddProfile<ViewModelToDomainMappingProfile>();
                _.AddProfile<DomainToViewModelMappingProfile>();
            });

        }
    }
}