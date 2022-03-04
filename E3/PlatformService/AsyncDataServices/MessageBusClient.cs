using Microsoft.Extensions.Configuration;
using PlatformService.Dtos;
using RabbitMQ.Client;

namespace PlatformService.AsynDataServices
{
    public class MessageBusClient : IMessageBusClient
    {
        private readonly IConfiguration _configuration;

        public MessageBusClient(IConfiguration configuration)
        {
             _configuration = configuration;
             var factory = new ConnectionFactory(){HostName = _configuration ["RabbitMQHost"], 
             Port =int.Parse(_configuration["RabbitMQPort"])};
        }
        public void PublishNewPlatform(PlatformPublishedDto platformNewPublishedDto)
        {
            throw new System.NotImplementedException();
        }
    }
}