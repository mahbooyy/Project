using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Domain.ViewModels.LoginAndRegistration
{
    public class ListOfProductsViewModel
    {
        public List<ProductsForListOfProductsViewModel> Products { get; set; }
        public Guid Id { get; set; }

        public Guid Id_Category { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public string PathImage { get; set; }

        public DateTime CreatedAt { get; set; }

        public string Opisanie { get; set; }
    }

    public class ProductsForListOfProductsViewModel
    {
        public Guid Id { get; set; }

        public Guid Id_Category { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public string PathImage { get; set; }

        public DateTime CreatedAt { get; set; }

        public string Opisanie { get; set; }
    }

}
