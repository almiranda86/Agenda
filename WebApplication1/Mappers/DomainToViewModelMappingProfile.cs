using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Mappers
{
    public class DomainToViewModelMappingProfile:Profile 
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<Agenda.Model.ContatoModel, Agenda.Model.ContatoModel>();
        }
    }
}