using System;
using System.Text.Json;
using Microsoft.Extensions.Configuration;
using PlatformService.Dtos;
using RabbitMQ.Client;

namespace PlatformService.AsynDataServices
{
    public class MessageBusClient : IMessageBusClient
    {
        private readonly IConfiguration _configuration;
        private readonly IConnection _connection;
        private readonly IModel _channel;

        public MessageBusClient(IConfiguration configuration)
        {
             _configuration = configuration;
             var factory = new ConnectionFactory(){HostName = _configuration ["RabbitMQHost"], 
                Port =int.Parse(_configuration["RabbitMQPort"])};
            try
            {
                _connection = factory.CreateConnection();
                _channel = _connection.CreateModel();

                _channel.ExchangeDeclare(exchange: "trigger", type : ExchangeType.Fanout);

                _connection.ConnectionShutdown += RabbitMQ_ConnectionShutdown;

                Console.Write(" --> Connectede to MessageBus");
            }
            catch(Exception ex)
            {
                Console.WriteLine($" --> Could not connect to the Message Bus :{ex.Message}");
            }
        }
   public void PublishNewPlatform(PlatformPublishedDto platformPublishedDto)
        {
            var message = JsonSerializer.Serialize(platformPublishedDto);

            if ( _connection.IsOpen)
            {
                Console.WriteLine(" --> RabbitMQ Connecion open , senfing message .... ");
            }
            else
            {
                 Console.WriteLine(" --> RabbitMQ Connecion closed, not message .... ");
            }
        }
        
        private void RabbitMQ_ConnectionShutdown(object sender, ShutdownEventArgs e )
        {
            Console.WriteLine(" -- > RabbitMQ Connection Shutdown");
        }
    }
}