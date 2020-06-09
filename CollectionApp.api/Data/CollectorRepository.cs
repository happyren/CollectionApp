using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CollectionApp.api.Helpers;
using CollectionApp.api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CollectionApp.api.Data
{
    public class CollectorRepository : ICollectorRepository
    {
        private readonly DataContext context;

        public CollectorRepository(DataContext context)
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

        public async Task<User> GetUser(int id)
        {
            var user = await this.context.Users.Include(p => p.Photos)
                .FirstOrDefaultAsync(u => u.Id == id);

            return user;
        }

        public async Task<PageList<User>> GetUsers(UserParams userParams)
        {
            var users =  this.context.Users.Include(p => p.Photos);

            return await PageList<User>.CreateAsync(users, userParams.PageNumber, 
            userParams.PageSize);
        }

        public async Task<bool> SaveAll()
        {
            return await this.context.SaveChangesAsync() > 0;
        }

        public async Task<Photo> GetPhoto(int id)
        {
            var photo = await context.UserPhotos.FirstOrDefaultAsync(p => p.Id == id);

            return photo;
        }

        public async Task<Photo> GetMainPhoto(int id)
        {
            return await context.UserPhotos.Where(u => u.UserId == id)
                .FirstOrDefaultAsync(p => p.IsMain);
        }
        
    }
}