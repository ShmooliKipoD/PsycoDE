using System;
using System.Collections.Generic;
using System.Linq;
using blog.Models;
using MongoDB.Driver;

namespace blog.Services
{
    public class MongoDataRepository : IDataRepository
    {
        BlogContext _context;

        public MongoDataRepository(BlogContext context)
        {
            this._context = context;
        }

        public ICollection<Trip> Trips
        {
            get
            {
                var trips = _context.Trips.Find(FilterDefinition<Trip>.Empty).ToList();

                this.AddIfContextEmpty(trips);

                return trips;
            }
        }

        public void AddTrip(Trip trip)
        {
            this._context.Trips.InsertOne(trip);
        }

        public Trip GetTripByName(string name)
        {
            return this.Trips
                    .Where(t => t.Name == name)
                    .SingleOrDefault();
        }

        private void AddIfContextEmpty(IEnumerable<Trip> trips)
        {
            if(trips.Count() == 0){
                var t = new Trip{
                Name = "Out",
                UserName = "The Dude",
                DateCreated = DateTime.Now,
                Stops = new List<Stop>{ 
                    new Stop() { Order = 0, Latitude =  33.748995, Longitude =  -84.387982, Name = "Atlanta, Georgia", Arrival = DateTime.Parse("Jun 3, 2014") },
                    new Stop() { Order = 1, Latitude =  48.856614, Longitude =  2.352222, Name = "Paris, France", Arrival = DateTime.Parse("Jun 4, 2014") },
                    new Stop() { Order = 2, Latitude =  50.850000, Longitude =  4.350000, Name = "Brussels, Belgium", Arrival = DateTime.Parse("Jun 25, 2014") },
                    new Stop() { Order = 3, Latitude =  51.209348, Longitude =  3.224700, Name = "Bruges, Belgium", Arrival = DateTime.Parse("Jun 28, 2014") },

                    }
                };

                var t2 = new Trip{
                Name = "Other place",
                UserName = "The Dude",
                DateCreated = DateTime.Now,
                Stops = new List<Stop>{ 
                    new Stop() { Order = 17, Latitude =  48.583148, Longitude =  7.747882, Name = "Strasbourg, France", Arrival = DateTime.Parse("Aug 17, 2014") },
                    new Stop() { Order = 18, Latitude =  46.519962, Longitude =  6.633597, Name = "Lausanne, Switzerland", Arrival = DateTime.Parse("Aug 19, 2014") },
                    new Stop() { Order = 19, Latitude =  46.021073, Longitude =  7.747937, Name = "Zermatt, Switzerland", Arrival = DateTime.Parse("Aug 27, 2014") },
                    new Stop() { Order = 20, Latitude =  46.519962, Longitude =  6.633597, Name = "Lausanne, Switzerland", Arrival = DateTime.Parse("Aug 29, 2014") },
                    new Stop() { Order = 21, Latitude =  53.349805, Longitude =  -6.260310, Name = "Dublin, Ireland", Arrival = DateTime.Parse("Sep 2, 2014") },
                    new Stop() { Order = 22, Latitude =  54.597285, Longitude =  -5.930120, Name = "Belfast, Northern Ireland", Arrival = DateTime.Parse("Sep 7, 2014") },
                    new Stop() { Order = 23, Latitude =  53.349805, Longitude =  -6.260310, Name = "Dublin, Ireland", Arrival = DateTime.Parse("Sep 9, 2014") },
                    new Stop() { Order = 24, Latitude =  47.368650, Longitude =  8.539183, Name = "Zurich, Switzerland", Arrival = DateTime.Parse("Sep 16, 2014") },
                    new Stop() { Order = 25, Latitude =  48.135125, Longitude =  11.581981, Name = "Munich, Germany", Arrival = DateTime.Parse("Sep 19, 2014") },
                    new Stop() { Order = 26, Latitude =  50.075538, Longitude =  14.437800, Name = "Prague, Czech Republic", Arrival = DateTime.Parse("Sep 21, 2014") },
                    new Stop() { Order = 27, Latitude =  51.050409, Longitude =  13.737262, Name = "Dresden, Germany", Arrival = DateTime.Parse("Oct 1, 2014") },
                    new Stop() { Order = 28, Latitude =  50.075538, Longitude =  14.437800, Name = "Prague, Czech Republic", Arrival = DateTime.Parse("Oct 4, 2014") },
                    new Stop() { Order = 29, Latitude =  42.650661, Longitude =  18.094424, Name = "Dubrovnik, Croatia", Arrival = DateTime.Parse("Oct 10, 2014") },
                    new Stop() { Order = 30, Latitude =  42.697708, Longitude =  23.321868, Name = "Sofia, Bulgaria", Arrival = DateTime.Parse("Oct 16, 2014") },
                    new Stop() { Order = 31, Latitude =  45.658928, Longitude =  25.539608, Name = "Brosov, Romania", Arrival = DateTime.Parse("Oct 20, 2014") },
                    new Stop() { Order = 32, Latitude =  41.005270, Longitude =  28.976960, Name = "Istanbul, Turkey", Arrival = DateTime.Parse("Nov 1, 2014") },
                    new Stop() { Order = 33, Latitude =  45.815011, Longitude =  15.981919, Name = "Zagreb, Croatia", Arrival = DateTime.Parse("Nov 11, 2014") },
                    new Stop() { Order = 34, Latitude =  41.005270, Longitude =  28.976960, Name = "Istanbul, Turkey", Arrival = DateTime.Parse("Nov 15, 2014") },
                    new Stop() { Order = 35, Latitude =  50.850000, Longitude =  4.350000, Name = "Brussels, Belgium", Arrival = DateTime.Parse("Nov 25, 2014") },
                    new Stop() { Order = 36, Latitude =  50.937531, Longitude =  6.960279, Name = "Cologne, Germany", Arrival = DateTime.Parse("Nov 30, 2014") },
                    new Stop() { Order = 37, Latitude =  48.208174, Longitude =  16.373819, Name = "Vienna, Austria", Arrival = DateTime.Parse("Dec 4, 2014") },
                    new Stop() { Order = 38, Latitude =  47.497912, Longitude =  19.040235, Name = "Budapest, Hungary", Arrival = DateTime.Parse("Dec 28,2014") },
                    new Stop() { Order = 39, Latitude =  37.983716, Longitude =  23.729310, Name = "Athens, Greece", Arrival = DateTime.Parse("Jan 2, 2015") },
                    new Stop() { Order = 40, Latitude =  -25.746111, Longitude =  28.188056, Name = "Pretoria, South Africa", Arrival = DateTime.Parse("Jan 19, 2015") },
                    new Stop() { Order = 41, Latitude =  43.771033, Longitude =  11.248001, Name = "Florence, Italy", Arrival = DateTime.Parse("Feb 1, 2015") },
                    new Stop() { Order = 42, Latitude =  45.440847, Longitude =  12.315515, Name = "Venice, Italy", Arrival = DateTime.Parse("Feb 9, 2015") },
                    new Stop() { Order = 43, Latitude =  43.771033, Longitude =  11.248001, Name = "Florence, Italy", Arrival = DateTime.Parse("Feb 13, 2015") },
                    new Stop() { Order = 44, Latitude =  41.872389, Longitude =  12.480180, Name = "Rome, Italy", Arrival = DateTime.Parse("Feb 17, 2015") },
                    new Stop() { Order = 45, Latitude =  28.632244, Longitude =  77.220724, Name = "New Delhi, India", Arrival = DateTime.Parse("Mar 4, 2015") },
                    new Stop() { Order = 46, Latitude =  27.700000, Longitude =  85.333333, Name = "Kathmandu, Nepal", Arrival = DateTime.Parse("Mar 10, 2015") },
                    new Stop() { Order = 47, Latitude =  28.632244, Longitude =  77.220724, Name = "New Delhi, India", Arrival = DateTime.Parse("Mar 11, 2015") },
                    new Stop() { Order = 48, Latitude =  22.1667, Longitude =  113.5500, Name = "Macau", Arrival = DateTime.Parse("Mar 21, 2015") },
                    new Stop() { Order = 49, Latitude =  22.396428, Longitude =  114.109497, Name = "Hong Kong", Arrival = DateTime.Parse("Mar 24, 2015") },
                    new Stop() { Order = 50, Latitude =  39.904030, Longitude =  116.407526, Name = "Beijing, China", Arrival = DateTime.Parse("Apr 19, 2015") },
                    new Stop() { Order = 51, Latitude =  22.396428, Longitude =  114.109497, Name = "Hong Kong", Arrival = DateTime.Parse("Apr 24, 2015") },
                    new Stop() { Order = 52, Latitude =  1.352083, Longitude =  103.819836, Name = "Singapore", Arrival = DateTime.Parse("Apr 30, 2015") },
                    new Stop() { Order = 53, Latitude =  3.139003, Longitude =  101.686855, Name = "Kuala Lumpor, Malaysia", Arrival = DateTime.Parse("May 7, 2015") },

                    }
                
                };
                _context.Trips.InsertOne(t);
                _context.Trips.InsertOne(t2);
            }
        }

        internal void AddNewStop(string name, Stop s)
        {
            Trip t = GetTripByName(name);
            var stops = t.Stops ?? new List<Stop>();
            stops.Add(s);
            var filter = Builders<Trip>.Filter.Eq("Name", name);
            var update = Builders<Trip>.Update.Set("Stops", stops);
            this._context.Trips.UpdateOne(filter, update);
        }
    }
}