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

namespace Application {
    public class Marking 
    {
        private readonly IValidator<Exam> _validator;

        public Marking(IValidator<Exam> validator)
        {
            _validator = validator;
        }

        public async Task<float> MarkingService(Exam exam)
        {
            //MarkingValidator score = exam;
            //score = 70.5f;
            exam.OverallExamScore = null;
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
