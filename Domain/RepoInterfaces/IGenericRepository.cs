using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepoInterfaces {

    // Declare a public interface called "IGenericRepository" that is parameterized with a type "T" that must be a reference type (i.e. a class)
    public interface IGenericRepository<T> where T : class {

        // These are queries that return Task objects
        Task<List<T>> GetAll();  // Returns a list of all entities of type "T" in the data store

        Task Save();   // Saves changes made to the data store


        // These are CRUD operations that return Task objects
        Task<T> Insert(T entity);   // Inserts an entity of type "T" into the data store and returns the inserted entity
        Task<T> Update(T entity);   // Updates an existing entity of type "T" in the data store and returns the updated entity
        Task Delete(int Id);    // Deletes the entity with the specified ID from the data store
        Task<T> GetById(int Id);    // Retrieves the entity with the specified ID from the data store and returns it
    }
}
