using Project.Interfaces.Repositories;
using Project.Interfaces.Services;
using Project.Models;

namespace Project.Services
{
    public class MessageService(IMessageRepository messageRepository) : IMessageService
    {
        private readonly IMessageRepository _messageRepository = messageRepository;

        public async Task AddMessagesAsync(Message message)
        {
            await _messageRepository.AddMessagesAsync(message);
        }

        public async Task<Message?> GetMessageByIdAsync(int id)
        {
            return await _messageRepository.GetMessageByIdAsync(id);
        }

        public async Task<List<Message>> GetMessagesAsync()
        {
            return await _messageRepository.GetMessagesAsync();
        }

        public async Task RemoveMessagesAsync(Message message)
        {
            await _messageRepository.RemoveMessagesAsync(message);
        }

        public async Task UpdateMessagesAsync(Message message)
        {
            await _messageRepository.UpdateMessagesAsync(message);
        }
    }
}
