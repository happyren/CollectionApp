using System.Collections.Generic;
using System.Threading.Tasks;
using CollectionApp.api.Models;
using Microsoft.EntityFrameworkCore;

namespace CollectionApp.api.Data
{

    public class CollectionGundamRepository : ICollectionGundamRepository
    {
        private readonly DataContext context;

        public CollectionGundamRepository(DataContext context)
        {
            this.context = context;
        }

        public void Add<T>(T entity) where T : class
        {
            this.context.Add(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            this.context.Remove(entity);
        }

        public async Task<CollectionGundam> GetCollectionGundam(int id)
        {
            var collectionGundam = await this.context.CollectionGundams.Include(p => p.Photos).FirstOrDefaultAsync(u => u.Id == id);

            return collectionGundam;
        }

        public async Task<IEnumerable<CollectionGundam>> GetCollectionGundams()
        {
            var collectionGundams = await this.context.CollectionGundams.Include(p => p.Photos).ToListAsync();

            return collectionGundams;
        }

        public async Task<bool> SaveAll()
        {
            return await this.context.SaveChangesAsync() > 0;
        }
    }
}