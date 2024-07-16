using ContosoPizza.Models;
using ContosoPizza.Services;
using Microsoft.AspNetCore.Mvc;

namespace ContosoPizza.Controllers;

[ApiController]
[Route("[controller]")]
public class PizzaController : ControllerBase
{
    PizzaService _service;
    public PizzaController(PizzaService service)
    {
        _service=service;
    }

    // Get all items.
    [HttpGet]
    public IEnumerable<Pizza> GetAll() =>
        _service.GetAll();

    // Get a specific item.
    [HttpGet("{id}")]
    public ActionResult<Pizza> GetById(int id)
    {
        var pizza = _service.GetById(id);
        if (pizza == null)
            return NotFound();
        return pizza;
    }

    [HttpPost]
    public IActionResult Create(Pizza newPizza)
    {
        var pizza = _service.Create(newPizza);
        return CreatedAtAction(nameof(GetById), new { id = pizza!.Id }, pizza);

    }

    [HttpPut("{id}/add_topping")]
    public IActionResult AddTopping(int id, int topingId)
    {
        var pizzaToUpdate = _service.GetById(id);
        if (pizzaToUpdate is null)
            return NotFound();
        else
        {
            _service.AddTopping(id, topingId);
            return NoContent();
        }
    }

    [HttpPut("{id}/updateSauce")]
    public IActionResult UpdateSauce(int id, int sauceId)
    {
        var pizzaToUpdate = _service.GetById(id);
        if(pizzaToUpdate is null)
        return NotFound();
        else
        {
            _service.UpdateSauce(id, sauceId);
            return NoContent();
        }
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var pizza = _service.GetById(id);
        if (pizza is null)
            return NotFound();
        _service.DeleteById(id);
        return NoContent();
    }
}