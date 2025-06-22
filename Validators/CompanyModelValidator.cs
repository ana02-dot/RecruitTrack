using FluentValidation;
using JobSeekerAPI.Dtos;

namespace JobSeekerAPI.Validators
{
    public class CompanyModelValidator : AbstractValidator<CompanyDto>
    {
        public CompanyModelValidator()
        {
            RuleFor(company => company.Name)
                .NotEmpty().WithMessage("Company name is required.")
                .Length(2, 100).WithMessage("Company name must be between 2 and 100 characters.");
            RuleFor(company => company.Description)
                .NotEmpty().WithMessage("Description is required.")
                .Length(6, 200).WithMessage("Company Description must be between 6 and 200 characters.");
            RuleFor(company => company.Industry)
                .NotEmpty().WithMessage("Industry is required.")
                .Length(2, 50).WithMessage("Company industry must be between 2 and 50 characters.");
        }
    }
}
