using Criando_API.Models;
using Criando_API.Services;
using Microsoft.AspNetCore.Mvc;

namespace Criando_API.Controllers;

[ApiController]
[Route("[controller]")]

public class PizzaController : ControllerBase{
    public PizzaController(){

    }

    [HttpGet]
    public ActionResult<List<Pizza>> getAll() => PizzaService.GetAll();

    [HttpGet("{id}")]
    public ActionResult<Pizza> Get(int id){
        var pizza = PizzaService.Get(id);
        if(pizza == null)
            return NotFound();

        return pizza;
    }

    [HttpPost]
    public IActionResult Create(Pizza pizza){
        PizzaService.Add(pizza);
        return CreatedAtAction(nameof(Create), new{id = pizza.Id}, pizza);
    }
    [HttpPut("{id}")]
    public IActionResult Updade(int id, Pizza pizza){
        if(id != pizza.Id)
            return BadRequest();
        var existingPizza = PizzaService.Get(id);
        if(existingPizza is null)
            return NotFound();
        PizzaService.Update(pizza);

        return NoContent();
    }
    [HttpDelete("{id}")]
    public IActionResult Delete(int id){
        var pizza = PizzaService.Get(id);

        if(pizza is null)
            return NotFound();

        PizzaService.Delete(id);
        
        return NoContent();
    }
}
