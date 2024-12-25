                using Microsoft.AspNetCore.Mvc;
using School.Domain.Models;
using System;

namespace School.Controllers
{
    public class UserProfileController : Controller
    {
        // Страница отображения профиля
        public IActionResult Index()
        {
            var userProfile = new UserProfile
            {
                Id = 1,
                FirstName = "John",
                LastName = "Doe",
                Email = "john.doe@example.com",
                DateOfBirth = new DateTime(1990, 1, 1),
                Bio = "Software developer and tech enthusiast."
            };

            return View(userProfile);
        }

        // Страница редактирования профиля
        public IActionResult Edit()
        {
            var userProfile = new UserProfile
            {
                Id = 1,
                FirstName = "John",
                LastName = "Doe",
                Email = "john.doe@example.com",
                DateOfBirth = new DateTime(1990, 1, 1),
                Bio = "Software developer and tech enthusiast."
            };

            return View(userProfile);
        }

        [HttpPost]
        public IActionResult Edit(UserProfile model)
        {
            if (ModelState.IsValid)
            {
                // Здесь логика сохранения изменений профиля пользователя.
                return RedirectToAction("Index");
            }

            return View(model);
        }
    }
}
