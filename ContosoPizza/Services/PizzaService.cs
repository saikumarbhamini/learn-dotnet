using ContosoPizza.Models;
using ContosoPizza.Data;
using Microsoft.EntityFrameworkCore;

namespace ContosoPizza.Services;

public class PizzaService(PizzaContext context)
{
    private readonly PizzaContext _context = context;

    public IEnumerable<Pizza> GetAll()
    {
        return [.. _context.Pizzas
        .Include(p => p.Toppings)
        .Include(p => p.Sauce)
        .AsNoTracking()];
    }

    public Pizza? GetById(int id)
    {
        return _context.Pizzas
        .Include(p => p.Toppings)
        .Include(p => p.Sauce)
        .AsNoTracking()
        .SingleOrDefault(p => p.Id == id);
    }

    public Pizza? Create(Pizza newPizza)
    {
        _context.Pizzas.Add(newPizza);
        _context.SaveChanges();
        return newPizza;
    }

    public void AddTopping(int PizzaId, int ToppingId)
    {
        var pizzaToUpdate = _context.Pizzas.Find(PizzaId);
        var toppingsToAdd = _context.Toppings.Find(ToppingId);

        if (pizzaToUpdate is null || toppingsToAdd is null)
        {
            throw new InvalidOperationException("Pizza or Topping doesn't exist");
        }

        pizzaToUpdate.Toppings ??= [];

        pizzaToUpdate.Toppings.Add(toppingsToAdd);

        _context.SaveChanges();
    }

    public void UpdateSauce(int PizzaId, int SauceId)
    {
        var pizzaToUpdate = _context.Pizzas.Find(PizzaId);
        var sauceToUpdate = _context.Sauces.Find(SauceId);

        if (pizzaToUpdate is null || sauceToUpdate is null)
        {
            throw new InvalidOperationException("Pizza or Sauce doesn't exist");
        }

        pizzaToUpdate.Sauce = sauceToUpdate;
        _context.SaveChanges();

    }

    public void DeleteById(int id)
    {
        var pizzaToDelete = _context.Pizzas.Find(id);

        if (pizzaToDelete is null)
            throw new InvalidOperationException("Pizza doesn't exist");
        else
        {
            _context.Pizzas.Remove(pizzaToDelete);
            _context.SaveChanges();
        }
    }
}