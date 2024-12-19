using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Domain.ModelsDb
{
    [Table("Cart")]
    public class CartDb
    {
        [Column("Id")]
        public Guid Id { get; set; }

        [Column("id_user")]
        public Guid UserId { get; set; }

        [Column("createdAt", TypeName = "timestamp")]
        public DateTime CreatedAt { get; set; }

        public ICollection<CartItemsDb> CartItemDb { get; set; }  // Связь с CartItemsDb
    }
}

