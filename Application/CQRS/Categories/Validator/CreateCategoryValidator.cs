using Application.CQRS.Categories.Commands.Requests;
using FluentValidation;

namespace Application.CQRS.Categories.Validator;

public class CreateCategoryValidator : AbstractValidator<CreateCategoryRequest>
{
    public CreateCategoryValidator()
    {
        RuleFor(c => c.Name)
            .NotEmpty().WithMessage("Name cannot be null")
            .MaximumLength(255).WithMessage("Cannot be more than 255");
    }


}
