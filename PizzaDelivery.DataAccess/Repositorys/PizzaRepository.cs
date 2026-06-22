using PizzaDelivery.DataAccess.Interfaces;
using PizzaDelivery.Domain.Enums;
using PizzaDelivery.Domain.Models;

namespace PizzaDelivery.DataAccess.Repositorys
{
    public class PizzaRepository : IPizzaRepository
    {
        public List<Pizza> GetPizzas()
        {
            return new List<Pizza>()
            {
                new  Pizza
                { 
                    Id = 1,
                    Name = "Pepperoni",
                    Description = "Пицца с пеперони",
                    Ingridients = new List<EIngridient>() { EIngridient.Pepperoni, EIngridient.Cheese },
                    Price = 300
                },
                new  Pizza
                {
                    Id = 2,
                    Name = "Пицца с ананасами",
                    Description = "Вкусные ананасы!",
                    Ingridients = new List<EIngridient>() { EIngridient.Pineapples, EIngridient.Cheese },
                    Price = 400
                },
                new  Pizza
                {
                    Id = 3,
                    Name = "Пицца с оливками",
                    Description = "Вкус греции!",
                    Ingridients = new List<EIngridient>() { EIngridient.Olives, EIngridient.Onion },
                    Price = 500
                }
            };
        }
    }
}
