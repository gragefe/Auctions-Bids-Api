namespace Data.SqlServer.Queries;

using Domain.Model;

internal static class SearchQueryBuilder
{
    internal static IQueryable<Domain.Model.Entities.Bid> BuildSearchQuery(SearchContext searchContext, SqlDbContext db)
    {
        IQueryable<Domain.Model.Entities.Bid> query = db.Bids;

        if (searchContext.VehicleId != default)
        {
            query = query.Where(c => c.VehicleId == searchContext.VehicleId);
        }

        if (searchContext.Value != default)
        {
            query = query.Where(c => c.Value == searchContext.Value);
        }

        return query;
    }
}