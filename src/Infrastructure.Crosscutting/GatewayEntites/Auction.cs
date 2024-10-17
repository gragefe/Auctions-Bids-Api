namespace Infrastructure.Crosscutting.GatewayEntites;

using Infrastructure.Crosscutting.Enum;

public class Auction
{
    public Guid Id { get; set; }

    public Guid VehicleId { get; set; }

    public AuctionStatus Status { get; set; }
}