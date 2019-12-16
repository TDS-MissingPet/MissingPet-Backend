using System;
using System.Collections.Generic;

namespace MissingPet.DataAccess.Entities
{
    public class AccountEntity
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public Guid IdentityId { get; set; }

        public virtual List<AdvertEntity> Advertisements { get; set; }

        public virtual List<AccountPhoneNumberEntity> AccountPhoneNumbers { get; set; }
    }
}
