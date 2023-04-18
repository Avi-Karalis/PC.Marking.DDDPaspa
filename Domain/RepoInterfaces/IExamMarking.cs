using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepoInterfaces
{
    internal interface IExamMarking
    {
        /// <summary>
        /// Gets all the exams of a specific marker
        /// </summary>
        /// <returns></returns>
        List<Exam> GetExamList();

        /// <summary>
        /// Gets a list of all unmarked exams for a specific marker
        /// </summary>
        /// <returns>A list of all unmarked exams for the marker</returns>
        List<Exam> GetUnmarkedExamList();

        /// <summary>
        /// Gets a list of all marked exams for a specific marker
        /// </summary>
        /// <returns>A list of all marked exams for the marker</returns>
        List<Exam> GetMarkedExamList();

        /// <summary>
        /// what is the output of the marking process????????
        /// </summary>
        /// <param name="examId"></param>
        /// <returns></returns>
        double MarkExam(int examId);


        /// <summary>
        /// Marks a question within an exam and returns the score for the question
        /// </summary>
        /// <param name="examId">The ID of the exam containing the question to mark</param>
        /// <param name="questionId">The ID of the question to mark</param>
        /// <returns>The score for the question</returns>
        double MarkQuestion(int examId, int questionId);

        /// <summary>
        /// Marks a section within an exam and returns the score for the section
        /// </summary>
        /// <param name="examId">The ID of the exam containing the section to mark</param>
        /// <param name="sectionId">The ID of the section to mark</param>
        /// <returns>The score for the section</returns>
        double MarkSection(int examId, int sectionId);
    }
}
