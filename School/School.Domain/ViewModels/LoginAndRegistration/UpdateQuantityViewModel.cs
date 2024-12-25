using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Domain.ViewModels.LoginAndRegistration
{
    public class UpdateQuantityViewModel
    {
        public Guid CartItemId { get; set; }
        public int Quantity { get; set; }


    }
}
