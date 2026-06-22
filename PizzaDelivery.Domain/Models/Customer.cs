namespace PizzaDelivery.Domain.Models
{
    public class Customer
    {
        public int Id { get; set; }

        /// <summary>
        /// Имя клиента
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Адрес
        /// </summary>
        public string Address { get; set; }
    }
}
