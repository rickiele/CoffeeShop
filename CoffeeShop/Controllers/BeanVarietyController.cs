using Microsoft.AspNetCore.Mvc;
using CoffeeShop.Models;
using CoffeeShop.Repositories;

namespace CoffeeShop.Controllers
{
    // In the controller above note that we decorate each method (a.k.a. controller action) with an attribute that denotes the HTTP verb that method responds to.

    // Some of the [HttpXXX]attributes refer to {id}. The id in this case says this method expects the URL to contain a route parameter with the bean variety's id.
    // For example in order to delete the bean variety with an id of 42 we would make a DELETE request to this URl:
    // https://localhost:5001/api/beanvariety/42

    // You'll also note that, unlike MVC, we don't have two methods for creating, editing or deleting entities.
    // This is because Web API does not have the concept of Views, so there are no forms to present to the user.

    // Also, since there is no View, you won't see a call the the View() method as we did in MVC. Instead you'll see a few other methods.
    // Two common methods are Ok() and NoContent().

    // Ok() is used when we want to return data.
    // NoContent() is used to indicate that the action was successful, but we don't have any data to return.


    // Some final differences from an MVC controller can be seen at the top of the class.
    // We must decorate a Web API controller with a couple of attributes and the controller class should inherit from the ControllerBase class instead of Controller.
    [Route("api/[controller]")]
    [ApiController]
    public class BeanVarietyController : ControllerBase
    {
        private readonly IBeanVarietyRepository _beanVarietyRepository;
        public BeanVarietyController(IBeanVarietyRepository beanVarietyRepository)
        {
            _beanVarietyRepository = beanVarietyRepository;
        }

        // https://localhost:5001/api/beanvariety/
        [HttpGet]

        // GET for retrieving one or more entities
        public IActionResult Get()
        {
            return Ok(_beanVarietyRepository.GetAll());
        }

        // https://localhost:5001/api/beanvariety/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var variety = _beanVarietyRepository.Get(id);
            if (variety == null)
            {
                return NotFound();
            }
            return Ok(variety);
        }

        // POST for creating a new entity
        // https://localhost:5001/api/beanvariety/
        [HttpPost]
        public IActionResult Post(BeanVariety beanVariety)
        {
            _beanVarietyRepository.Add(beanVariety);
            return CreatedAtAction("Get", new { id = beanVariety.Id }, beanVariety);
        }

        // PUT for updating an entity
        // https://localhost:5001/api/beanvariety/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, BeanVariety beanVariety)
        {
            if (id != beanVariety.Id)
            {
                return BadRequest();
            }

            _beanVarietyRepository.Update(beanVariety);
            return NoContent();
        }

        // DELETE for removing an entity
        // https://localhost:5001/api/beanvariety/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _beanVarietyRepository.Delete(id);
            return NoContent();
        }
    }
}
