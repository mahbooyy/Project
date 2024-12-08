using School.Domain.ModelsDb;
using School.Domain.Response;
using System.Collections.Generic;


namespace School.Service.InterFace
{
    public interface ICategoryProductsService
    {
        BaseResponse<List<CategoryDb>> GetALLCategoryProducts();
    }
}
