using System.Threading;
using System.Threading.Tasks;
using CommandService.EventProcessing;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using RabbitMQ.Client;

namespace CommandService.AsynDataService
{
    public class MessageBusSubscriber : BackgroundService
    {
        private IConfiguration _configuration;
        private IEventProcessor _eventprocessor;

        public MessageBusSubscriber(
            IConfiguration configuration , 
            IEventProcessor eventeprocessor)
        {
            _configuration = configuration;
            _eventprocessor = eventeprocessor;
        }
        private void InitializeRabbitMQ()
        {
            var factory = new ConnectionFactory()
            {
                HostName = _configuration["RabbitMQHost"], Port = int.Parse(_configuration["RabbitMQPort"])
            };
        }
        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            throw new System.NotImplementedException();
        }
    }
}