using System.Collections.Generic;
using System.Threading.Tasks;
using CollectionApp.api.Helpers;
using CollectionApp.api.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;

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
        
        public async Task<PageList<CollectionGundam>> GetGundams(UserParams userParams)
        {
            var gundams = this.context.CollectionGundams.OrderByDescending(p => p.Id)
                .Include(p => p.Photos).AsQueryable();

            if (userParams.Likees)
            {
                var gundamLikees = await GetLikees(userParams.UserId);
                gundams = gundams.Where(g => gundamLikees.Contains(g.Id));
            }

            return await PageList<CollectionGundam>.CreateAsync(gundams, userParams
            .PageNumber,
                userParams.PageSize);
        }

        public async Task<IEnumerable<int>> GetLikees(int id)
        {
            var user = await context.Users.Include(x => x.Likees).FirstOrDefaultAsync(u
                => u.Id == id);
            return user.Likees.Where(u => u.LikerId == id).Select(i => i.LikeeId);
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