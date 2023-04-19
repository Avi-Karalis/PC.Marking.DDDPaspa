namespace Application.Queries.GetAllExamsQuery;

public sealed record GetAllExamsResponse(IEnumerable<int> ExamIds, IEnumerable<double> OverallExamScores);
