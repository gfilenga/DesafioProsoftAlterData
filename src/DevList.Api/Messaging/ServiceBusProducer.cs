using Azure.Messaging.ServiceBus;
using DevList.Domain.Settings;
using Newtonsoft.Json;

namespace DevList.Api.Messaging
{
    public class ServiceBusProducer : IServiceBusProducer
    {
        private readonly ServiceBusClient _serviceBusClient;
        private readonly ServiceBusSender _serviceBusSender;

        public ServiceBusProducer(string connectionString, string queueName, IConfiguration configuration)
        {
            _serviceBusClient = new ServiceBusClient(connectionString);
            _serviceBusSender = _serviceBusClient.CreateSender(queueName);
        }
  
        public async Task SendMessageAsync(object message)
        {
            var objAsText = JsonConvert.SerializeObject(message);
            await _serviceBusSender.SendMessageAsync(new ServiceBusMessage(objAsText));
        }

        public async Task SendMessageAsync(string message)
        {
            await _serviceBusSender.SendMessageAsync(new ServiceBusMessage(message));
        }
    }
}
