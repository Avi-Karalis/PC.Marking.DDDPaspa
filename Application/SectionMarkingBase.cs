using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application {
    public class SectionMarkingBase : ISectionMarkingBase {

        private readonly IQuestionMarkingBase _questionMarking;

        // Constructor injection: passing an instance of IQuestionMarkingBase to initialize the _questionMarking field
        public SectionMarkingBase(IQuestionMarkingBase questionMarkingBase) => _questionMarking = questionMarkingBase;

        // The implementation of SectionMarkingService method defined in the ISectionMarkingBase interface.
        public async Task<Section> SectionMarkingService(Section section)
        {
            section.AwardedSectionMarks = 0;
            foreach(Question question in section.Questions) 
            {
                // Call the QuestionMarkingService method of _questionMarking instance
                // and pass the current question as an argument. The method will mark the
                // question and return it with the awarded marks updated.
                await _questionMarking.QuestionMarkingService(question);
                    section.AwardedSectionMarks += question.AwardedMarks;
               
            }
            
            return section;
        }
    }
}
