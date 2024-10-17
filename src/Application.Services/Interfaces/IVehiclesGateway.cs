namespace Application.Services.Interfaces;

using Application.DTO;
using Infrastructure.Crosscutting.GatewayEntites;

public interface IVehiclesGateway
{
    Task<Vehicle> GetVehicle(Guid Id);
}