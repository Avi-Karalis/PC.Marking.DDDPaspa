using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApplicationDbContext;
using Domain;
using Microsoft.EntityFrameworkCore;
using RepoInterfaces;

namespace Infrastructure {
    public class ExamRepository : IExamRepository {

        // Holds an instance of the MarkingDbContext
        private readonly MarkingDbContext _context;

        // Constructor for ExamRepository that accepts a MarkingDbContext instance
        public ExamRepository(MarkingDbContext context)
        {
            _context = context;
        }

        // Deletes an Exam record from the database with the specified Id
        public async Task Delete(int Id) {

            _context.Exams.Remove(await GetById(Id));
            await Save();
        }

        // Retrieves all Exam records from the database
        public async Task<List<Exam>> GetAll() {

            return await _context.Exams.ToListAsync();
        }

        // Retrieves an Exam record from the database with the specified Id
        public async Task<Exam> GetById(int Id) {

           return await _context.Exams.FirstOrDefaultAsync(x => x.Id == Id);
        }

        // Retrieves all Exam records from the database that are in AutoMarked state
        public async Task<List<Exam>> GetMarkedList() {

            return await _context.Exams.Where(x => x.MarkingState == MarkingState.AutoMarked).ToListAsync();
        }

        // Retrieves all Exam records from the database that are in UnMarked state
        public async Task<List<Exam>> GetUnmarkedList() {

            return await _context.Exams.Where(x => x.MarkingState == MarkingState.UnMarked).ToListAsync();
        }

        // Inserts an Exam record into the database
        public async Task<Exam> Insert(Exam exam) {

            await _context.Exams.AddAsync(exam);
            await Save();
            return exam;
        }

        // Saves changes made to the database
        public async Task Save() {
            
            await _context.SaveChangesAsync();

        }

        // Updates an Exam record in the database
        public async Task<Exam> Update(Exam entity) {
           
            _context.Exams.Update(entity);
            await Save();
            return entity;

        }
    }
}
