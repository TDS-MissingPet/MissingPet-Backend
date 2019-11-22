using MissingPet.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MissingPet.DataAccess.Repositories.Implementations
{
    public class AccountPhoneNumberRepository : IRepository<AccountPhoneNumberEntity>
    {
        private MissingPetContext _context;

        public AccountPhoneNumberRepository()
        {
            _context = new MissingPetContext();
        }

        public int Add(AccountPhoneNumberEntity item)
        {
            if(item == null)
            {
                throw new ArgumentNullException(nameof(item));
            }

            var result = _context.AccountPhoneNumbers.Add(item);
            _context.SaveChanges();

            return result.Id;
        }

        public int Delete(int id)
        {
            throw new NotImplementedException();
        }

        public AccountPhoneNumberEntity Get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<AccountPhoneNumberEntity> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            throw new NotImplementedException();
        }

        public AccountPhoneNumberEntity Update(AccountPhoneNumberEntity item)
        {
            throw new NotImplementedException();
        }
    }
}
