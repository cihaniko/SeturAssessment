using ReportService.Entities.RabbitMqModels;

namespace ReportService.Utilities.RabbitMq
{
    public interface IRabbitMqProducerHelper
    {
        void SendMessageQueue(IMessagesModel messages);
    }
}