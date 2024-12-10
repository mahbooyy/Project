using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using School.Domain.ViewModels.LoginAndRegistration;
using School.Service;
using School.Service.InterFace;
using Service.InterFace;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace School.Controllers
{
    public class CatalogController : Controller
    {
        private readonly ICatalogSerivce _catalogService;
        private readonly IProductsService _productsService;
        private IMapper _mapper { get; set; }

        private MapperConfiguration mapperConfiguration = new MapperConfiguration(p =>
        {
            p.AddProfile<AppMappingProfile>();
        });

        public CatalogController(ICatalogSerivce catalogService, IProductsService productsService)
        {
            _catalogService = catalogService;
            _productsService = productsService;
            _mapper = mapperConfiguration.CreateMapper();
        }

        public IActionResult Catalog()
        {
            var categories = _catalogService.GetAllCategories();
            var products = _catalogService.GetAllProducts();

            var catalog = new CatalogViewModel
            {
                Categories = _mapper.Map<List<CategoryProductsViewModel>>(categories.Data),
                Products = _mapper.Map<List<ListOfProductsViewModel>>(products.Data),
            };
            return View("Catalog",catalog);
        }

    }
}
