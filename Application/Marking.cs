using Domain;
using Domain.Exceptions;
using Domain.Validators;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Application
{
    public class Marking
    {
         //ExamMarkingBase ExamMarkingBase { get; set; }
         //SectionMarkingBase SectionMarkingBase { get; set; }
         //QuestionMarkingBase QuestionMarkingBase { get; set; }

        private readonly IValidator<Exam> _validator;
        private  IExamMarkingBase _examMarkingBase;
        private  ISectionMarkingBase _sectionMarkingBase;
        private  IQuestionMarkingBase _questionMarkingBase;


        public Marking(IValidator<Exam> validator,
            IExamMarkingBase examMarkingBase,
            ISectionMarkingBase sectionMarkingBase,
            IQuestionMarkingBase questionMarkingBase)
        {
            _validator = validator;
            _examMarkingBase = examMarkingBase;
            _questionMarkingBase = questionMarkingBase;
            _sectionMarkingBase = sectionMarkingBase;

        }

        public async Task<float> MarkingService(Exam exam)
        {
            // 1st 
            exam.Sections.ForEach(section => { section.Questions.ForEach(q => _questionMarkingBase.QuestionMarkingService(q)); });

            exam.Sections.ForEach(section => _sectionMarkingBase.SectionMarkingService(section));

            await _examMarkingBase.ExamAutoMarkingService(exam);

            //

            //var tasks = new List<Task>();
            //exam.Sections.ForEach(section => section.Questions.ForEach(q => tasks.Add(Task.Run(()=> QuestionMarkingBase.QuestionMarkingService(q)))));
            //Task.WaitAll(tasks.ToArray());

            var result = _validator.Validate(exam);

            if (!result.IsValid)
            {
                var errors = result.Errors.Select(x => x.ErrorMessage).ToArray();
                throw new InvalidRequestBodyException
                {
                    Errors = errors
                };
            }
            return (float)exam.OverallExamScore;

        }
    }
}
