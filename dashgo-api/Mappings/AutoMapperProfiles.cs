using AutoMapper;
using dashgo_api.Models.Domain;
using dashgo_api.Models.Dtos;

namespace dashgo_api.Mappings
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<AddPropertyRequestDto, Property>().ReverseMap();
            CreateMap<Property, PropertyDto>().ReverseMap();
            CreateMap<UpdatePropertyRequestDto, Property>().ReverseMap();
        }
    }
}
