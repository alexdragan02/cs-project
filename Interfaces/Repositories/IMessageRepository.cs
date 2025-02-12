using Project.Models;

namespace Project.Interfaces.Repositories
{
    public interface IMessageRepository
    {
        Task<List<Message>> GetMessagesAsync();
        Task<Message?> GetMessageByIdAsync(int id);
        Task AddMessagesAsync(Message message);
        Task AddMessageFileAsync(MessageFile file);
        Task UpdateMessagesAsync(Message oldMessage, Message newMessage);
        Task RemoveMessagesAsync(Message message);
    }
}
