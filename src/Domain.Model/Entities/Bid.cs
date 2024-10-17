namespace Domain.Model.Entities;

using Domain.Model.Validators;

public class Bid
{
    public Guid Id { get; set; }

    public Guid VehicleId { get; set; }

    public Guid AuctionId { get; set; }

    public double Value { get; set; }

    public virtual List<string> Validate()
    {
        var errors = new List<string>();

        if (this.VehicleId == default)
        {
            errors.Add($"{nameof(this.VehicleId)} {CustomValidationMessages.IsRequired}");
        }

        if (this.AuctionId == default)
        {
            errors.Add($"{nameof(this.AuctionId)} {CustomValidationMessages.IsRequired}");
        }

        if (this.Value <= 0)
        {
            errors.Add($"{nameof(this.AuctionId)} {CustomValidationMessages.IsRequired}");
        }

        return errors;
    }
}