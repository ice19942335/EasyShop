using System.ComponentModel.DataAnnotations;

namespace ServerMonetization.CP.Infrastructure.Validation.ViewModelValidation
{
    public class ValidateTermsAccepted : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if(!(bool)value)
                return new ValidationResult(GetErrorMessage());

            return ValidationResult.Success;
        }

        private string GetErrorMessage() => "Please accept terms of service";
    }
}
