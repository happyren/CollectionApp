using System.Collections.Generic;
using System.Threading.Tasks;
using CollectionApp.api.Helpers;
using CollectionApp.api.Models;

namespace CollectionApp.api.Data
{
    public interface ICollectorRepository
    {
        void Add<T>(T entity) where T : class;
        void Delete<T>(T entity) where T : class;
        Task<bool> SaveAll();
        Task<PageList<User>> GetUsers(UserParams userParams);
        Task<User> GetUser(int id);
        Task<Photo> GetPhoto(int id);
        Task<Photo> GetMainPhoto(int id);
        Task<Like> GetLike(int userId, int gundamId);
    }
}