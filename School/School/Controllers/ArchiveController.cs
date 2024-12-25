using Microsoft.AspNetCore.Mvc;
using School.Domain.ViewModels.LoginAndRegistration;
using System;
using System.Collections.Generic;
using System.Linq;

namespace School.Controllers
{

    public class ArchiveController : Controller
    {
        // Список для хранения временных архивированных данных
        private static List<ArchivedItemViewModel> _archivedItems = new List<ArchivedItemViewModel>();

        // Страница архива
        public IActionResult Archive()
        {
            return View(_archivedItems);
        }

        // Метод для добавления товара в архив
        [HttpPost]
        public IActionResult AddToArchive(int productId, string productName, decimal price, int quantity)
        {
            // Проверка валидности данных
            if (string.IsNullOrEmpty(productName) || price <= 0 || quantity <= 0)
            {
                return Json(new { success = false, message = "Ошибка: Неверные данные товара." });
            }

            // Здесь, например, добавьте товар в архивный список или в базу данных
            var archivedItem = new ArchivedItemViewModel
            {
                ProductName = productName,
                Price = price,
                Quantity = quantity,
                ArchivedDate = DateTime.Now
            };

            // Добавление в архив (здесь просто в память, замените на базу данных, если нужно)
            _archivedItems.Add(archivedItem);

            return Json(new { success = true, message = "Товар добавлен в архив." });
        }



        // Метод для удаления товара из архива
        [HttpPost]
        public IActionResult RemoveFromArchive(string productName)
        {
            var itemToRemove = _archivedItems.FirstOrDefault(ai => ai.ProductName == productName);
            if (itemToRemove != null)
            {
                _archivedItems.Remove(itemToRemove);
                return Json(new { success = true, message = "Товар удалён из архива." });
            }

            return Json(new { success = false, message = "Товар не найден в архиве." });
        }
    }
}