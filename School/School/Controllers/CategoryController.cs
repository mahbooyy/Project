using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using School.Domain.ViewModels.LoginAndRegistration;
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
            _mapper = mapper;
        }

        public IActionResult CategoryProducts()
        {
            // Получаем данные о категориях из сервиса
            var result = _categoryproductsService.GetALLCategoryProducts();

            if (result == null || result.Data == null || result.Data.Count == 0)
            {
                // Если нет категорий, показываем сообщение
                ViewData["ErrorMessage"] = "Нет доступных категорий.";
                return View(new List<CategoryProductsViewModel>());
            }

            // Маппим данные из результата в модель представления
            var categoryproducts = _mapper.Map<List<CategoryProductsViewModel>>(result.Data);

            return View(categoryproducts);
        }
    }
}
