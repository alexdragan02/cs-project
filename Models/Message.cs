using System.ComponentModel.DataAnnotations;

namespace Project.Models
{
    public class Message
    {
        [Key]
        public int Id { get; set; }
        public string Email { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Context { get; set; } = string.Empty;
    }
}
