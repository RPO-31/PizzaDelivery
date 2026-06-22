using PizzaDelivery.Domain.Models;

namespace PizzaDelivery.DataAccess.Interfaces
{
    public interface IPizzaRepository
    {
        List<Pizza> GetPizzas();
    }
}
