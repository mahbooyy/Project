using AutoMapper;
using School.DAL.Interface;
using School.Domain.Models;
using School.Domain.ModelsDb;
using School.Domain.Response;
using School.Domain.Validators;
using School.Service;
using Service.InterFace;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Realizations
{
    public class CatalogService : ICatalogSerivce
    {
        private readonly IBaseStorage<CategoryDb> _categoryStorage;

        private IMapper _mapper { get; set; }
        private CategoryValidator _categoryValidator { get; set; }

        private MapperConfiguration mapperConfiguration = new MapperConfiguration(p =>
        {
            p.AddProfile<AppMappingProfile>();
        });

        private readonly IBaseStorage<ProductsDb> _productsStorage;
        private ProductsValidator _productValidator { get; set; }
        public CatalogService(IBaseStorage<CategoryDb> categoryStorage, IBaseStorage<ProductsDb> productsStorage)
        {
            _categoryStorage = categoryStorage;
            _productsStorage = productsStorage;
            _categoryValidator = new CategoryValidator();
            _productValidator = new ProductsValidator();
            _mapper = mapperConfiguration.CreateMapper();
        }

        public BaseResponse<List<Category>> GetAllCategories()
        {
            try
            {
                var categoriesDb = _categoryStorage.GetAll().ToList();
                var result = _mapper.Map<List<Category>>(categoriesDb);
                if (result.Count == 0)
                {
                    return new BaseResponse<List<Category>>()
                    {
                        Description = "Найдено 0 элементов",
                        StatusCode = School.Domain.Response.StatusCode.OK
                    };
                }
                return new BaseResponse<List<Category>>()
                {
                    Data = result,
                    StatusCode = School.Domain.Response.StatusCode.OK
                };
            }
            catch (Exception e)
            {
                return new BaseResponse<List<Category>>()
                {
                    Description = e.Message,
                    StatusCode = StatusCode.InternalServerError
                };
            }
        }

        public BaseResponse<List<Products>> GetAllProducts()
        {
            try
            {
                var productDb = _productsStorage.GetAll().ToList();
                var result = _mapper.Map<List<Products>>(productDb);
                if (result.Count == 0)
                {
                    return new BaseResponse<List<Products>>()
                    {
                        Description = "Найдено 0 элементов",
                        StatusCode = School.Domain.Response.StatusCode.OK
                    };
                }
                return new BaseResponse<List<Products>>()
                {
                    Data = result,
                    StatusCode = School.Domain.Response.StatusCode.OK
                };
            }
            catch (Exception e)
            {
                return new BaseResponse<List<Products>>()
                {
                    Description = e.Message,
                    StatusCode = StatusCode.InternalServerError
                };
            }
        }
    }
}
