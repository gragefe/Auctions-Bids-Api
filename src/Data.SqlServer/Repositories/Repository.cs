namespace Data.SqlServer;

using Data.SqlServer.Queries;
using Domain.Model;
using Domain.Model.Interfaces;
using Infrastructure.Crosscutting.Validations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

public class Repository : IRepository
{
    private readonly SqlDbContext _context;

    public Repository(SqlDbContext context)
    {
        _context = context;
    }

    public async Task<Guid> CreateAsync(Domain.Model.Entities.Bid Bid)
    {
        await _context.AddAsync(Bid);
        await _context.SaveChangesAsync();

        return Bid.Id;
    }

    public async Task<Domain.Model.Entities.Bid> GetByIdAsync(Guid id)
    {
       return await _context.Bids.FindAsync(id);
    }

    public async Task<List<Domain.Model.Entities.Bid>> SearchAsync(SearchContext searchContext)
    {
        return await SearchQueryBuilder.BuildSearchQuery(searchContext, _context).ToListAsync();
    }
}