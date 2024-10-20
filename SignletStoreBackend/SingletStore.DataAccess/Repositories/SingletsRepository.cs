

using Microsoft.EntityFrameworkCore;
using SingletStore.Core.Models;
using SingletStore.DataAccess.Entities;

namespace SingletStore.DataAccess.Repositories
{  
    public class SingletsRepository : ISingletsRepository
    {
        private readonly SingletStoreDbContext _context;

        public SingletsRepository(SingletStoreDbContext context)
        {
            _context = context;
        }

        public async Task<List<Singlet>> Get()
        {
            var singletEntities = await _context.Singlets
                .AsNoTracking()
                .ToListAsync();

            var singlets = singletEntities
                .Select(b => Singlet.Create(b.Id, b.Title, b.Description, b.Price).Singlet)
                .ToList();

            return singlets;
        }

        public async Task<Guid> Create(Singlet singlet)
        {
            var singletEntity = new SingletEntity
            {
                Id = singlet.Id,
                Title = singlet.Title,
                Description = singlet.Description,
                Price = singlet.Price,
            };
            await _context.Singlets.AddAsync(singletEntity);
            await _context.SaveChangesAsync();

            return singletEntity.Id;
        }

        public async Task<Guid> Update(Guid id, string title , string description, decimal price)
        {
           await _context.Singlets
                .Where(b => b.Id == id)
                .ExecuteUpdateAsync(s => s
                   .SetProperty(b => b.Title, b => title)
                   .SetProperty(b => b.Description, b => description)
                   .SetProperty(b => b.Price, b => price));

            return id;
        }

        public async Task<Guid> Delete(Guid id)
        {
            await _context.Singlets
                .Where(b => b.Id == id)
                .ExecuteDeleteAsync();

            return id;
        }
    }
}
