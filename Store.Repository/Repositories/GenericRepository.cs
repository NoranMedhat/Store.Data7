using Microsoft.EntityFrameworkCore;
using Store.Data.Contexts;
using Store.Data.Entities;
using Store.Repository.Interfaces;
using Store.Repository.Specification;

namespace Store.Repository.Repositories
{
    public class GenericRepository<TEntity, TKey> : IGenericRepository<TEntity, TKey> where TEntity : BaseEntity<TKey>
    {
        private readonly StoreDbContext _context;

        public GenericRepository(StoreDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(TEntity entity)
            =>await _context.Set<TEntity>().AddAsync(entity);

        public void Delete(TEntity entity)
            => _context.Set<TEntity>().Remove(entity);

        public async Task<IReadOnlyList<TEntity>> GetAllAsNoTrackingAsync()
            => await _context.Set<TEntity>().AsNoTracking().ToListAsync();


        public async Task<IReadOnlyList<TEntity>> GetAllAsync()
            => await _context.Set<TEntity>().ToListAsync();

        //public async Task<TEntity> GetByIdAsNoTrackingAsync(TKey? id)
        //                => await _context.Set<TEntity>().AsNoTracking().FirstOrDefaultAsync(x=>x.Id==id);

        public async Task<TEntity> GetByIdAsync(TKey? id)
            => await _context.Set<TEntity>().FindAsync(id);
        public void Update(TEntity entity)
            => _context.Set<TEntity>().Update(entity);
        public async Task<TEntity> GetWithSpecificationByIdAsync(ISpecification<TEntity> specs)
          =>await ApplySpecification(specs).FirstOrDefaultAsync();

        public async Task<IReadOnlyList<TEntity>> GetWithSpecificationAllAsync(ISpecification<TEntity> specs)
            =>await ApplySpecification(specs).ToListAsync();
        private IQueryable<TEntity> ApplySpecification(ISpecification<TEntity> specs)
            => SpecificationEvaluator<TEntity, TKey>.GetQuery(_context.Set<TEntity>(), specs);

        public async Task<int> GetCountSpecificationAsync(ISpecification<TEntity> specs)
        => await ApplySpecification(specs).CountAsync();
    }
}
