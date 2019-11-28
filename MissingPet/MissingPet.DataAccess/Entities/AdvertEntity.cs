using System;
using System.Collections.Generic;

namespace MissingPet.DataAccess.Entities
{
    public class AdvertEntity
    {
        public int Id { get; set; }

        public string Title { get; set; } 

        public string Text { get; set; }

        public double Reward { get; set; }

        public bool IsClosed { get; set; }

        public DateTime CreationDate { get; set; }

        public virtual List<AdvertImageEntity> AdvertImages { get; set; }

        public int AdvertAddressDetailsId { get; set; }

        public virtual AdvertAddressDetailsEntity AdvertAddressDetails { get; set; }

        public virtual List<TagEntity> Tags { get; set; }

        public int AccountId { get; set; }

        public virtual AccountEntity Account { get; set; }
    }
}
