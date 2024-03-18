using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace APiComEFCore.Model
{
    public class ProductModel
    {
        [Key]
        public long ProductID { get; set; }
        public string? Name { get; set; }
        public decimal Price { get; set; }
        public long    Quantity { get; set; }
    }
}