using System.Runtime.Versioning;
using Project.Interfaces.Repositories;
using Project.Interfaces.Services;
using Project.Models;

namespace Project.Services
{
    public class MessageService(
        IMessageRepository messageRepository,
        IWebHostEnvironment hostEnvironment
    ) : IMessageService
    {
        private readonly IMessageRepository _messageRepository = messageRepository;

        private readonly IWebHostEnvironment _hostEnvironment = hostEnvironment;

        // public async Task AddMessagesAsync(Message message)
        // {
        //     await _messageRepository.AddMessagesAsync(message);
        // }

        public async Task AddMessagesAsync(Message message, IFormFile file)
        {
            var webRootPath = _hostEnvironment.WebRootPath; // Use WebRootPath instead of ContentRootPath
            string uploadFolder = Path.Combine(webRootPath, "Uploads");

            Directory.CreateDirectory(uploadFolder);

            string fileExtension = Path.GetExtension(file.FileName);
            string uniqueFileName = file.FileName + "_" + Guid.NewGuid().ToString() + fileExtension;

            string fullFilePath = Path.Combine(uploadFolder, uniqueFileName);

            // Save the file to the server
            using (var fileStream = new FileStream(fullFilePath, FileMode.Create))
            {
                await file.CopyToAsync(fileStream);
            }

            // Save only the relative path
            string relativeFilePath = $"/Uploads/{uniqueFileName}";

            var messageFile = new MessageFile
            {
                Message = message,
                MessageId = message.Id,
                FileName = file.FileName,
                FilePath = relativeFilePath, // Save relative path instead of full system path
            };

            message.MessageFile = messageFile;

            await _messageRepository.AddMessageFileAsync(messageFile);
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

        public async Task UpdateMessagesAsync(Message oldMessage, Message newMessage)
        {
            await _messageRepository.UpdateMessagesAsync(oldMessage, newMessage);
        }
    }
}
