using Project.Models;

namespace Project.Interfaces.Services
{
    public interface IMessageService
    {
        Task<List<Message>> GetMessagesAsync();
        Task<Message?> GetMessageByIdAsync(int id);
        Task AddMessagesAsync(Message message);
        Task UpdateMessagesAsync(Message oldMessage, Message newMessage);
        Task RemoveMessagesAsync(Message message);
    }
}
