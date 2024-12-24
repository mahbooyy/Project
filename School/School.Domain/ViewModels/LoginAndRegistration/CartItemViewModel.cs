using School.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Domain.ViewModels.LoginAndRegistration
{
    public class CartItemViewModel
    {
        public Guid ProductId { get; set; }
        public string ProductName { get; set; } // Название продукта
        public int Quantity { get; set; }       // Количество
        public decimal Price { get; set; }     // Цена за единицу
        public decimal Total => Quantity * Price; // Общая стоимость

        public Guid Id { get; set; }
    }
}
