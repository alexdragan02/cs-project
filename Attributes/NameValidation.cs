using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace Project.Attributes
{
    public class NameValidationAttribute : ValidationAttribute
    {
        protected override ValidationResult? IsValid(
            object? value,
            ValidationContext validationContext
        )
        {
            if (value is string str && Regex.IsMatch(str, "^[A-Za-z]+$"))
            {
                return ValidationResult.Success;
            }
            return new ValidationResult(ErrorMessage);
        }
    }
}
