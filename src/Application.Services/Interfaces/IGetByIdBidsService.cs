namespace Application.Services.Interfaces;

using Application.DTO;

public interface IGetByIdBidsService
{
    public Task<Bid> GetByIdAsync(Guid Id);
}