﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MissingPet.Domain.Models
{
    public class Advert
    {
        public string Title { get; set; }

        public string Text { get; set; }

        public double Reward { get; set; }

        public int AccountId { get; set; }

        public DateTime CreationDate { get; set; }

        public List<string> Tags { get; set; }

        public Account Account { get; set; }

        public AdvertAddressDetails AdvertAddressDetails { get; set; }

        public string ImageUrl { get; set; }
    }
}
