using System.ComponentModel.DataAnnotations;
using Project.Attributes;

namespace Project.Models
{
    public class Message
    {
        [Key]
        public int Id { get; set; }

        [EmailAddress(ErrorMessage = "Adresa de mail nu e valida!")]
        [Required(ErrorMessage = "Campul e obligatoriu")]
        public string Email { get; set; } = string.Empty;

        [NameValidation(ErrorMessage = "Sunt acceptate doar litere!!")]
        [Required(ErrorMessage = "Numele este obligatoriu!")]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "Scrie un mesaj!")]
        public string Context { get; set; } = string.Empty;

        public MessageFile? MessageFile { get; set; }
    }
}
