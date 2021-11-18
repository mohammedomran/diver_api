using Divers.Models;
using Divers.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Divers.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MealsController : ControllerBase
    {
        private readonly IMealService _service;
        public MealsController(IMealService service)
        {
            _service = service;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Meal>> GetMeals() {
            var Meals = _service.GetMeals();
            return Ok(Meals);
        }
    }
}
