using MissingPet.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MissingPet.DataAccess.Repositories.Implementations
{
    public class ContactPersonDetailsRepository : IRepository<ContactPersonDetails>
    {
        private MissingPetContext _context;

        public ContactPersonDetailsRepository()
        {
            _context = new MissingPetContext();
        }

        public int Add(ContactPersonDetails item)
        {
            if(item == null)
            {
                throw new ArgumentNullException(nameof(item));
            }

            var result = _context.ContactPersonDetails.Add(item);
            _context.SaveChanges();

            return result.Id;
        }

        public int Delete(int id)
        {
            if(id <= 0)
            {
                throw new ArgumentException(nameof(id));
            }

            var itemToDelete = _context.ContactPersonDetails.FirstOrDefault(x => x.Id == id);

            if(itemToDelete == null)
            {
                throw new KeyNotFoundException($"Contact Person Details with id: {id} was not found in database.");
            }

            _context.ContactPersonDetails.Remove(itemToDelete);
            _context.SaveChanges();

            return id;
        }

        public ContactPersonDetails Get(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentException(nameof(id));
            }

            return _context.ContactPersonDetails.FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<ContactPersonDetails> GetAll() => _context.ContactPersonDetails.AsEnumerable();

        public void Save()
        {
            _context.SaveChanges();
        }

        public ContactPersonDetails Update(ContactPersonDetails item)
        {
            throw new NotImplementedException();
        }
    }
}
