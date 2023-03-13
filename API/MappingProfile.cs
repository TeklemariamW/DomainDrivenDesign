using AutoMapper;
using Entities.DataTransferObjects;
using Entities.Models;

namespace API
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Owner, OwnerDto>();
        }
    }
}
