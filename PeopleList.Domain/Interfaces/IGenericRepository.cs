using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PeopleList.Domain.Interfaces
{
    public interface IGenericRepository<T> where T : class
    {
        T GetById(int id);
        Task<T> GetByIdAsync(int id);
        IEnumerable<T> GetAll();
        Task<IEnumerable<T>> GetAllAsync();
        IEnumerable<T> Find(Expression<Func<T, bool>> expression);
        Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> expression);
        IEnumerable<T> FindAll(Expression<Func<T, bool>> expression);
        Task<IEnumerable<T>> FindAllAsync(Expression<Func<T, bool>> expression);
        void Add(T entity);
        Task<T> AddAsync(T entity);
        void AddRange(IEnumerable<T> entities);
        Task<T> AddRangeAsync(IEnumerable<T> entities);
        void Remove(T entity);
        Task<T> RemoveAsync(T entity);
        void RemoveRange(IEnumerable<T> entities);
        Task<T> RemoveRangeAsync(IEnumerable<T> entities);
    }
}
