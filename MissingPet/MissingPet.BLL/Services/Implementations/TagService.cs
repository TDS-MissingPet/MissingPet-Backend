using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MissingPet.DataAccess.Entities;
using MissingPet.DataAccess.Repositories;
using MissingPet.Domain.Models;

namespace MissingPet.BLL.Services.Implementations
{
    public class TagService : ITagService
    {
        private readonly IRepository<TagEntity> _tagRepository;

        public TagService(IRepository<TagEntity> tagRepository)
        {
            _tagRepository = tagRepository;
        }

        public IEnumerable<Tag> GetAll() => _tagRepository.GetAll().Select(x => new Tag() { Value = x.Value });
    }
}
