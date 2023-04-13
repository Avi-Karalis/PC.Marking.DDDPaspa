using FluentValidation;

namespace Domain.Validators;

public class MarkingValidator : AbstractValidator<Exam>
{
    public MarkingValidator()
    {
        RuleFor(x => x.OverallExamScore).NotEmpty().WithMessage("Score is required");
        RuleFor(x => x.OverallExamScore).GreaterThanOrEqualTo(0).WithMessage("Score must not be a negative number");
    }
}
