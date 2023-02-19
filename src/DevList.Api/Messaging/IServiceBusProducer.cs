namespace DevList.Api.Messaging
{
    public interface IServiceBusProducer
    {
        Task SendMessageAsync(string message);

        Task SendMessageAsync(object message);
    }
}
