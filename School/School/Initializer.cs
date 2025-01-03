﻿using Microsoft.Extensions.DependencyInjection;
using School.DAL.Interface;
using School.DAL.Storage;
using School.Domain.ModelsDb;
using School.Service.InterFace;
using School.Service.Realizations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Service.InterFace;
using Service.Realizations;

namespace School
{
    public static class Initializer
    {
        public static void InitializeRepositories(this IServiceCollection services)
        {
            services.AddScoped<IBaseStorage<UserDb>, UserStorage>();
            services.AddScoped<IBaseStorage<CategoryDb>, CategoryStorage>();
            services.AddScoped<IBaseStorage<ProductsDb>, ProductsStorage>();
            services.AddScoped<IBaseStorage<PictureProductDb>, PictureProductStorage>();



        }

        public static void InitializeServices(this IServiceCollection services)
        {
            services.AddScoped<IAccountService, AccountService>();
            services.AddScoped<ICategoryProductsService, CategoryProductsService>();
            services.AddScoped<IProductsService, ProductsService>();
            services.AddControllersWithViews()
                    .AddDataAnnotationsLocalization()
                    .AddViewLocalization();
            services.AddScoped<ICatalogSerivce, CatalogService>();
        }
    }

}
