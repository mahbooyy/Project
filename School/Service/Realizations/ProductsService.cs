using AutoMapper;
using School.DAL.Interface;
using School.DAL.Storage;
using School.Domain.Models;
using School.Domain.ModelsDb;
using School.Domain.Response;
using School.Service.InterFace;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace School.Service.Realizations
{
    public class ProductsService : IProductsService
    {
        private readonly IBaseStorage<ProductsDb> _productsStorage;
        private readonly IBaseStorage<PictureProductDb> _pictureProductStorage;
        private readonly IMapper _mapper;

        public ProductsService(IBaseStorage<ProductsDb> productsStorage, IBaseStorage<PictureProductDb> pictureProductStorage, IMapper mapper)
        {
            _productsStorage = productsStorage;
            _pictureProductStorage = pictureProductStorage;
            _mapper = mapper;
        }

        public BaseResponse<List<Products>> GetALLProductsByCategory(Guid Id)
        {
            try
            {
                var productsDb = _productsStorage.GetAll().Where(x => x.Id_Category == Id).OrderBy(p => p.CreatedAt).ToList();

                var result = _mapper.Map<List<Products>>(productsDb);
                if (!result.Any())
                {
                    return new BaseResponse<List<Products>>()
                    {
                        Description = "Найдено 0 элементов",
                        StatusCode = StatusCode.OK
                    };
                }

                return new BaseResponse<List<Products>>()
                {
                    Data = result,
                    StatusCode = StatusCode.OK
                };
            }
            catch (Exception ex)
            {
                return new BaseResponse<List<Products>>()
                {
                    Description = ex.Message,
                    StatusCode = StatusCode.InternalServerError
                };
            }
        }

        public BaseResponse<List<Products>> GetProductsByFilter(ProductsFilter filter)
        {
            try
            {
                var allProductsResponse = GetALLProductsByCategory(filter.Id_Category);
                var productFilter = allProductsResponse.Data;

                if (filter != null && productFilter != null)
                {
                    if (filter.PriceMax > 0 || filter.PriceMin > 0)
                    {
                        productFilter = productFilter.Where(f => f.Price >= filter.PriceMin && f.Price <= filter.PriceMax).ToList();
                    }

                    if (!string.IsNullOrEmpty(filter.SortBy))
                    {
                        productFilter = filter.SortBy switch
                        {
                            "Price" => filter.IsAscending
                                ? productFilter.OrderBy(f => f.Price).ToList()
                                : productFilter.OrderByDescending(f => f.Price).ToList(),
                            "Time" => filter.IsAscending
                                ? productFilter.OrderBy(f => f.CreatedAt).ToList()
                                : productFilter.OrderByDescending(f => f.CreatedAt).ToList(),
                            "Name" => filter.IsAscending
                                ? productFilter.OrderBy(f => f.Name).ToList()
                                : productFilter.OrderByDescending(f => f.Name).ToList(),
                            _ => productFilter
                        };
                    }

                    return new BaseResponse<List<Products>>
                    {
                        Data = productFilter,
                        Description = "Отфильтрованные данные",
                        StatusCode = StatusCode.OK
                    };
                }
                else
                {
                    return new BaseResponse<List<Products>>()
                    {
                        Description = "Неверные фильтры или отсутствуют данные для фильтрации",
                        StatusCode = StatusCode.BadRequest
                    };
                }
            }
            catch (Exception ex)
            {
                return new BaseResponse<List<Products>>()
                {
                    Description = ex.Message,
                    StatusCode = StatusCode.InternalServerError
                };
            }
        }

        public async Task<BaseResponse<Products>> GetProductsById(Guid id)
        {
            try
            {
                var productsDb = await _productsStorage.Get(id);

                var result = _mapper.Map<Products>(productsDb);
                if (result == null)
                {
                    return new BaseResponse<Products>()
                    {
                        Description = "Продукт не найден",
                        StatusCode = StatusCode.OK
                    };
                }

                return new BaseResponse<Products>()
                {
                    Data = result,
                    StatusCode = StatusCode.OK
                };
            }
            catch (Exception ex)
            {
                return new BaseResponse<Products>()
                {
                    Description = ex.Message,
                    StatusCode = StatusCode.InternalServerError
                };
            }
        }

        public BaseResponse<List<PictureProduct>> GetPictureProductById(Guid Id)
        {
            try
            {
                var pictureDb = _pictureProductStorage.GetAll().Where(x => x.Id_Product == Id).ToList();

                var result = _mapper.Map<List<PictureProduct>>(pictureDb);
                if (!result.Any())
                {
                    return new BaseResponse<List<PictureProduct>>()
                    {
                        Description = "Найдено 0 элементов",
                        StatusCode = StatusCode.OK
                    };
                }

                return new BaseResponse<List<PictureProduct>>()
                {
                    Data = result,
                    StatusCode = StatusCode.OK
                };
            }
            catch (Exception ex)
            {
                return new BaseResponse<List<PictureProduct>>()
                {
                    Description = ex.Message,
                    StatusCode = StatusCode.InternalServerError
                };
            }
        }

        Task<BaseResponse<List<Products>>> IProductsService.GetALLProductsByCategory(Guid Id)
        {
            throw new NotImplementedException();
        }

        Task<BaseResponse<List<Products>>> IProductsService.GetProductsByFilter(ProductsFilter filter)
        {
            throw new NotImplementedException();
        }

        Task<BaseResponse<Products>> IProductsService.GetProductsById(Guid Id)
        {
            throw new NotImplementedException();
        }

        Task<BaseResponse<List<PictureProduct>>> IProductsService.GetPictureProductById(Guid Id)
        {
            throw new NotImplementedException();
        }
    }
}
