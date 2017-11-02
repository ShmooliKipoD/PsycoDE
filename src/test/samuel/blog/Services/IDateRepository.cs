using System.Collections.Generic;
using blog.Models;

namespace blog.Services
{
    public interface IDateRepository
    {
         ICollection<Trip> Trips { get; }
    }
}