using PizzaDelivery.Domain.Enums;

namespace PizzaDelivery.Domain.Models
{
    public class Pizza
    {
        public int Id { get; set; }

        /// <summary>
        /// Название пиццы
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Описание
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Список ингридиентов
        /// </summary>
        public List<EIngridient> Ingridients { get; set; }

        /// <summary>
        /// Цена
        /// </summary>
        public int Price { get; set; }
    }
}
