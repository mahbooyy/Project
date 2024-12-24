using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Domain.ModelsDb
{
    [Table("CartItems")]
    public class CartItemsDb
    {
        [Column("Id")]
        public Guid Id { get; set; }

        [Column("CartId")]
        public Guid CartId { get; set; }

        [Column("ProductId")]
        public Guid ProductId { get; set; }

        [Column("Quantity")]
        public int Quantity { get; set; }

        [Column("Price")]

        public decimal Price { get; set; }

        public CartDb CartDb { get; set; }  // Связь с CartDb
        public ProductsDb ProductsDb { get; set; }  // Связь с ProductsDb
    }
}
