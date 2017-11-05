using System.Collections.Generic;
using blog.Models;

namespace blog.Services
{
    public interface IDataRepository
    {
         ICollection<Trip> Trips { get; }

         void AddTrip(Trip trip);

         Trip GetTripByName(string name);
    }
}