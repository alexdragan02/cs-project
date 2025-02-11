using Microsoft.EntityFrameworkCore;
using Project.Data;
using Project.Interfaces.Repositories;
using Project.Models;

namespace Project.Repositories
{
    public class MessageRepository(ApplicationDbContext context) : IMessageRepository
    {
        private readonly ApplicationDbContext _context = context;

        public async Task AddMessagesAsync(Message message)
        {
            await _context.Messages.AddAsync(message);
            await _context.SaveChangesAsync();
        }

        public async Task<Message?> GetMessageByIdAsync(int id)
        {
            var message = await _context.Messages.FirstOrDefaultAsync(message => message.Id == id);
            return message;
        }

        public async Task<List<Message>> GetMessagesAsync()
        {
            return await _context.Messages.ToListAsync();
        }

        public async Task RemoveMessagesAsync(Message message)
        {
            _context.Messages.Remove(message);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateMessagesAsync(Message oldMessage, Message newMessage)
        {
            oldMessage.Email = newMessage.Email;
            oldMessage.Name = newMessage.Name;
            oldMessage.Context = newMessage.Context;
            await _context.SaveChangesAsync();
        }
    }
}
