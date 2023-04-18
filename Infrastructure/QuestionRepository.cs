using ApplicationDbContext;
using Domain;
using Microsoft.EntityFrameworkCore;
using RepoInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure {
    public class QuestionRepository : IQuestionRepository 
    {
        // Declare a private field of type MarkingDbContext to store the database context
        private readonly MarkingDbContext _markingDbContext;

        // Declare a constructor that accepts an instance of MarkingDbContext and assign it to the private field
        public QuestionRepository(MarkingDbContext applicationDbContext)
        {
            _markingDbContext = applicationDbContext;
            
        }
        // Implement the Delete method of the IQuestionRepository interface that deletes a Question entity by Id
        public async Task Delete(int Id) 
        {
            
            _markingDbContext.Questions.Remove( await GetById(Id));
            await Save();
        }

        // Implement the GetAll method of the IQuestionRepository interface that retrieves all the Question entities
        public async Task<List<Question>> GetAll() {
            
            return await _markingDbContext.Questions.ToListAsync();
        }

        // Implement the GetById method of the IQuestionRepository interface that retrieves a Question entity by Id
        public async Task<Question> GetById(int Id) {

            return await _markingDbContext.Questions.FirstAsync(q => q.Id == Id);
        }


        // Implement the Insert method of the IQuestionRepository interface that adds a new Question entity to the database
        public async Task<Question> Insert(Question entity)
        {
            await _markingDbContext.Questions.AddAsync(entity);
            await Save();
            return entity;
        }

        // Implement the Save method of the IQuestionRepository interface that saves changes to the database
        public async Task Save() {
           await _markingDbContext.SaveChangesAsync();
        }

        // Implement the Update method of the IQuestionRepository interface that updates an existing Question entity in the database
        public async Task<Question> Update(Question entity) {
            _markingDbContext.Update(entity);
            await Save();
            return entity;
        }
    }
}
