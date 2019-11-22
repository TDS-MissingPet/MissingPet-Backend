using System.Collections.Generic;

namespace MissingPet.DataAccess.Entities
{
    public class TagEntity
    {
        public int Id { get; set; }

        public string Value { get; set; }

        public virtual List<AdvertEntity> Adverts { get; set; }
    }
}
