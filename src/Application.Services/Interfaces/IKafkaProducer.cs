namespace Application.Services.Interfaces;

using Application.DTO;

public interface IKafkaProducer
{
    Task ProduceAsync(string topic, string message);
}