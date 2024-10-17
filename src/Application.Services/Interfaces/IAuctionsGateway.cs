namespace Application.Services.Interfaces;

using Infrastructure.Crosscutting.GatewayEntites;

public interface IAuctionsGateway
{
    Task<Auction> GetAuction(Guid Id);
}