using System.ComponentModel.DataAnnotations;

namespace tamkhoatech.ACWeb.Common
{
    public class NullAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object? value, ValidationContext validationContext)
        {
            if (value != null)
            {
                return ValidationResult.Success!;
            }
            else
            {
                return new ValidationResult("Không được để trống!");
            }
        }
    }
}
