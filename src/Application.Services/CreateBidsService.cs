namespace Application.Services;

using Application.Services.Interfaces;
using AutoMapper;
using Domain.Model.Interfaces;
using Infrastructure.Crosscutting.Enum;
using Infrastructure.Crosscutting.Validations;
using System.ComponentModel.DataAnnotations;
using DTO = Application.DTO;


public class CreateBidsService : ICreateBidsService
{
    private readonly IMapper _mapper;
    private readonly IRepository _repository;
    private readonly IKafkaProducer _KafkaProducer;
    private readonly IAuctionsGateway _auctionsGateway;
    private readonly IVehiclesGateway _vehiclesGateway;

    public CreateBidsService(
        IMapper mapper,
        IRepository repository,
        IKafkaProducer kafkaProducer,
        IAuctionsGateway auctionsGateway,
        IVehiclesGateway vehiclesGateway)
    {
        _mapper = mapper;
        _repository = repository;
        _KafkaProducer = kafkaProducer;
        _auctionsGateway = auctionsGateway;
        _vehiclesGateway = vehiclesGateway;
    }

    public async Task<Guid> CreateAsync(DTO.Bid dtoBid)
    {
        await ValidateAction(dtoBid);
        await ValidateVehicle(dtoBid);

        var bid = _mapper.Map<Domain.Model.Entities.Bid>(dtoBid);

        var validationErrors = bid.Validate();

        if (validationErrors.Count > 0)
        {
            throw new CustomValidationException(validationErrors);
        }

        await _repository.CreateAsync(bid);

        await _KafkaProducer.ProduceAsync("AuctionTopic", "Auction as json");

        return bid.Id;
    }

    private async Task ValidateAction(DTO.Bid dtoAuction)
    {
        var auction = await _auctionsGateway.GetAuction(dtoAuction.AuctionId);

        if (auction == null)
        {
            throw new CustomValidationException(CustomValidationMessages.NonExistentAuction);
        }

        if (auction.Status != AuctionStatus.Active)
        {
            throw new CustomValidationException(CustomValidationMessages.AuctionClosed);
        }
    }

    private async Task ValidateVehicle(DTO.Bid dtoAuction)
    {
        var vehicle = await _vehiclesGateway.GetVehicle(dtoAuction.VehicleId);

        if (vehicle == null)
        {
            throw new CustomValidationException(CustomValidationMessages.NonExistentVehicle);
        }

        if (vehicle.AuctionId == default || vehicle.AuctionId != dtoAuction.AuctionId)
        {
            throw new CustomValidationException(CustomValidationMessages.VehicleDoesNotBelongToThisAuction);
        }
    }
}