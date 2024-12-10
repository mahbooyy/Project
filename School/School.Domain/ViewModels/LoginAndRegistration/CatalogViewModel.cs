using System;
using System.Collections.Generic;

namespace School.Domain.ViewModels.LoginAndRegistration
{
    public class CatalogViewModel
    {
        public List<CategoryProductsViewModel> Categories { get; set; }

        public List<ListOfProductsViewModel> Products { get; set; }

        public Guid Id_Category { get; set; }
    }
}
