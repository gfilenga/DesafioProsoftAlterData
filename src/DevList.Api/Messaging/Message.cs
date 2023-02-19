using DevList.Domain.Models;

namespace DevList.Api.Messaging
{
    public class Message
    {
        public string? Action { get; set; }
        public Developer? Developer { get; set; }
    }
}
