using Domain;
using RepoInterfaces;

namespace Application 
{
    public class QuestionMarkingBase : IQuestionMarkingBase
    {
        // inject the IQuestionRepository dependency into the constructor
        private readonly IQuestionRepository _questionRepository;
        public QuestionMarkingBase(IQuestionRepository questionRepository) =>  _questionRepository = questionRepository;

        // define the QuestionMarkingService method that takes a Question object and marks it
        public async Task<Question> QuestionMarkingService(Question question)
        {
            question.AwardedMarks = 0;
            foreach (var option in question.OptionsAvailable)
            {
                // if the option is selected by the student and is correct, then add its mark value to the awarded marks of the question
                if (option.Selected == true && option.IsCorrect == true)
                {
                    question.AwardedMarks += option.MarkValue;
                }
            } 
                  

            return question;
        }
    }
}