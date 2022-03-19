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
        private IConnection _connection;
        private IModel _channel;

        public MessageBusSubscriber(
            IConfiguration configuration , 
            IEventProcessor eventeprocessor)
        {
            _configuration = configuration;
            _eventprocessor = eventeprocessor;
        }
        private void InitializeRabbitMQ()
        {
            var factory = new ConnectionFactory(){HostName = _configuration["RabbitMQHost"], Port = int.Parse(_configuration["RabbitMQPort"])};
               
            _connection = factory.CreateConnection(); 
            _channel = _connection.CreateModel();
            _channel.ExchangeDeclare(exchange: "trigger",type: ExchangeType.Fanout);
        }
        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            throw new System.NotImplementedException();
        }
    }
}