﻿        using System;
        using System.Collections.Generic;
        using System.Linq;
        using System.Text;
        using System.Threading.Tasks;

        namespace School.Domain.ViewModels.LoginAndRegistration
        {
            public class CategoryProductsViewModel
            {
                public string Name { get; set; }

                public Guid Id { get; set; }

                public Guid Id_Product { get; set; }

                public DateTime createdAt { get; set; }
             }
            
        }
