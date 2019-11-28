using MissingPet.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MissingPet.DataAccess.Repositories.Implementations
{
    public class AccountRepository : IRepository<AccountEntity>
    {
        private MissingPetContext _context;

        public AccountRepository()
        {
            _context = new MissingPetContext();
        }

        public int Add(AccountEntity item)
        {
            if(item == null)
            {
                throw new ArgumentNullException(nameof(item));
            }

            var result = _context.Accounts.Add(item);
            _context.SaveChanges();

            return result.Id;
        }

        public int Delete(int id)
        {
            throw new NotImplementedException();
        }

        public AccountEntity Get(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentException(nameof(id));
            }

            return _context.Accounts.FirstOrDefault(x => x.Id == id);
        }

        public IQueryable<AccountEntity> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public AccountEntity Update(AccountEntity item)
        {
            throw new NotImplementedException();
        }
    }
}
