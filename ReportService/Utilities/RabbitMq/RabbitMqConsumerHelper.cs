using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using ReportService.Business.ReportService;
using ReportService.Business.ReportStatusService;
using ReportService.Entities.Concrete;
using ReportService.Entities.RabbitMqModels;
using System.Text;
using System.Text.Json;

namespace ReportService.Utilities.RabbitMq
{
    public class RabbitMqConsumerHelper : BackgroundService
    {
        private readonly IConfiguration _configuration;
        private readonly IReportStatusManager _reportStatusManager;
        private readonly IReportManager _reportManager;
        private readonly RabbitMqSettings _rabbitMqSettings;
        private string _channelName;
        private IConnection _conn;
        private IModel _model;
        public RabbitMqConsumerHelper(IConfiguration configuration, IReportStatusManager reportStatusManager, IReportManager reportManager)
        {
            this._configuration = configuration;
            this._reportStatusManager = reportStatusManager;
            this._reportManager = reportManager;
            _rabbitMqSettings = _configuration.GetSection("RabbitMqSettings").Get<RabbitMqSettings>();

            _channelName = _rabbitMqSettings.QueueName;
            InitializeListener();
        }

        private void InitializeListener()
        {

            var factory = new ConnectionFactory()
            {
                Uri = new Uri(_rabbitMqSettings.Uri)
            };

            _conn = factory.CreateConnection();
            _conn.ConnectionShutdown += ConnectionShutdown;
            _model = _conn.CreateModel();
            _model.QueueDeclare(queue: _channelName, durable: false, exclusive: false, autoDelete: false, arguments: null);
        }

        public virtual void ConnectionShutdown(object sender, ShutdownEventArgs e)
        {
        }
        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            stoppingToken.ThrowIfCancellationRequested();

            var consumer = new EventingBasicConsumer(_model);

            consumer.Received += (model, mq) =>
            {

                var body = mq.Body.ToArray();
                var message = Encoding.UTF8.GetString(body);

                MessageHandler(message).Wait(stoppingToken);

            };

            _model.BasicConsume(queue: _channelName, autoAck: true, consumer: consumer);

            return Task.CompletedTask;

        }
        private async Task MessageHandler(string message)
        {

            var deserializeMessage = JsonSerializer.Deserialize<MessagesModel>(message);

            ReportStatus rs = new()
            {
                CreatedAt = DateTime.Now,
                ReportDetail = "",
                Status = ReportStatusEnum.Hazirlaniyor.ToString(),
            };

            await _reportStatusManager.Add(rs);

            var result = await _reportManager.StatisticReportByAllLocation();


            if (result.IsSuccess && result.Data.Count != 0)
            {
                rs.ReportDetail = JsonSerializer.Serialize(result.Data);
                rs.Status=ReportStatusEnum.Tamamlandi.ToString();
                await _reportStatusManager.UpdateAsync(rs);
            }

        }
        public override void Dispose()
        {
            _model.Close();
            _conn.Close();
            base.Dispose();
        }
    }
}
