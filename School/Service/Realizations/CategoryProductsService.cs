        using AutoMapper;
        using School.DAL.Interface;
        using School.Domain.Models;
        using School.Domain.ModelsDb;
        using School.Domain.Response;
        using School.Domain.Validators;
        using School.Service.InterFace;
        using System;
        using System.Collections.Generic;
        using System.Linq;

        namespace School.Service.Realizations
        {
            public class CategoryProductsService : ICategoryProductsService
            {
                private readonly IBaseStorage<CategoryDb> _CategoryStorage;
                private IMapper _mapper { get; set; }
                private CategoryValidator _validationRules { get; set; }

                MapperConfiguration mapperConfiguration = new MapperConfiguration(p =>
                {
                    p.AddProfile<AppMappingProfile>();
                });

                public CategoryProductsService(IBaseStorage<CategoryDb> CategoryStorage)
                {
                    _CategoryStorage = CategoryStorage;
                    _mapper = mapperConfiguration.CreateMapper();
                    _validationRules = new CategoryValidator();
                }

                // Реализуем метод GetALLCountries() из интерфейса
                public BaseResponse<List<Category>> GetALLCategoryProducts()
                {
                    try
                    {
                        // Получаем данные из хранилища и сортируем
                        var CategoryDb = _CategoryStorage.GetAll().OrderBy(p => p.CreatedAt).ToList();


                        var result = _mapper.Map<List<Category>>(CategoryDb);
                        // Если ничего не найдено
                        if (result.Count == 0)
                        {
                            return new BaseResponse<List<Category>>()
                            {
                                Description = "Найдено 0 элементов",
                                StatusCode = StatusCode.OK
                            };
                        }

                        // Возвращаем успешный ответ с данными
                        return new BaseResponse<List<Category>>()
                        {
                            Data = result,
                            StatusCode = StatusCode.OK
                        };
                    }
                    catch (Exception ex)
                    {
                        // Обрабатываем исключение и возвращаем ошибку
                        return new BaseResponse<List<Category>>()
                        {
                            Description = ex.Message,
                            StatusCode = StatusCode.InternalServerError
                        };
                    }
                }
            }
        }