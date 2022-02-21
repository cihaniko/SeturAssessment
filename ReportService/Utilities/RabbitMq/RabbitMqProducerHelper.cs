using RabbitMQ.Client;
using ReportService.Entities.RabbitMqModels;
using System.Text;
using System.Text.Json;

namespace ReportService.Utilities.RabbitMq
{
    public class RabbitMqProducerHelper
    {
        private readonly IConfiguration _configuration;
        private readonly RabbitMqSettings _rabbitMqSettings;

        public RabbitMqProducerHelper(IConfiguration configuration)
        {
            this._configuration = configuration;
            _rabbitMqSettings = _configuration.GetSection("RabbitMqSettings").Get<RabbitMqSettings>();
        }

        public void SendMessageQueue(IMessagesModel messages)
        {
            var QueueName = _rabbitMqSettings.QueueName;
            var factory = new ConnectionFactory
            {
                Uri = new Uri(_rabbitMqSettings.Uri)
            };
            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                channel.QueueDeclare(
                        queue: QueueName,
                        durable: false,
                        exclusive: false,
                        autoDelete: false,
                        arguments: null);

                string message = JsonSerializer.Serialize(messages);
                var body = Encoding.UTF8.GetBytes(message);

                channel.BasicPublish(exchange: "", routingKey: QueueName, basicProperties: null, body: body);
            }
        }
    }
}
