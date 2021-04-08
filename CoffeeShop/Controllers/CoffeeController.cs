using Microsoft.AspNetCore.Mvc;
using CoffeeShop.Models;
using CoffeeShop.Repositories;

namespace CoffeeShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoffeeController : ControllerBase
    {
        private readonly ICoffeeRepository _coffeeRepo;
        public CoffeeController(ICoffeeRepository coffeeRepo)
        {
            _coffeeRepo = coffeeRepo;
        }

        // https://localhost:5001/api/coffee/
        [HttpGet]

        // GET for retrieving one or more entities
        public IActionResult Get()
        {
            return Ok(_coffeeRepo.GetAll());
        }

        // https://localhost:5001/api/coffee/1
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var coffees = _coffeeRepo.GetById(id);
            if (coffees == null)
            {
                return NotFound();
            }
            return Ok(coffees);
        }

        // POST for creating a new entity
        // https://localhost:5001/api/coffee/
        [HttpPost]
        public IActionResult Post(Coffee coffee)
        {
            _coffeeRepo.Add(coffee);
            return CreatedAtAction("Get", new { id = coffee.Id }, coffee);
        }

        // PUT for updating an entity
        // https://localhost:5001/api/coffee/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, Coffee coffee)
        {
            if (id != coffee.Id)
            {
                return BadRequest();
            }

            _coffeeRepo.Update(coffee);
            return NoContent();
        }

        // DELETE for removing an entity
        // https://localhost:5001/api/coffee/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _coffeeRepo.Delete(id);
            return NoContent();
        }
    }
}
