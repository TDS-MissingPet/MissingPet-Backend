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
    public class AdvertService : IAdvertService
    {
        public AdvertService(IRepository<AdvertEntity> advertRepository, IRepository<TagEntity> tagRepository)
        {
            _tagRepository = tagRepository;
            _advertRepository = advertRepository;
        }

        private readonly IRepository<AdvertEntity> _advertRepository;
        private readonly IRepository<TagEntity> _tagRepository;

        public int Add(Advert advert)
        {
            if(advert == null)
            {
                throw new ArgumentNullException(nameof(advert));
            }

            var result = _advertRepository.Add(new AdvertEntity()
            {
                CreationDate = DateTime.Now,
                Text = advert.Text,
                Reward = advert.Reward,
                Title = advert.Title,
                AccountId = advert.AccountId,
                Tags = advert.Tags.Select(x => new TagEntity() { Value = x }).ToList()
            });

            return result;
        }
    }
}
