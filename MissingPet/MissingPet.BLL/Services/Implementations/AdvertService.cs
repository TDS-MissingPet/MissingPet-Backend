using System;
using System.Collections.Generic;
using System.Linq;
using MissingPet.DataAccess.Entities;
using MissingPet.DataAccess.Repositories;
using MissingPet.Domain.Models;
using MissingPet.Domain.RequestModels;

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
            if (advert == null)
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
                Tags = advert.Tags?.Select(x => new TagEntity() { Value = x }).ToList(),
                AdvertAddressDetails = advert.AdvertAddressDetails != null ? new AdvertAddressDetailsEntity()
                {
                    City = advert.AdvertAddressDetails.City,
                    Street = advert.AdvertAddressDetails.Street
                } : null
            });

            return result;
        }

        public IEnumerable<Advert> GetAll(AdvertsFilterRequestModel filters, AdvertsSortRequestModel sortInfo, int pageNumber = 0, int pageSize = 10)
        {
            var adverts = _advertRepository.GetAll();

            if (filters != null)
            {
                adverts = FilterAdverts(adverts, filters);
            }

            if (sortInfo != null)
            {
                adverts = SortAdverts(adverts, sortInfo);
            }

            var mappedAdverts = adverts.Where(x => !x.IsClosed)
                .Skip(pageNumber * pageSize).Select(x => new Advert()
                {
                    AccountId = x.AccountId,
                    Tags = x.Tags.Select(c => c.Value).ToList(),
                    Reward = x.Reward,
                    CreationDate = x.CreationDate,
                    Title = x.Title,
                    Text = x.Text,
                    ImageUrl = x.AdvertImages.FirstOrDefault().Url,
                    Account = new Account()
                    {
                        FirstName = x.Account.FirstName,
                        LastName = x.Account.LastName,
                        PhoneNumber = x.Account.AccountPhoneNumbers.FirstOrDefault(c => c.IsPrimary).PhoneNumber
                    }
                }).Take(pageSize);

            return mappedAdverts;
        }

        public AdvertDetails GetById(int id)
        {
            if (id == 0)
            {
                throw new ArgumentNullException(nameof(id));
            }

            var adverts = _advertRepository.GetAll();
            var dbAdvert = adverts.FirstOrDefault(x => !x.IsClosed && x.Id == id);

            if (dbAdvert == null)
            {
                throw new ArgumentException("Partner id is invalid or doesn't exists.");
            }

            var advert = new AdvertDetails()
            {
                AccountId = dbAdvert.AccountId,
                Tags = dbAdvert.Tags.Select(c => c.Value).ToList(),
                Reward = dbAdvert.Reward,
                Text = dbAdvert.Text,
                CreationDate = dbAdvert.CreationDate,
                Title = dbAdvert.Title,
                AccountDetails = new AccountDetails()
                {
                    FirstName = dbAdvert.Account.FirstName,
                    LastName = dbAdvert.Account.LastName,
                    PhoneNumber = dbAdvert.Account.AccountPhoneNumbers.Select(x => x.PhoneNumber)
                },
                AdvertAddressDetails = new AdvertAddressDetails()
                {
                    City = dbAdvert.AdvertAddressDetails.City,
                    Street = dbAdvert.AdvertAddressDetails.Street
                },
                AdvertImages = dbAdvert.AdvertImages.Select(x => new ImageInfo()
                {
                    Name = x.Name,
                    Url = x.Url
                }).ToList()
            };

            return advert;
        }

        private IQueryable<AdvertEntity> FilterAdverts(IQueryable<AdvertEntity> adverts, AdvertsFilterRequestModel filters)
        {
            IQueryable<AdvertEntity> resultQuery = adverts;

            if (!string.IsNullOrWhiteSpace(filters.City))
            {
                resultQuery = adverts.Where(x => x.AdvertAddressDetails.City == filters.City);
            }

            if (filters.CreationDateFromFilter != new DateTime())
            {
                resultQuery = adverts.Where(x => x.CreationDate >= filters.CreationDateFromFilter);
            }

            if (filters.CreationDateToFilter != new DateTime())
            {
                resultQuery = adverts.Where(x => x.CreationDate <= filters.CreationDateToFilter);
            }

            if (filters.RewardToFilter != 0)
            {
                resultQuery = adverts.Where(x => x.Reward <= filters.RewardToFilter);
            }

            if (filters.RewardFromFilter != 0)
            {
                resultQuery = adverts.Where(x => x.Reward >= filters.RewardFromFilter);
            }

            return resultQuery;
        }

        private IQueryable<AdvertEntity> SortAdverts(IQueryable<AdvertEntity> adverts, AdvertsSortRequestModel sortOrder)
        {
            IQueryable<AdvertEntity> resultQuery = adverts;

            if (sortOrder.ByCity)
            {
                resultQuery = sortOrder.IsDesc ? adverts.OrderByDescending(x => x.AdvertAddressDetails.City) : adverts.OrderBy(x => x.AdvertAddressDetails.City);
            }

            if (sortOrder.ByReward)
            {
                resultQuery = sortOrder.IsDesc ? adverts.OrderByDescending(x => x.Reward) : adverts.OrderBy(x => x.Reward);
            }

            if (sortOrder.ByTitle)
            {
                resultQuery = sortOrder.IsDesc ? adverts.OrderByDescending(x => x.Title) : adverts.OrderBy(x => x.Title);
            }

            if (sortOrder.ByCreationDate)
            {
                resultQuery = sortOrder.IsDesc ? adverts.OrderByDescending(x => x.CreationDate) : adverts.OrderBy(x => x.CreationDate);
            }

            return resultQuery;
        }
    }
}
