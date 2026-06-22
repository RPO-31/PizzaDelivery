using PizzaDelivery.Domain.Enums;

namespace PizzaDelivery.Domain.Models
{
    public class Order
    {
        public int Id { get; set; }

        /// <summary>
        /// Id клиента
        /// </summary>
        public Customer Customer { get; set; }

        /// <summary>
        /// Статус заказа
        /// </summary>
        public EOrderStatus OrderStatus { get; set; }

        /// <summary>
        /// Пиццы в заказе
        /// </summary>
        public Pizza Pizza { get; set; }
    }
}
