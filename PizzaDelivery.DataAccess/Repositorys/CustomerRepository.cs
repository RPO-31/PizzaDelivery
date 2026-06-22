using PizzaDelivery.DataAccess.Interfaces;
using PizzaDelivery.Domain.Models;

namespace PizzaDelivery.DataAccess.Repositorys
{
    public class CustomerRepository : ICustomerRepository
    {
        public List<Customer> GetCustomer()
        {
            return new List<Customer>
            {
                new Customer
                {
                    Id = 1,
                    Name = "Petrovich",
                    Address = "Sterlitamak"
                }
            };
        }
    }
}