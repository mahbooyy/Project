using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Domain.ViewModels.LoginAndRegistration
{
    public class ArchivedItemViewModel
    {
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public DateTime ArchivedDate { get; set; }
    }

}
