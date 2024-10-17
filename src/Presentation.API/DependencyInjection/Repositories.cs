namespace Presentation.API.DependencyInjection;

using Data.SqlServer;
using Domain.Model.Interfaces;
using Microsoft.EntityFrameworkCore;

public static class Repositories
{
    public static void AddRepositories(WebApplicationBuilder builder)
    {
        var connectionString = builder.Configuration.GetSection("SqlServer").GetValue<string>("ConnectionString");

        builder.Services.AddDbContext<SqlDbContext>(options =>
            options.UseSqlServer(connectionString));

        builder.Services.AddScoped<IRepository, Repository>();
    }
}