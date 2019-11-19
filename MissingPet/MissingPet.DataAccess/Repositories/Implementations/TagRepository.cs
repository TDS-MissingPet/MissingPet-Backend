﻿using MissingPet.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MissingPet.DataAccess.Repositories.Implementations
{
    public class TagRepository : IRepository<Tag>
    {
        private MissingPetContext _context;

        public TagRepository()
        {
            _context = new MissingPetContext();
        }

        public int Add(Tag item)
        {
            if(item == null)
            {
                throw new ArgumentNullException(nameof(item));
            }

            var result = _context.Tags.Add(item);
            _context.SaveChanges();

            return result.Id;
        }

        public int Delete(int id)
        {
            if(id <= 0)
            {
                throw new ArgumentException(nameof(id));
            }

            var itemToDelete = _context.Tags.FirstOrDefault(x => x.Id == id);

            if(itemToDelete == null)
            {
                throw new KeyNotFoundException($"Tag with id: {id} was not found in database.");
            }

            _context.Tags.Remove(itemToDelete);
            _context.SaveChanges();

            return id;
        }

        public Tag Get(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentException(nameof(id));
            }

            return _context.Tags.FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<Tag> GetAll() => _context.Tags.AsEnumerable();

        public Tag Update(Tag item)
        {
            throw new NotImplementedException();
        }
    }
}
