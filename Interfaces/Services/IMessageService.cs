using Project.Models;

namespace Project.Interfaces.Services
{
    public interface IMessageService
    {
        Task<List<Message>> GetMessagesAsync();
        Task<Message?> GetMessageByIdAsync(int id);
        Task AddMessagesAsync(Message message);
        Task UpdateMessagesAsync(Message message);
        Task RemoveMessagesAsync(Message message);
    }
}
