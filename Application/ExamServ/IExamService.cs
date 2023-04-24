using RepoInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ExamServ
{
    public interface IExamService

    {
        public IExamRepository ExamRepository1 { get; }
        public IExamRepository ExamRepository2 { get; }
    }
}
