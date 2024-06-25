

using FluentValidation;
using JobListingApp.SharedKernel.Dto;
using JobListingApp.Domain.Contracts;
using System.Data;
using System.Text.RegularExpressions;


namespace JobListingApp.Application.Validators;

public class RegisterCreateListingDtoValidator : AbstractValidator<CreateListingDto>
{
    public RegisterCreateListingDtoValidator(IBoardUnitOfWork unitOfWork)
    {
        RuleFor(p => p.Title)
            .MinimumLength(2)
            .MaximumLength(30)
            .Matches(new Regex(@"^[a-zA-Z]+$")).WithMessage("Title can only contain letters.");
        RuleFor(p => p.Description)
            .MinimumLength(10)
            .MaximumLength(255);
        RuleFor(p => p.Company);

        RuleFor(p => p.PostedDate)
            .LessThanOrEqualTo(DateTime.Now).WithMessage("Posted date cannot be in the future.");

    }
}
