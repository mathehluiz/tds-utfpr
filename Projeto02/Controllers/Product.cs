using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using APiComEFCore.Data;
using APiComEFCore.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace APiComEFCore.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {

        private readonly ProductContext _context;

        public ProductController(ProductContext context)
        {
            _context = context;
        }

        [HttpGet]
        public  ActionResult<List<ProductModel>> Product() {
            return _context.Products.ToList();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductModel?>> ProductByID(long id) {
            return await _context.Products.Where(i => i.ProductID.Equals(id)).FirstAsync();
        }

        [HttpPost]
        public async Task<ActionResult<ProductModel>> Product(ProductModel Product) {
            _context.Add(Product);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Product", Product);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ProductModel>> Product(long id, ProductModel Product) {
            if (id != Product.ProductID) {
                return BadRequest();
            }

            _context.Entry(Product).State = EntityState.Modified;
            
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ProductModel>> ProductDelete(long id) {
            var Product =await ProductByID(id);
            _context.Remove<ProductModel>(Product.Value!);
            await _context.SaveChangesAsync();

            return Ok();
        }
    }

}