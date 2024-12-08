using AutoMapper.Configuration;
using Microsoft.EntityFrameworkCore;
using School.Domain.ModelsDb;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.DAL
{
    public class ApplicationDbContext : DbContext
    {
        protected readonly IConfiguration Configuration;

        public DbSet<UserDb> userDb { get; set; }

        public DbSet<CategoryDb> CategoryDb { get; set; }

        public DbSet<OrdersDb> OrdersDb { get; set; }

        public DbSet<PictureProductDb> PictureProductDb { get; set; }

        public DbSet<ProductsDb> ProductsDb { get; set; }

        public DbSet<RequestDb> RequestDb { get; set; }



        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }


    }
}
