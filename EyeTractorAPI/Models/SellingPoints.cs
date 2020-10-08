using System;
using System.Collections.Generic;

namespace EyeTractorAPI.Models
{
    public partial class SellingPoints
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Vicinity { get; set; }
        public decimal? Latitude { get; set; }
        public decimal? Longitude { get; set; }
    }
}
