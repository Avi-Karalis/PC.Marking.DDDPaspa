using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApplicationDbContext;
using Infrastructure;
using RepoInterfaces;

namespace Application.ExamServ
{
    public class ExamService : IExamService
    {
        private MarkingDbContext _context;

        public ExamService(MarkingDbContext context)
        {
            _context = context;
            ExamRepository1 = new ExamRepository (_context);
            ExamRepository1 = new ExamRepository2 (_context);
        }

        public IExamRepository ExamRepository1 {get; private set;}
        public IExamRepository ExamRepository2 {get; private set;}

    }
}
