using Microsoft.AspNetCore.Mvc;
using MyWebApp.Models;
using System.Net.Http.Headers;
using System.Reflection.Metadata.Ecma335;
using System.Text.Json;

namespace MyWebApp.Controllers;

public class ProductManagerController : Controller
{
    private readonly HttpClient client = null;
    private string ProductApiUrl = "";
    public ProductManagerController()
    {
        client = new HttpClient();
        var contentType = new MediaTypeWithQualityHeaderValue("application/json");
        ProductApiUrl = "http://localhost:5269/api/products";
    }

    //Show all products
    public async Task<IActionResult> Index()
    {
        HttpResponseMessage response = await client.GetAsync(ProductApiUrl);
        string stringData = await response.Content.ReadAsStringAsync();
        var options = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true,
        };
        List<Product>? listProduct = JsonSerializer.Deserialize<List<Product>>(stringData,options);
        return View(listProduct);
    }//end Index

    public ActionResult Create()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(Product product)
    {
        if (ModelState.IsValid)
        {
            string stringData = JsonSerializer.Serialize(product);
            var contentData = new StringContent(stringData, System.Text.Encoding.UTF8, "application/json");
            HttpResponseMessage response = await client.PostAsync(ProductApiUrl, contentData);
            if (response.IsSuccessStatusCode)
            {
                ViewBag.Message = "Product inserted successfully!";
            }
            else
            {
                ViewBag.Message = "Error while calling Web API!";
            }
        }
        return View(product);
    }//end Create

    public async Task<IActionResult> Delete(int? id)
    {
        HttpResponseMessage response = await client.DeleteAsync($"{ProductApiUrl}/{id}");
        if (response.IsSuccessStatusCode)
        {
            TempData["Message"] = "Product deleted successfully!";
        }
        else
        {
            TempData["Message"] = "Error while calling Web API";
        }
        return RedirectToAction(nameof(Index));
    }//end Delete
}//end Class
