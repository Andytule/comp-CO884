using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Northwind.Models;

namespace Northwind.Controllers
{
    public class ProductsController : Controller
    {
        private string baseUrl = "http://localhost:54410/api/";

        // GET: ProductsController
        [AllowAnonymous]
        public async Task<IActionResult> Index(int categoryId = 1)
        {
            var categories = await GetCategoryAsync();

            ViewBag.categoryId = new SelectList(categories, "id", "name");

            var products = new List<Product>();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseUrl);
                var response = await client.GetAsync($"products/ByCategory/{categoryId}");

                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    products = JsonSerializer.Deserialize<List<Product>>(json);
                }
            }

            return View(products);
        }

        // GET: ProductsController/Details/5
        [Authorize]
        public async Task<IActionResult> Details(int id)
        {
            var product = await GetProductAsync(id);
            if (product == null)
            {
                return View("Error", new ErrorViewModel
                {
                    RequestId = $"Product Id {id} not found"
                });
            }
            else
            {
                var categories = await GetCategoryAsync();

                var temp = from a in categories
                            .Where(a => a.id == product.categoryId)
                           select a.name;

                ViewBag.Name = temp.FirstOrDefault();
                return View(product);
            }
            
            
        }

        private async Task<Product> GetProductAsync(int id)
        {
            var product = new Product();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseUrl);
                var response = await client.GetAsync($"products/{id}");

                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    product = JsonSerializer.Deserialize<Product>(json);
                } 
                else
                {
                    product = null; 
                }
            }

            return product;
        }

        private async Task<List<Category>> GetCategoryAsync()
        {
            var categories = new List<Category>();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseUrl);
                var response = await client.GetAsync("categories");

                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    categories = JsonSerializer.Deserialize<List<Category>>(json);
                } 
            }

            return categories;
        }
        
    }
}
