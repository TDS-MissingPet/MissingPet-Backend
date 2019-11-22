using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MissingPet.DataAccess.Entities
{
    public class AccountPhoneNumberEntity
    {
        public int Id { get; set; }

        public string PhoneNumber { get; set; }

        public bool IsPrimary { get; set; }

        public int AccountId { get; set; }

        public virtual AccountEntity Account { get; set; }
    }
}
