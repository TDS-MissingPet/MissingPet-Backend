using MissingPet.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MissingPet.DataAccess
{
    public class MissingPetContext : DbContext
    {
        public MissingPetContext() : base("MissingPetConnection")
        {

        }

        public DbSet<Advert> Adverts { get; set; }
        public DbSet<AdvertAddressDetails> AdvertAddressDetails { get; set; }
        public DbSet<AdvertImage> AdvertImage { get; set; }
        public DbSet<ContactPersonDetails> ContactPersonDetails { get; set; }
        public DbSet<Tag> Tags { get; set; }
    }
}
