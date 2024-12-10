using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using School.Domain.ViewModels.LoginAndRegistration;
using School.Service;
using School.Service.InterFace;
using System;
using System.Collections.Generic;

namespace School.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryProductsService _categoryproductsService;
        private readonly IMapper _mapper;

        public CategoryController(ICategoryProductsService categoryproductsService, IMapper mapper)
        {
            _categoryproductsService = categoryproductsService;
            var mapperConfiguration = new MapperConfiguration(p => p.AddProfile<AppMappingProfile>());
            _mapper = mapperConfiguration.CreateMapper();
        }

        //    public IActionResult CategoryProducts()
        //    {
        //        var result = _categoryproductsService.GetALLCategoryProducts();

        //        if (result == null || result.Data == null || result.Data.Count == 0)
        //        {
        //            ViewData["ErrorMessage"] = "Нет доступных категорий.";
        //            return View(new List<CategoryProductsViewModel>());
        //        }

        //        var categoryproducts = _mapper.Map<List<CategoryProductsViewModel>>(result.Data);
        //        return View(categoryproducts); // передаем список
        //    }
    }
}
