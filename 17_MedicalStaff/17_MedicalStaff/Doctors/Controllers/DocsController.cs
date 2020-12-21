using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Doctors.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Doctors.Controllers
{
    public class DocsController : Controller
    {
        private string baseUrl = "http://localhost:5215/api/";

        // GET: DocsController
        public async Task<IActionResult> Index()
        {
            var docs = new List<Doc>();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseUrl);
                var response = await client.GetAsync("physicians");

                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    docs = JsonSerializer.Deserialize<List<Doc>>(json);
                }
            }

            return View(docs);
        }

        // GET: DocsController/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var doc = await GetDocAsync(id);
            return View(doc);
        }

        // GET: DocsController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DocsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Doc doc)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var content = new StringContent(JsonSerializer.Serialize(doc), Encoding.UTF8, "application/json");

                    using (var client = new HttpClient())
                    {
                        client.BaseAddress = new Uri(baseUrl);
                        var response = await client.PostAsync("physicians", content);
                    }
                }

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: DocsController/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var doc = await GetDocAsync(id);
            return View(doc);
        }

        // POST: DocsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Doc doc)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var content = new StringContent(JsonSerializer.Serialize(doc), Encoding.UTF8, "application/json");

                    using (var client = new HttpClient())
                    {
                        client.BaseAddress = new Uri(baseUrl);
                        var response = await client.PutAsync($"physicians/{id}", content);
                    }
                }

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: DocsController/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var doc = await GetDocAsync(id);
            return View(doc);
        }

        // POST: DocsController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id, IFormCollection collection)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(baseUrl);
                    var response = await client.DeleteAsync($"physicians/{id}");
                }

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        private async Task<Doc> GetDocAsync(int id)
        {
            var doc = new Doc();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseUrl);
                var response = await client.GetAsync($"physicians/{id}");

                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    doc = JsonSerializer.Deserialize<Doc>(json);
                }
            }

            return doc;
        }
    }
}
