using System.Data;
using FluentValidation;
using FluentValidation.AspNetCore;
using JobSeekerAPI.Dtos;

namespace JobSeekerAPI.Validators;

public class ApplicantModelValidator:AbstractValidator<ApplicantDto>
{
    public ApplicantModelValidator()
    {
        RuleFor(applicant => applicant.FirstName)
            .NotEmpty().WithMessage("First Name  is required.")
            .Length(2, 50).WithMessage("First name must be between 2 and 50 characters.");
        RuleFor(applicant => applicant.LastName)
            .NotEmpty().WithMessage("Last Name  is required.")
            .Length(2, 50).WithMessage("Last name must be between 2 and 50 characters.");
        RuleFor(applicant => applicant.Email)
            .NotEmpty().WithMessage("Email is required.")
            .EmailAddress().WithMessage("Invalid email format.");
    }
}