namespace Infrastructure.Gateways.Kafka;

using Application.Services.Interfaces;
using Confluent.Kafka;
using System;
using System.Threading.Tasks;

public class KafkaProducer: IKafkaProducer
{
    private readonly IProducer<Null, string> _producer;

    public KafkaProducer(string brokerList)
    {
        var config = new ProducerConfig
        {
            BootstrapServers = "localhost:9092"
        };

        _producer = new ProducerBuilder<Null, string>(config).Build();
    }

    public async Task ProduceAsync(string topic, string message)
    {
        try
        {
            var result = await _producer.ProduceAsync(topic, new Message<Null, string>
            {
                Value = message
            });

            Console.WriteLine($"Mensagem '{message}' enviada para o tópico {topic} [Partição: {result.Partition}, Offset: {result.Offset}]");
        }
        catch (ProduceException<Null, string> e)
        {
            Console.WriteLine($"Erro ao produzir mensagem: {e.Error.Reason}");
        }
    }

    public void Dispose()
    {
        _producer.Flush(TimeSpan.FromSeconds(10));
        _producer.Dispose();
    }
}
