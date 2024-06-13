

using FluentValidation;
using JobListingApp.Dto;
using JobListingApp.WebApi.Persistance;
using System.Data;
using System.Text.RegularExpressions;


namespace JobListingApp.WebApi.Dto.Validators
{
    public class RegisterCreateListingDtoValidator : AbstractValidator<CreateListingDto>
    {
        public RegisterCreateListingDtoValidator(IBoardUnitOfWork unitOfWork)
        {
            RuleFor(p => p.Tit)
                .MinimumLength(2)
                .MaximumLength(30)
                .Matches(new Regex(@"^[a-zA-Z]+$")).WithMessage("Title can only contain letters.");
            RuleFor(p => p.Desc)
                .MinimumLength(10)
                .MaximumLength(255);
            RuleFor(p => p.Company);
            
            RuleFor(p => p.PostedDate)
                .LessThanOrEqualTo(DateTime.Now).WithMessage("Posted date cannot be in the future.");

        }
    }
}
