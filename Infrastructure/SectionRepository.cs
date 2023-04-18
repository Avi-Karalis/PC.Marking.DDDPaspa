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
    public class SectionRepository : ISectionRepository {

        private readonly MarkingDbContext _markingDbContext;

        // Constructor that takes an instance of MarkingDbContext and assigns it to _markingDbContext.
        public SectionRepository(MarkingDbContext applicationDbContext)
        {
            _markingDbContext = applicationDbContext;
        }
        // Implementation of the Delete method in the ISectionRepository interface.
        public async Task Delete(int Id) {
            _markingDbContext.Sections.Remove(await GetById(Id));
            await Save();
        }

        // Implementation of the GetAll method in the ISectionRepository interface.
        public async Task<List<Section>> GetAll() {
            return await _markingDbContext.Sections.ToListAsync();
        }

        // Implementation of the GetById method in the ISectionRepository interface.
        public async Task<Section> GetById(int Id) {
            return await _markingDbContext.Sections.FirstAsync(x => x.Id == Id);
        }

        // Implementation of the Insert method in the ISectionRepository interface.
        public async Task<Section> Insert(Section entity) {
            await _markingDbContext.Sections.AddAsync(entity);
            await Save();
            return entity;
        }

        // Implementation of the Save method in the ISectionRepository interface.
        public async Task Save() {
            await _markingDbContext.SaveChangesAsync();
        }

        // Implementation of the Update method in the ISectionRepository interface.
        public async Task<Section> Update(Section entity) {
            _markingDbContext.Update(entity);
            await Save();
            return entity;
        }
    }
}
