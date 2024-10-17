namespace Application.Services;

using AutoMapper;
using DTO = Application.DTO;
using Domain = Domain.Model;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<DTO.Bid, Domain.Entities.Bid>();
        CreateMap<Domain.Entities.Bid, DTO.Bid>();

        CreateMap<DTO.SearchContext, Domain.SearchContext>();
    }
}