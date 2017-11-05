using System.Linq;
using blog.Models;
using blog.Services;
using blog.ViewModels;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using System.Collections.Generic;
using System;
using System.Collections;

namespace blog.Controllers.Api
{
    [Route("api/trips")]
    public class TripController : Controller
    {
        private MongoDataRepository _repository;

        public TripController(MongoDataRepository repository)
        {
            this._repository = repository;
        }

        [HttpGet("")]
        public IActionResult Get()
        {
            IEnumerable<TripViewModel> result = new List<TripViewModel>();
            try
            {
                var t = _repository.Trips;
                 result = Mapper.Map<IEnumerable<TripViewModel>>(t);
                
            }
            catch(Exception e)
            {
                BadRequest($"{e.Message}");
            }
            return Ok(result);
        }

        [HttpPost("")]
        public IActionResult Post([FromBody]TripViewModel trip)
        {
            if(ModelState.IsValid)
            {
                Trip t = Mapper.Map<Trip>(trip);

                this._repository.AddTrip(t);

                return Created($"api/trips/{trip.Name}", Mapper.Map<TripViewModel>(t));
            }

            return BadRequest("Bad Data");
        }
    }
}