namespace Application.Services;

using Application.Services.Interfaces;
using AutoMapper;
using Domain.Model.Interfaces;
using Infrastructure.Crosscutting.Validations;
using DTO = Application.DTO;


public class GetByIdBidsService : IGetByIdBidsService
{
    private readonly IMapper _mapper;
    private readonly IRepository _repository;

    public GetByIdBidsService(
        IMapper mapper,
        IRepository repository)
    {
        _mapper = mapper;
        _repository = repository;
    }

    public async Task<DTO.Bid> GetByIdAsync(Guid id)
    {
        var bid = await _repository.GetByIdAsync(id);

        if (bid == null)
        {
            throw new CustomValidationException(CustomValidationMessages.NonExistentAuction);
        }

        var bidDto = _mapper.Map<DTO.Bid>(bid);

        return bidDto;
    }
}