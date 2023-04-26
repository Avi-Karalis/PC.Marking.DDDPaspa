using Application.giannisDF.ApiDto;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.giannisDF.ApiDtoMapping
{
    public class ApiDtoMapper
    {

        public Exam GetDtoToExam(ExamGetDto getExamDto)
        {
            return new Exam();
        }
        public Exam SendDtoToExam(ExamSendDto getExamDto)
        {
            return new Exam();
        }

        public ExamGetDto ExamToGetDto(Exam exam)
        {
            return new ExamGetDto();
        }

        public ExamSendDto ExamToSendDto(Exam exam)
        {
            return new ExamSendDto();
        }
    }
}
