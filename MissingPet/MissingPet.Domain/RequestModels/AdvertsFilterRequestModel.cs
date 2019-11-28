using System;

namespace MissingPet.Domain.RequestModels
{
    public class AdvertsFilterRequestModel
    {
        public string City { get; set; }

        public DateTime CreationDateFromFilter { get; set; }

        public DateTime CreationDateToFilter { get; set; }

        public double RewardFromFilter { get; set; }

        public double RewardToFilter { get; set; }


    }
}
