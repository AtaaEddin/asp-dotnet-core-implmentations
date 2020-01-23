using System.Linq.Expressions;
using Postgres.Business.Entites;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Postgres.Business.Interfaces
{
    public interface IEFRepository<T> where T : BaseEntity,IAggregateRoot 
    {
        Task<T> findAsync(int id);
        Task<List<T>> findAllAsync();
        Task<T> addAsync(T entity);
        Task updateAsync(T entity);
        Task deleteAsync(T entity);

    }
}