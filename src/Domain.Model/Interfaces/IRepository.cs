namespace Domain.Model.Interfaces;

using Domain.Model.Entities;

public interface IRepository
{
    Task<Guid> CreateAsync(Bid Bid);

    Task<Bid> GetByIdAsync(Guid id);

    Task<List<Bid>> SearchAsync(Domain.Model.SearchContext searchContext);
}