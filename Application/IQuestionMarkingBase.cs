using Domain;

namespace Application; 
// Define an interface for the question marking service
public interface IQuestionMarkingBase {
    // Declare a method that accepts a question and returns a Task<Question> after marking the question
    Task<Question> QuestionMarkingService(Question question);
}