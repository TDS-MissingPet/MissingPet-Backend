using System.Collections.Generic;
using System.Linq;

namespace MissingPet.DataAccess.Repositories
{
    public interface IRepository<T>
    {
        IQueryable<T> GetAll();
        T Get(int id);
        int Delete(int id);
        int Add(T item);
        T Update(T item);
        void Save();
    }
}
