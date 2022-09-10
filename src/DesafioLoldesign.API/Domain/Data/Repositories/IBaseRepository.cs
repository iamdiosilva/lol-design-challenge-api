using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DesafioLoldesign.API.Domain.Data.Repositories
{
    public interface IBaseRepository <T> where T : class
    {
        Task<T> Add(T obj);
        Task<T> GetById(Guid id);
        Task<List<T>> GetAll();
        Task<T> Update(T obj);
        Task Remove(Guid id);
        Task<bool> SaveChangesAsync();
    }
    
}