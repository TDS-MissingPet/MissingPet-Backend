using System.Collections.Generic;

namespace MissingPet.DataAccess.Repositories
{
    public interface IRepository<T>
    {
        IEnumerable<T> GetAll();
        T Get(int id);
        int Delete(int id);
        int Add(T item);
        T Update(T item);
        void Save();
    }
}
