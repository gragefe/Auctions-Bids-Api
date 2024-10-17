namespace Infrastructure.Gateways.HttpGateways;

using Application.Services.Interfaces;
using Infrastructure.Crosscutting.GatewayEntites;

public class AuctionsHttpGateway : IAuctionsGateway
{
    Task<Auction> IAuctionsGateway.GetAuction(Guid Id)
    {
        return null;
    }
}