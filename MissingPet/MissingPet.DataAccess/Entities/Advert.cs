using System;
using System.Collections.Generic;

namespace MissingPet.DataAccess.Entities
{
    public class Advert
    {
        public int Id { get; set; }

        public string Title { get; set; } 

        public string Text { get; set; }

        public double Reward { get; set; }

        public bool IsClosed { get; set; }

        public DateTime CreationDate { get; set; }

        public virtual List<ContactPersonDetails> ContactPersonsDetails { get; set; }

        public virtual List<AdvertImage> AdvertImages { get; set; }

        public virtual List<Tag> Tags { get; set; }
    }
}
