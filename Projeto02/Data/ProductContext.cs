using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using APiComEFCore.Model;
using Microsoft.EntityFrameworkCore;

namespace APiComEFCore.Data
{
    public class ProductContext : DbContext
    {
        public ProductContext(DbContextOptions<ProductContext> options) : base(options) {

        }

        public DbSet<TodoItemModel> Product { get; set; };
    }
}