using Domain.Shared;
using RepoInterfaces;

namespace Application.Queries.GetAllExamsQuery;

internal sealed class GetAllExamsQueryHandler : IQueryHandler<GetAllExamsQuery, GetAllExamsResponse>
{
    private IExamRepository _examRepo;

    public GetAllExamsQueryHandler(IExamRepository examRepo)
    {
        _examRepo = examRepo;
    }

    public async Task<Result<GetAllExamsResponse>> Handle(GetAllExamsQuery request, CancellationToken cancellationToken)
    {
        var exams = await _examRepo.GetAll();

        if (exams.Count == 0)
        {
            return Result<GetAllExamsResponse>.FailureResult(
                "There are no exams to show. Please try again later.");
        }
        IEnumerable<int> examIds = exams.Select(e => e.Id);
        IEnumerable<double> examOverallScores = exams.Select(e => e.OverallExamScore);
        var response = new GetAllExamsResponse(examIds, examOverallScores);

        return Result<GetAllExamsResponse>.SuccessResult(response);
    }
}
