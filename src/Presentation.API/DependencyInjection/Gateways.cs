namespace Presentation.API.DependencyInjection;

using Application.Services.Interfaces;
using Data.SqlServer;
using Domain.Model.Interfaces;
using Infrastructure.Gateways.Kafka;
using Microsoft.EntityFrameworkCore;

public static class Gateways
{
    public static void AddGateways(WebApplicationBuilder builder)
    {
        var kafkaBrokerList = builder.Configuration.GetSection("Kafka:BrokerList").Value;

        builder.Services.AddScoped<IKafkaProducer, KafkaProducer>(provider =>
        {
            return new KafkaProducer(kafkaBrokerList);
        });
    }
}