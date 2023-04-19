using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepoInterfaces {

    // Declare a public interface called "IExamRepository" that extends the "IGenericRepository" interface for Exam entities
    public interface IExamRepository : IGenericRepository<Exam> {

        // Define a method that asynchronously returns a list of all unmarked exams
        Task<List<Exam>> GetUnmarkedList();

        // Define a method that asynchronously returns a list of all marked exams
        Task<List<Exam>> GetMarkedList();

        // These are commands - presumably the methods that implement them would perform actions on the data store

    }
}
