using System.Linq;
using blog.Models;
using blog.Services;
using Microsoft.AspNetCore.Mvc;

namespace blog.Controllers.Api
{
    public class TripController : Controller
    {
        private MongoDataRepository _repository;

        public TripController(MongoDataRepository repository)
        {
            this._repository = repository;
        }

        [HttpGet("api/trips")]
        public IActionResult Get()
        {
            return Ok( Json(_repository.Trips.ToList()) );
        }
    }
}