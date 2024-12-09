using System.Collections.Generic;
using System;

namespace School.Domain.ViewModels.LoginAndRegistration
{
    public class ProductsPageViewModel
    {
        public Guid Id { get; set; }

        public Guid Id_Category { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public string PathImage { get; set; }

        public DateTime CreatedAt { get; set; }

        public string Opisanie { get; set; }

        public List<PictureProductsViewModel> PictureProducts { get; set; }
    }

    public class PictureProductsViewModel
    {
        public string PathImage { get; set; }
    }
}
