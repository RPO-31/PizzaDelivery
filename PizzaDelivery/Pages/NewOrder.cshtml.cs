using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PizzaDelivery.Domain.Models;
using System.Text.Json;

namespace PizzaDelivery.Pages
{
    public class NewOrderModel : PageModel
    {
        public Order? Order { get; set; }

        public IActionResult OnGet()
        {
            if (!TempData.TryGetValue(IndexModel.OrderTempDataKey, out var orderData) ||
                orderData is not string serializedOrder)
            {
                return RedirectToPage("/Index");
            }

            Order = JsonSerializer.Deserialize<Order>(serializedOrder);

            if (Order is null)
            {
                return RedirectToPage("/Index");
            }

            return Page();
        }
    }
}
