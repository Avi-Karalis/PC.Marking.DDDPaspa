using Domain;
using Domain.Exceptions;
using Domain.Shared;
using FluentValidation;

namespace Application.Commands.AutoMarkingCommand;

internal sealed class AutoMarkingCommandHandler : ICommandHandler<AutoMarkingCommand, Exam>
{
    private readonly IValidator<Exam> _validator;
    private readonly IExamMarkingBase _examMarkingBase;

    public AutoMarkingCommandHandler(IValidator<Exam> validator, IExamMarkingBase examMarkingBase)
    {
        _validator = validator;
        _examMarkingBase = examMarkingBase;
    }

    public async Task<Result<Exam>> Handle(AutoMarkingCommand request, CancellationToken cancellationToken)
    {
        var markedExam = await _examMarkingBase.ExamAutoMarkingService(request.exam);

        var result = _validator.Validate(request.exam);

        if (!result.IsValid)
        {
            var errors = result.Errors.Select(x => x.ErrorMessage).ToArray();
            throw new InvalidRequestBodyException
            {
                Errors = errors
            };
        }
        return Result<Exam>.SuccessResult(markedExam);
    }
}
