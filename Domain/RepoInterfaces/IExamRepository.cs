using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepoInterfaces {
    public interface IExamRepository : IGenericRepository<Exam> {
        ExamRepositoryImplementations Implementation { get; set; }
        Task<List<Exam>> GetUnmarkedList();
        Task<List<Exam>> GetMarkedList();

        // these are commands.

        
    }

    public enum ExamRepositoryImplementations
    {
        None,
        MarkingExam2022,
        ExamRepository,
        ExamRepository2
    }
}
