using System;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using CommandService.EventProcessing;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace CommandService.AsynDataService
{
    public class MessageBusSubscriber : BackgroundService
    {
        private IConfiguration _configuration;
        private IEventProcessor _eventprocessor;
        private IConnection _connection;
        private IModel _channel;
    
        private string _queueName;
        private object _eventProcessor;

        public MessageBusSubscriber(
            IConfiguration configuration , 
            IEventProcessor eventeprocessor)
        {
            _configuration = configuration;
            _eventprocessor = eventeprocessor;

            InitializeRabbitMQ();
        }
        private void InitializeRabbitMQ()
        {
            var factory = new ConnectionFactory(){HostName = _configuration["RabbitMQHost"], Port = int.Parse(_configuration["RabbitMQPort"])};
               
            _connection = factory.CreateConnection(); 
            _channel = _connection.CreateModel();
            _channel.ExchangeDeclare(exchange: "trigger",type: ExchangeType.Fanout);
            _queueName = _channel.QueueDeclare().QueueName;
            _channel.QueueBind(queue: _queueName,
                exchange: "trigger",
                routingKey: "");

            Console.WriteLine(" ---> Listening on the Message Bus....");

            _connection.ConnectionShutdown += RabbitMQ_ConnectionShutdown;
        }
        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            stoppingToken.ThrowIfCancellationRequested();

            var consumer = new EventingBasicConsumer(_channel);

            consumer.Received += (ModuleHandle, ea) =>
            {
                Console.WriteLine("---> Evente Received ! ");

                var body = ea.Body;
                var notificationMessage = Encoding.UTF8.GetString(body.ToArray());

                _eventprocessor.ProcessEvent(notificationMessage);
            };

            _channel.BasicConsume(queue: _queueName, autoAck : true, consumer: consumer);

            return Task.CompletedTask;///
        }

        private void RabbitMQ_ConnectionShutdown(Object sender, ShutdownEventArgs e )
        {
                Console.WriteLine("---> Connection Shutdown");
        }
        public override void Dispose()
        {
            if ( _channel.IsOpen)
            {
                _channel.Close();
                _connection.Close();
            }

        }
    }
}