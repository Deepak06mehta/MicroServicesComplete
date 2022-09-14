using System;
using Mango.Services.ProductAPI.Models;
using Microsoft.EntityFrameworkCore;
namespace Mango.Services.ProductAPI.DBContexts
{
    public class ApplicationDBContext: DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options): base(options)
        {
        }

        public DbSet<Product> products { get; set; }
    }
}

