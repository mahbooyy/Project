using School.Domain.Models;
using School.Domain.Response;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace School.Service.InterFace
{
    public interface IProductsService
    {
        Task<BaseResponse<List<Products>>> GetALLProductsByCategory(Guid Id);

        Task<BaseResponse<List<Products>>> GetProductsByFilter(ProductsFilter filter);

        Task<BaseResponse<Products>> GetProductsById(Guid Id);

        Task<BaseResponse<List<PictureProduct>>> GetPictureProductById(Guid Id);
    }
}
