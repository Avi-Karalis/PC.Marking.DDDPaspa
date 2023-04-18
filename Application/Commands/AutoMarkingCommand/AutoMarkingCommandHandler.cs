using Domain;
using Domain.DTO;
using Domain.Exceptions;
using Domain.Shared;
using FluentValidation;

namespace Application.Commands.AutoMarkingCommand;

public sealed class AutoMarkingCommandHandler : ICommandHandler<AutoMarkingCommand>
{
    private readonly IValidator<Exam> _validator;
    private readonly IExamMarkingBase _examMarkingBase;

    public AutoMarkingCommandHandler(IValidator<Exam> validator, IExamMarkingBase examMarkingBase)
    {
        _validator = validator;
        _examMarkingBase = examMarkingBase;
    }

    public async Task<Result> Handle(AutoMarkingCommand request, CancellationToken cancellationToken)
    {
        await _examMarkingBase.ExamAutoMarkingService(request.exam);

        var result = _validator.Validate(request.exam);

        if (!result.IsValid)
        {
            var errors = result.Errors.Select(x => x.ErrorMessage).ToArray();
            throw new InvalidRequestBodyException
            {
                Errors = errors
            };
        }
        return Result.SuccessResult();
    }
}
