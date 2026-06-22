using PizzaDelivery.Domain.Models;

namespace PizzaDelivery.DataAccess.Interfaces
{
    public interface ICustomerRepository
    {
        List<Customer> GetCustomer();
    }
}
