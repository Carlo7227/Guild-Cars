﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildCars.Models.Queries
{
    public class VehicleSearchParameters
    {
        public decimal? MaxPrice { get; set; }
        public decimal? MinPrice { get; set; }
        public int? MaxYear { get; set; }
        public int? MinYear { get; set; }
        public string Text { get; set; }
    }
}
