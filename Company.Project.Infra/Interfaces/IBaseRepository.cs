using Company.Project.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Company.Project.Infra.Interfaces
{
    public interface IBaseRepository<T> where T : Base
    {
        Task<T> Create(T obj);
        Task<T> Update(T obj);
        Task Remove(int id);
        Task<T> Get(int id);
        Task<List<T>> Get();
    }
}
