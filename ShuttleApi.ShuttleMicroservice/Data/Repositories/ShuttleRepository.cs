using Microsoft.EntityFrameworkCore;
using ShuttleApi.ShuttleMicroservice.Models;

namespace ShuttleApi.ShuttleMicroservice.Data
{
    public class ShuttleRepository : IBaseRepository<Shuttle>
    {
        private readonly ShuttleDbContext _context;
        public ShuttleRepository(ShuttleDbContext context)
        {
            _context = context;
        }
        public async Task Create(Shuttle entity)
        {
            var checkEntity = await _context.Set<Shuttle>().FirstOrDefaultAsync(s => s.Id == entity.Id);
            if (checkEntity != null)
                throw new InvalidOperationException();
            await _context.Set<Shuttle>().AddAsync(entity);
        }

        public async Task Delete(Guid id)
        {
            var checkEntity = await _context.Set<Shuttle>().FirstOrDefaultAsync(s => s.Id == id) ?? throw new InvalidOperationException();
            _context.Set<Shuttle>().Remove(checkEntity);
        }

        public async Task<IEnumerable<Shuttle>> GetAll()
        {
            return await _context.Set<Shuttle>().ToListAsync();
        }

        public async Task<Shuttle> GetById(Guid id)
        {
            var checkEntity = await _context.Set<Shuttle>().FirstOrDefaultAsync(s => s.Id == id) ?? throw new InvalidOperationException();
            return checkEntity;
        }

        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }

        public async Task Update(Shuttle entity)
        {
            var checkEntity = await _context.Set<Shuttle>().FirstOrDefaultAsync(s => s.Id == entity.Id) ?? throw new InvalidOperationException();
            _context.Set<Shuttle>().Update(checkEntity);
            await Save();
            
        }
    }
}
