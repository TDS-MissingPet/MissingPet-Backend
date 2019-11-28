using System;

namespace MissingPet.Domain.RequestModels
{
    public class AdvertsSortRequestModel
    {
        public bool IsDesc { get; set; }

        public bool ByCity { get; set; }

        public bool ByReward { get; set; }

        public bool ByTitle { get; set; }

        public bool ByCreationDate { get; set; }
    }
}
