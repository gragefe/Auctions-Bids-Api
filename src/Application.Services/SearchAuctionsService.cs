namespace Application.Services;

using Application.DTO;
using Application.Services.Interfaces;
using AutoMapper;
using Domain.Model.Interfaces;


public class SearchBidsService : ISearchBidsService
{
    private readonly IMapper _mapper;
    private readonly IRepository _repository;

    public SearchBidsService(
        IMapper mapper,
        IRepository repository)
    {
        _mapper = mapper;
        _repository = repository;
    }

    public async Task<List<Bid>> SearchAsync(SearchContext searchContextDto)
    {
        var searchContext = _mapper.Map<Domain.Model.SearchContext>(searchContextDto);

        var result = await _repository.SearchAsync(searchContext);

        // Check it and mapfrom domain to dto
        return new List<Bid>();
    }
}