using MissingPet.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MissingPet.DataAccess.Repositories.Implementations
{
    public class AdvertAddressDetailsRepository : IRepository<AdvertAddressDetails>
    {
        private MissingPetContext _context;

        public AdvertAddressDetailsRepository()
        {
            _context = new MissingPetContext();
        }

        public int Add(AdvertAddressDetails item)
        {
            if(item == null)
            {
                throw new ArgumentNullException(nameof(item));
            }

            var result = _context.AdvertAddressDetails.Add(item);
            _context.SaveChanges();

            return result.Id;
        }

        public int Delete(int id)
        {
            if(id <= 0)
            {
                throw new ArgumentException(nameof(id));
            }

            var itemToDelete = _context.AdvertAddressDetails.FirstOrDefault(x => x.Id == id);

            if(itemToDelete == null)
            {
                throw new KeyNotFoundException($"Advert Address Details with id: {id} was not found in database.");
            }

            _context.AdvertAddressDetails.Remove(itemToDelete);
            _context.SaveChanges();

            return id;
        }

        public AdvertAddressDetails Get(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentException(nameof(id));
            }

            return _context.AdvertAddressDetails.FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<AdvertAddressDetails> GetAll() => _context.AdvertAddressDetails.AsEnumerable();

        public Advert Update(Advert item)
        {
            throw new NotImplementedException();
        }
    }
}
