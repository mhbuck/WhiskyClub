﻿using System.Collections.Generic;

namespace WhiskyClub.Core.Models
{
    public class Whisky
    {
        public int WhiskyId { get; set; }
        public string Name { get; set; }
        public string Brand { get; set; }
        public int? Age { get; set; }
        public string Country { get; set; }
        public string Region { get; set; }
        public string Description { get; set; }
        public string ImageUri { get; set; }
        public decimal? Price { get; set; }
        public int? Volume { get; set; }

        public List<Event> Events { get; set; }
    }
}