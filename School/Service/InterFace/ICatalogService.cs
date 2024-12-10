using School.Domain.Models;
using School.Domain.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.InterFace
{
    public interface ICatalogSerivce
    {
        BaseResponse<List<Category>> GetAllCategories();

        BaseResponse<List<Products>> GetAllProducts();
    }
}
