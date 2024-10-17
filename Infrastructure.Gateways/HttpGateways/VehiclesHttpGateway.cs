namespace Infrastructure.Gateways.HttpGateways;

using Application.Services.Interfaces;
using Infrastructure.Crosscutting.GatewayEntites;

public class VehiclesHttpGateway : IVehiclesGateway
{
    public async Task<Vehicle> GetVehicle(Guid VehicleId)
    {
        return null;
    }
}