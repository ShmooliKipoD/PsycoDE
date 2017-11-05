using System;
using System.Collections.Generic;
using AutoMapper;
using blog.Models;
using blog.Services;
using blog.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace blog.Controllers.Api
{
    ///api/trips/Other%29place/stops
    [Route("/api/trips/{name}/stops")]
    public class StopController : Controller
    {
        private MongoDataRepository _repository;

        public StopController(MongoDataRepository repository)
        {
            this._repository = repository;
        }

        [HttpGet("")]
        public IActionResult Get(string name)
        {
            try{
                var stop = Mapper.Map<IEnumerable<StopViewModel>>(this._repository.GetTripByName(name)?.Stops);
                return Ok(stop);
            }
            catch(Exception e)
            {
                return BadRequest($"Failed to get stops {e.Message}");
            }
        }

        [HttpPost("")]
        public IActionResult Post(string name, [FromBody]StopViewModel vm)
        {
            try
            {
                if(ModelState.IsValid){

                    Stop s = Mapper.Map<Stop>(vm);

                    _repository.AddNewStop(name, s);

                    return Created($"/api/trips/{name}/stops/{s.Name}",
                                   Mapper.Map<StopViewModel>(s));
                }

                return BadRequest("model is not valid");
            
            }
            catch(Exception e)
            {
                return BadRequest($"Failed to get stops {e.Message}");
            }
        }
    }
}