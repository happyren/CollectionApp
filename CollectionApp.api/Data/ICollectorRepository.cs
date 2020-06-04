using System.Collections.Generic;
using System.Threading.Tasks;
using CollectionApp.api.Models;

namespace CollectionApp.api.Data
{
    public interface ICollectorRepository
    {
        void Add<T>(T entity) where T: class;
        void Delete<T>(T entity) where T: class;
        Task<bool> SaveAll();
        Task<IEnumerable<User>> GetUsers();
        Task<User> GetUser(int id);
    }
}