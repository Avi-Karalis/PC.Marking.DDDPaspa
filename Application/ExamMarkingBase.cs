using Domain;

namespace Application; 
public class ExamMarkingBase : IExamMarkingBase {
    private readonly ISectionMarkingBase _sectionMarking;

    // Constructor that injects an instance of ISectionMarkingBase through dependency injection
    public ExamMarkingBase(ISectionMarkingBase sectionMarkingBase) => _sectionMarking = sectionMarkingBase;

    public async Task<Exam> ExamAutoMarkingService(Exam exam) {
        exam.OverallExamScore = 0;
        // For each section in the exam, call the SectionMarkingService method from the injected _sectionMarking instance
        foreach (Section section in exam.Sections) {
           await _sectionMarking.SectionMarkingService(section);
            // If the overall exam score is less than or equal to the maximum score, add the awarded section marks to the overall exam score
            if (exam.OverallExamScore <= exam.MaximumScore) {
                exam.OverallExamScore += section.AwardedSectionMarks;
            }
            else
            {
                throw new Exception("your code sux");
            }
        }

        // Once all sections have been marked, update the exam's MarkingState to AutoMarked and return the exam
        exam.MarkingState = MarkingState.AutoMarked;
        return exam;
    }
}