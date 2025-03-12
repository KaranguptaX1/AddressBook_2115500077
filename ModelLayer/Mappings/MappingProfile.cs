using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using ModelLayer.Model;
using ModelLayer.DTO;
namespace ModelLayer.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Contact, ContactDTO>();
            CreateMap<CreateContactDTO, Contact>();
            CreateMap<UpdateContactDTO, Contact>();
        }
    }
}
