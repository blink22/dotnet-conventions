using FluentValidation;
using FluentValidation.Results;

namespace WebApi.Validators
{
    // Base class for validation with FluentValidation
    public class BaseValidator<T> : AbstractValidator<T>
    {
        // Method to perform validation and return the validation result
        public virtual ValidationResult Check(T input)
        {
            return Validate(input); // Invoking FluentValidation's Validate method to perform validation
        }
    }
}
