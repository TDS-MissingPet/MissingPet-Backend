using MissingPet.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MissingPet.DataAccess.Repositories.Implementations
{
    public class AdvertRepository : IRepository<Advert>
    {
        private MissingPetContext _context;

        public AdvertRepository()
        {
            _context = new MissingPetContext();
        }

        public int Add(Advert item)
        {
            if(item == null)
            {
                throw new ArgumentNullException(nameof(item));
            }

            var result = _context.Adverts.Add(item);
            _context.SaveChanges();

            return result.Id;
        }

        public int Delete(int id)
        {
            if(id <= 0)
            {
                throw new ArgumentException(nameof(id));
            }

            var itemToDelete = _context.Adverts.FirstOrDefault(x => x.Id == id);

            if(itemToDelete == null)
            {
                throw new KeyNotFoundException($"Advert with id: {id} was not found in database.");
            }

            _context.Adverts.Remove(itemToDelete);
            _context.SaveChanges();

            return id;
        }

        public Advert Get(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentException(nameof(id));
            }

            return _context.Adverts.FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<Advert> GetAll() => _context.Adverts.AsEnumerable();

        public Advert Update(Advert item)
        {
            throw new NotImplementedException();
        }
    }
}
