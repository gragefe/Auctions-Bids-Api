namespace Bids.API.DependencyInjection;

using Application.Services.Interfaces;
using BidsServices = Application.Services;

public static class Bidservices
{
    public static void AddServices(WebApplicationBuilder builder)
    {
        builder.Services
              .AddScoped<ICreateBidsService, BidsServices.CreateBidsService>();
        builder.Services
              .AddScoped<IGetByIdBidsService, BidsServices.GetByIdBidsService>();
        builder.Services
              .AddScoped<ISearchBidsService, BidsServices.SearchBidsService>();
    }
}