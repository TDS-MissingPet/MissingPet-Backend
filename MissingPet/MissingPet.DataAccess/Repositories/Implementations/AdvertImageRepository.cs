using MissingPet.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MissingPet.DataAccess.Repositories.Implementations
{
    public class AdvertImageRepository : IRepository<AdvertImage>
    {
        private MissingPetContext _context;

        public AdvertImageRepository()
        {
            _context = new MissingPetContext();
        }

        public int Add(AdvertImage item)
        {
            if(item == null)
            {
                throw new ArgumentNullException(nameof(item));
            }

            var result = _context.AdvertImage.Add(item);
            _context.SaveChanges();

            return result.Id;
        }

        public int Delete(int id)
        {
            if(id <= 0)
            {
                throw new ArgumentException(nameof(id));
            }

            var itemToDelete = _context.AdvertImage.FirstOrDefault(x => x.Id == id);

            if(itemToDelete == null)
            {
                throw new KeyNotFoundException($"Advert Image with id: {id} was not found in database.");
            }

            _context.AdvertImage.Remove(itemToDelete);
            _context.SaveChanges();

            return id;
        }

        public AdvertImage Get(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentException(nameof(id));
            }

            return _context.AdvertImage.FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<AdvertImage> GetAll() => _context.AdvertImage.AsEnumerable();

        public AdvertImage Update(AdvertImage item)
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
