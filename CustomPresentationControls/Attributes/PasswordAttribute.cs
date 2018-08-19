using CustomPresentationControls.Authentication;
using System.ComponentModel.DataAnnotations;
using System.Security;

namespace CustomPresentationControls.Attributes
{
    public class PasswordAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            string password = value.ToString();
            if (password == null)
            {
                return new ValidationResult("Property unable to be validated as password.");
            }
            else if (!AuthenticationService.ValidatePassword(password, out string message))
            {
                return new ValidationResult(message);
            }
            return null;
        }
    }
}
