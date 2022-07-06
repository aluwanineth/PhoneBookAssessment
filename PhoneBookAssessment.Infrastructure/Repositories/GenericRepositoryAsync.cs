using Microsoft.EntityFrameworkCore;
using PhoneBookAssessment.Application.Interfaces;
using PhoneBookAssessment.Infrastructure.Contexts;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PhoneBookAssessment.Infrastructure.Repositories
{
    public abstract class GenericRepositoryAsync<T> : IGenericRepositoryAsync<T> where T : class
    {
        protected readonly ApplicationDbContext _dbContext;

        protected GenericRepositoryAsync(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public virtual async Task<T> GetByIdAsync(int id)
        {
            return await _dbContext.Set<T>().FindAsync(id);
        }
        public async Task<T> AddAsync(T entity)
        {
            await _dbContext.Set<T>().AddAsync(entity);
            await _dbContext.SaveChangesAsync();
            return entity;
        }

        public async Task<IReadOnlyList<T>> GetAllAsync()
        {
            return await _dbContext
                 .Set<T>()
                 .ToListAsync();
        }
    }
}
