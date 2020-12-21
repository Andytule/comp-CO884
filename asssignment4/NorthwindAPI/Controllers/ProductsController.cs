using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NorthwindAPI.Models;

namespace NorthwindAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly northwindContext _context;

        public ProductsController(northwindContext context)
        {
            _context = context;
        }

        // GET: api/Products
        [HttpGet("ByCategory/{category}")]
        public async Task<ActionResult<IEnumerable<Product>>> GetProducts(int category)
        {
            var products = await _context.Products.Where(p => p.CategoryId == category && p.Discontinued == false).ToListAsync();
                           
            return products;
        }

        // GET: api/Products/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProduct(int id)
        {
            var product = await _context.Products.FindAsync(id);

            if (product == null)
            {
                return NotFound();
            }

            return product;
        }


        private bool ProductExists(int id)
        {
            return _context.Products.Any(e => e.ProductId == id);
        }
    }
}
