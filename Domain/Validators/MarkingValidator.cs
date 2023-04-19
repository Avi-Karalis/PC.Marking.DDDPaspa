using FluentValidation;

namespace Domain.Validators;

// Declare a public class called "MarkingValidator" which inherits from the "AbstractValidator" class and validates objects of type "Exam"
public class MarkingValidator : AbstractValidator<Exam>
{
    public MarkingValidator()
    {
        // Define a validation rule for the "OverallExamScore" property of the "Exam" object
        RuleFor(x => x.OverallExamScore).NotEmpty().WithMessage("Score is required");
        // Define a validation rule for the "OverallExamScore" property of the "Exam" object, which ensures it is not a negative number
        RuleFor(x => x.OverallExamScore).GreaterThanOrEqualTo(0).WithMessage("Score must not be a negative number");
    }
}
