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

        public DbSet<AdvertEntity> Adverts { get; set; }
        public DbSet<AdvertAddressDetailsEntity> AdvertAddressDetails { get; set; }
        public DbSet<AdvertImageEntity> AdvertImage { get; set; }
        public DbSet<AccountEntity> Accounts { get; set; }
        public DbSet<TagEntity> Tags { get; set; }
        public DbSet<AccountPhoneNumberEntity> AccountPhoneNumbers { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AdvertEntity>().ToTable("Adverts");
            modelBuilder.Entity<AdvertAddressDetailsEntity>().ToTable("AdvertAddressDetails");
            modelBuilder.Entity<AdvertImageEntity>().ToTable("AdvertImage");
            modelBuilder.Entity<AccountEntity>().ToTable("Accounts");
            modelBuilder.Entity<TagEntity>().ToTable("Tags");
            modelBuilder.Entity<AccountPhoneNumberEntity>().ToTable("AccountPhoneNumbers");

            modelBuilder.Entity<AdvertEntity>()
                .HasMany<TagEntity>(s => s.Tags)
                .WithMany(c => c.Adverts)
                .Map(cs =>
                {
                    cs.ToTable("AdvertTags");
                });
            base.OnModelCreating(modelBuilder);
        }
    }
}
