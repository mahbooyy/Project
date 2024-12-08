using Microsoft.EntityFrameworkCore;
using School.DAL.Interface;
using School.Domain.ModelsDb;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.DAL.Storage
{
    public class ProductsStorage : IBaseStorage<ProductsDb>
    {
        public readonly ApplicationDbContext _db;

        public ProductsStorage(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task Add(ProductsDb item)
        {
            await _db.AddAsync(item);
            await _db.SaveChangesAsync();
        }

        public async Task Delete(ProductsDb item)
        {
            _db.Remove(item);
            await _db.SaveChangesAsync();
        }

        public async Task<ProductsDb> Get(Guid id)
        {
            return await _db.ProductsDb.FirstOrDefaultAsync(x => x.Id == id);
        }

        public IQueryable<ProductsDb> GetAll()
        {
            return _db.ProductsDb;
        }

        public async Task<ProductsDb> Update(ProductsDb item)
        {
            _db.ProductsDb.Update(item);
            await _db.SaveChangesAsync();

            return item;

        }
    }
}
