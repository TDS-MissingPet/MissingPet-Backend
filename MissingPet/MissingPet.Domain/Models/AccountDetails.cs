﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MissingPet.Domain.Models
{
    public class AccountDetails
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public IEnumerable<string> PhoneNumber { get; set; }


    }
}
