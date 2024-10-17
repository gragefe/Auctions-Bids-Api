namespace Application.Services.Interfaces;

using Application.DTO;

public interface ICreateBidsService
{
    public Task<Guid> CreateAsync(Bid DtoBid);
}