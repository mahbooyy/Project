﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Domain.ModelsDb
{
    [Table("products")]
    public class ProductsDb
    {
        [Column("id")]
        public Guid Id { get; set; }

        [Column("id_category")]
        public Guid Id_Category { get; set; }

        [Column("name")]
        public string Name { get; set; }

        [Column("price")]
        public decimal Price { get; set; }

        [Column("pathImg")]
        public string PathImage { get; set; }

        [Column("createdAt", TypeName = "timestamp")]
        public DateTime CreatedAt { get; set; }

        [Column("opisanie")]
        public string Opisanie { get; set; }

        // Навигационное свойство для CategoryDb
        public CategoryDb CategoryDb { get; set; }

        public ICollection<CartItemsDb> CartItemDb { get; set; }
    }

}

