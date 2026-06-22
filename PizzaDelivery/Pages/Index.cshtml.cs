using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PizzaDelivery.DataAccess.Interfaces;
using PizzaDelivery.Domain.Models;

namespace PizzaDelivery.Pages
{
    public class IndexModel : PageModel
    {
        [BindProperty]
        public Order Order { get; set; }

        public List<Pizza> Pizzas { get; set; }
        public List<Customer> Customers { get; set; }

        private ICustomerRepository customerRepository;
        private IPizzaRepository pizzaRepository;

        public IndexModel(ICustomerRepository customerRepository,
            IPizzaRepository pizzaRepository)
        {
            this.customerRepository = customerRepository;
            this.pizzaRepository = pizzaRepository;
        }

        public void OnGet()
        {
            LoadData();
        }

        private void LoadData()
        {
            Pizzas = pizzaRepository.GetPizzas();
            Customers = customerRepository.GetCustomer();
        }
    }
}
