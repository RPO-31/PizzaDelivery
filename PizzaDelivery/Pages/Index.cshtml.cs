using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PizzaDelivery.DataAccess.Interfaces;
using PizzaDelivery.Domain.Enums;
using PizzaDelivery.Domain.Models;
using System.Text.Json;

namespace PizzaDelivery.Pages
{
    public class IndexModel : PageModel
    {
        public const string OrderTempDataKey = "Order";

        [BindProperty]
        public int SelectedCustomerId { get; set; }

        [BindProperty]
        public List<int> SelectedPizzaIds { get; set; } = new();

        public List<Pizza> Pizzas { get; set; } = new();
        public List<Customer> Customers { get; set; } = new();

        private readonly ICustomerRepository customerRepository;
        private readonly IPizzaRepository pizzaRepository;

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

        public IActionResult OnPost()
        {
            LoadData();

            var customer = Customers.FirstOrDefault(customer => customer.Id == SelectedCustomerId);
            var pizzas = Pizzas
                .Where(pizza => SelectedPizzaIds.Contains(pizza.Id))
                .ToList();

            if (customer is null)
            {
                ModelState.AddModelError(nameof(SelectedCustomerId), "Выберите клиента.");
            }

            if (pizzas.Count == 0)
            {
                ModelState.AddModelError(nameof(SelectedPizzaIds), "Выберите хотя бы одну пиццу.");
            }

            if (!ModelState.IsValid)
            {
                return Page();
            }

            var order = new Order
            {
                Customer = customer!,
                Pizzas = pizzas,
                OrderStatus = EOrderStatus.Created
            };

            TempData[OrderTempDataKey] = JsonSerializer.Serialize(order);

            return RedirectToPage("/NewOrder");
        }

        private void LoadData()
        {
            Pizzas = pizzaRepository.GetPizzas();
            Customers = customerRepository.GetCustomer();
        }
    }
}
