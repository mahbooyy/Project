using Microsoft.AspNetCore.Mvc;
using School.DAL;
using School.Domain.ModelsDb;
using School.Domain.ViewModels.LoginAndRegistration;
using System;
using System.Linq;
using System.Security.Claims;
using Microsoft.EntityFrameworkCore;


namespace School.Controllers
{
    public class CartController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CartController(ApplicationDbContext context)
        {
            _context = context;
        }

        // Отображение корзины
        public IActionResult Cart()
        {
            var email = User.FindFirst(ClaimTypes.Email)?.Value;

            var userId = _context.userDb.FirstOrDefault(x => x.Email == email).Id;

            if (userId == Guid.Empty)
            {
                return Unauthorized("Пользователь не авторизован.");
            }

            var cart = _context.Carts.SingleOrDefault(c => c.UserId == userId);
            if (cart == null)
            {
                return View(new CartViewModel { Items = new() });
            }

            var cartItems = _context.CartItems
                .Where(c => c.CartId == cart.Id)
                .Select(c => new CartItemViewModel
                {
                    Id = c.Id,
                    ProductId = c.ProductId,
                    ProductName = c.ProductsDb.Name,
                    Quantity = c.Quantity,
                    Price = c.Price
                })
                .ToList();

            var cartViewModel = new CartViewModel
            {
                Id = cart.Id,
                UserId = userId,
                CreatedAt = cart.CreatedAt,
                Items = cartItems
            };

            return View(cartViewModel);
        }

        [HttpPost]
        public IActionResult AddToCart(Guid productId)
        {
            var email = User.FindFirst(ClaimTypes.Email)?.Value;

            var userId = _context.userDb.FirstOrDefault(x => x.Email == email).Id;

            if (userId == Guid.Empty)
            {
                return Unauthorized("Пользователь не авторизован.");
            }

            var cart = _context.Carts.SingleOrDefault(c => c.UserId == userId);
            if (cart == null)
            {
                cart = new CartDb
                {
                    Id = Guid.NewGuid(),
                    UserId = userId,
                    CreatedAt = DateTime.UtcNow
                };
                _context.Carts.Add(cart);
                _context.SaveChanges();
            }

            var cartItem = _context.CartItems.SingleOrDefault(ci => ci.CartId == cart.Id && ci.ProductId == productId);
            if (cartItem == null)
            {
                var product = _context.ProductsDb.Find(productId);
                if (product == null)
                {
                    return NotFound("Товар не найден.");
                }

                cartItem = new CartItemsDb
                {
                    Id = Guid.NewGuid(),
                    CartId = cart.Id,
                    ProductId = product.Id,
                    Quantity = 1,
                    Price = product.Price
                };
                _context.CartItems.Add(cartItem);
            }
            else
            {
                cartItem.Quantity++;
            }

            _context.SaveChanges();
            return RedirectToAction("Cart");
        }

        [HttpPost]
        public IActionResult RemoveFromCart(Guid cartItemId)
        {
            var cartItem = _context.CartItems.Find(cartItemId);
            if (cartItem != null)
            {
                _context.CartItems.Remove(cartItem);
                _context.SaveChanges();
            }

            return RedirectToAction("Cart");
        }

        private Guid GetCurrentUserId()
        {
            var userIdClaim = User.FindFirst("UserId");
            if (userIdClaim == null)
            {
                return Guid.Empty; // Возвращает пустой ID, если claim отсутствует
            }

            return Guid.Parse(userIdClaim.Value);
        }
        [HttpPost]
        public IActionResult UpdateQuantity([FromBody] UpdateQuantityViewModel model)
        {
            if (model == null || model.CartItemId == Guid.Empty || model.Quantity < 1)
            {
                return BadRequest(new { success = false, message = "Некорректные данные." });
            }

            var cartItem = _context.CartItems.FirstOrDefault(ci => ci.Id == model.CartItemId);
            if (cartItem == null)
            {
                return NotFound(new { success = false, message = "Товар в корзине не найден." });
            }

            cartItem.Quantity = model.Quantity;
            _context.SaveChanges();

            return Ok(new { success = true });
        }
        [HttpPost]
        public IActionResult DeleteItem([FromBody] DeleteItemViewModel model)
        {
            if (model == null || model.CartItemId == Guid.Empty)
            {
                return BadRequest(new { success = false, message = "Некорректные данные." });
            }

            var cartItem = _context.CartItems.FirstOrDefault(ci => ci.Id == model.CartItemId);
            if (cartItem == null)
            {
                return NotFound(new { success = false, message = "Товар в корзине не найден." });
            }

            var cartId = cartItem.CartId;

            // Удаление товара из базы данных
            _context.CartItems.Remove(cartItem);
            _context.SaveChanges();

            // Пересчитать общую стоимость корзины
            var totalPrice = _context.CartItems
                .Where(ci => ci.CartId == cartId)
                .Sum(ci => ci.Quantity * ci.Price);

            return Json(new { success = true, totalPrice });
        }


    }
}
