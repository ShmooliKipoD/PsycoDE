using System;

namespace blog.ViewModels
{
    public class StopViewModel
    {
        public string Name { get; set; }

        public double Latitude { get; set; }

        public double Longitude { get; set; }

        public int Order { get; set; }
   
        public DateTime Arrival { get; set; } = DateTime.UtcNow;
    }
}