﻿using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using School.Domain.ViewModels.LoginAndRegistration;
using Microsoft.Extensions.Logging;
using School.Domain.Models;
using AutoMapper;
using School.Service;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using System.Security.Claims;
using System.Diagnostics;
using System;
using System.Net.Http;
using System.IO;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.AspNetCore.Hosting;
using School.Service.InterFace;

namespace School.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IWebHostEnvironment _appEnviroment;
        private readonly IAccountService _accountService;
        private readonly IMapper _mapper;

        public HomeController(ILogger<HomeController> logger, IAccountService accountService, IWebHostEnvironment appEnviroment)
        {
            _accountService = accountService;
            _logger = logger;
            _appEnviroment = appEnviroment;
            var mapperConfiguration = new MapperConfiguration(p => p.AddProfile<AppMappingProfile>());
            _mapper = mapperConfiguration.CreateMapper();
        }

        public IActionResult SiteInformation()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult ContactsInformation()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            var errorModel = new ErrorViewModel
            {
                RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier,
                Message = "Произошла ошибка",
                ShowRequestId = true // Если нужно, установите ShowRequestId
            };

            // Убедитесь, что ViewData["Title"] устанавливается
            ViewData["Title"] = "Error";
            return View(errorModel);
        }


        [HttpPost]
        public async Task<IActionResult> Login([FromBody] LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = _mapper.Map<User>(model);
                var response = await _accountService.Login(user);

                if (response.StatusCode == Domain.Response.StatusCode.OK)
                {
                    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                        new ClaimsPrincipal(response.Data));
                    return Ok(model);
                }

                ModelState.AddModelError("", response.Description);
            }

            var errors = ModelState.Values.SelectMany(v => v.Errors)
                .Select(e => e.ErrorMessage)
                .ToList();

            return BadRequest(errors);
        }

        [HttpPost]
        public async Task<IActionResult> Register([FromBody] RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = _mapper.Map<User>(model);
                var confirm = _mapper.Map<ConfirmEmailViewModel>(model);
                var code = await _accountService.Register(user);
                confirm.GeneratedCode = code.Data;
                return Ok(confirm);  // Возвращаем ConfirmEmailViewModel с сгенерированным кодом
            }

            var errors = ModelState.Values.SelectMany(v => v.Errors)
                .Select(e => e.ErrorMessage)
                .ToList();

            return BadRequest(errors);
        }

        [HttpPost]
        public async Task<IActionResult> ConfirmEmail([FromBody] ConfirmEmailViewModel confirmEmailModel)
        {
            var user = _mapper.Map<User>(confirmEmailModel);
            var response = await _accountService.ConfirmEmail(user, confirmEmailModel.GeneratedCode, confirmEmailModel.CodeConfirm);

            if (response.StatusCode == Domain.Response.StatusCode.OK)
            {
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                new ClaimsPrincipal(response.Data));

                return Ok(confirmEmailModel);  // Подтверждаем модель
            }

            ModelState.AddModelError("", response.Description);

            var errors = ModelState.Values.SelectMany(v => v.Errors)
                .Select(e => e.ErrorMessage)
                .ToList();

            return BadRequest(errors);
        }

        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("SiteInformation", "Home");  // Перенаправление после выхода
        }

        public async Task AuthenticationGoogle(string returnUrl = "/")
        {
            await HttpContext.ChallengeAsync(GoogleDefaults.AuthenticationScheme,
                new AuthenticationProperties
                {
                    RedirectUri = Url.Action("GoogleResponse", new { returnUrl }),
                    Parameters = { { "prompt", "select_account" } }
                });
        }

        public async Task<IActionResult> GoogleResponse(string returnUrl = "/")
        {
            try
            {
                var result = await HttpContext.AuthenticateAsync(CookieAuthenticationDefaults.AuthenticationScheme);

                if (result?.Succeeded == true)
                {
                    User model = new User
                    {
                        Login = result.Principal.FindFirst(ClaimTypes.Name)?.Value,
                        Email = result.Principal.FindFirst(ClaimTypes.Email)?.Value,
                        PathImage = "/" + SaveImageInImageUser(result.Principal.FindFirst("picture")?.Value, result).Result ?? "/css/Images/ETIL_BROTHER2.png"
                    };

                    var response = await _accountService.IsCreatedAccount(model);
                    if (response.StatusCode == Domain.Response.StatusCode.OK)
                    {
                        await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,    
                            new ClaimsPrincipal(response.Data));
                        return Redirect(returnUrl);
                    }
                }

                return BadRequest("Аутентификация не удалась.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        private async Task<string> SaveImageInImageUser(string imageUrl, AuthenticateResult result)
        {
            string filePath = "";
            if (!string.IsNullOrEmpty(imageUrl))
            {
                //using (var httpClient = new HttpClient())
                //{
                //    filePath = Path.Combine("Images/avatars", $"{result.Principal.FindFirst(ClaimTypes.Email)?.Value}-avatar.jpg");

                //    var imageBytes = await httpClient.GetByteArrayAsync(imageUrl);

                //    await System.IO.File.WriteAllBytesAsync(Path.Combine(_appEnviroment.WebRootPath, filePath), imageBytes);
                //}
            }
            return filePath;
        }
        public IActionResult Profile()
        {
            // Здесь можно передать информацию о профиле пользователя
            return View();
        }

        public IActionResult Cart()
        {
            // Логика отображения корзины
            return View();
        }

        public IActionResult Archive()
        {
            // Логика отображения архива
            return View();
        }
    }
}
