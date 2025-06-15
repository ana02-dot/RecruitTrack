using FluentValidation;
using JobSeekerAPI.Dtos;
using JobSeekerAPI.Models;
using JobSeekerAPI.Services;

namespace JobSeekerAPI.Validators
{
    public class CreateUserDtoValidator : AbstractValidator<CreateUserDto>
    {
        public CreateUserDtoValidator() 
        { 
            RuleFor(user => user.FirstName)
                .NotEmpty().WithMessage("First name is required.")
                .Length(2, 50).WithMessage("First name must be between 2 and 50 characters.");

            RuleFor(user => user.LastName)
                .NotEmpty().WithMessage("Last name is required.")
                .Length(2, 50).WithMessage("Last name must be between 2 and 50 characters.");

            RuleFor(user => user.Email)
                .NotEmpty().WithMessage("Email is required.")
                .EmailAddress().WithMessage("Invalid email format.");

            RuleFor(user => user.Password)
                .NotEmpty().WithMessage("Password is required.")
                .MinimumLength(6).WithMessage("Password must be at least 6 characters long.");

            RuleFor(user => user.Role)
                .NotEmpty().WithMessage("Role is required.")
                .Must(role => role.ToLower() == "hr" || role.ToLower() == "admin" || role.ToLower() == "applicant")
                .WithMessage("Role must be either 'hr', 'admin', or 'applicant'.");
        }
    }
}
