using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Domain.ViewModels.LoginAndRegistration
{
    public class CartViewModel
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public DateTime CreatedAt { get; set; }
        public List<CartItemViewModel> Items { get; set; } = new List<CartItemViewModel>();
    }

}
