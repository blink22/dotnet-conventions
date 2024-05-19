using FluentValidation;
using Services.DTOs.Requests;

namespace WebApi.Validators
{
    // Validator class for ExampleRequestDto using FluentValidation
    public class ExampleEntityDtoValidator : BaseValidator<ExampleRequestDto>
    {
        // Constructor to set up validation rules
        public ExampleEntityDtoValidator()
        {
            // Defining validation rules for FirstName property of ExampleRequestDto
            RuleFor(dto => dto.FirstName)
                .NotNull() // Checking if FirstName is not null
                .WithMessage("First name is required"); // Setting error message if validation fails

            // Example of another validation rule:
            //RuleFor(dto => dto.Age)
            //    .GreaterThanOrEqualTo(18) // Checking if Age is greater than or equal to 18
            //    .WithMessage("Legal Age Is Required"); // Setting error message if validation fails

            // Various built-in validations can be used such as for email, regex, numerical length, etc.
            // Custom validators can also be created that return a bool
        }
    }
}
