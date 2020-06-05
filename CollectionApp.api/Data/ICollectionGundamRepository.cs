using System.Collections.Generic;
using System.Threading.Tasks;
using CollectionApp.api.Models;

namespace CollectionApp.api.Data
{

    public interface ICollectionGundamRepository
    {

        void Add<T>(T entity) where T : class;

        void Delete<T>(T entity) where T : class;

        Task<bool> SaveAll();

        Task<IEnumerable<CollectionGundam>> GetCollectionGundams();
        
        Task<CollectionGundam> GetCollectionGundam(int id);
    }
}