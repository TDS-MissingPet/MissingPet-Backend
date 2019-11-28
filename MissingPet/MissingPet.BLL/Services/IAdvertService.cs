using MissingPet.Domain.Models;
using MissingPet.Domain.RequestModels;
using System.Collections.Generic;

namespace MissingPet.BLL.Services
{
    public interface IAdvertService
    {
        int Add(Advert advert);
        IEnumerable<Advert> GetAll(AdvertsFilterRequestModel filters, AdvertsSortRequestModel sortInfo, int pageNumber, int pageSize);

        AdvertDetails GetById(int id);
    }
}
