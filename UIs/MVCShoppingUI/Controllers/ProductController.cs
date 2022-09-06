using Microsoft.AspNetCore.Mvc;
using MVCShoppingUI.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace MVCShoppingUI.Controllers
{
    public class ProductController : Controller
    {
        public async Task<IActionResult> Index()
        {
            string Url = "https://localhost:44314/api/Products/GetProducts";
            var ProductList = new List<ProductsModel>();
            using var httpClient = new HttpClient();

            ViewBag.CartItems = "1";

            try
            {
                using var response = await httpClient.GetAsync(Url);
                string apiResponse = await response.Content.ReadAsStringAsync();
                ProductList = JsonConvert.DeserializeObject<List<ProductsModel>>(apiResponse);
            }
            catch (Exception ex)
            {

                throw ex.InnerException;
            }
            return View(ProductList);
        }

        public ViewResult GetProductById() => View();

        [HttpPost]
        public async Task<IActionResult> GetProductById(int id)
        {
            var Product = new ProductModel();
            string Url = "https://localhost:44314/api/Products/GetProducts/";
            using var httpClient = new HttpClient();

            try
            {
                using var response = await httpClient.GetAsync(Url + id);
                string apiResponse = await response.Content.ReadAsStringAsync();
                Product = JsonConvert.DeserializeObject<ProductModel>(apiResponse);

            }
            catch (Exception ex)
            {

                throw ex.InnerException;
            }

            return View(Product);
        }

        public async Task<IActionResult> AddProduct()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddProduct([FromForm] ProductModel product)
        {
            string Url = "https://localhost:44314/api/Products/AddProduct";
            using var httpClient = new HttpClient();

            var response = await httpClient.PostAsync(Url, ConvertProduct(product).GetAwaiter().GetResult());
            var data = await response.Content.ReadAsStringAsync();
            response.EnsureSuccessStatusCode();

            return RedirectToAction(nameof(Index));
        }



        public async Task<MultipartFormDataContent> ConvertProduct(ProductModel product)
        {
            using var memoryStream = new MemoryStream();

            await product.Images.CopyToAsync(memoryStream);
            var imageBytes = memoryStream.ToArray();
            var response = new HttpResponseMessage();

            var formDataContent = new MultipartFormDataContent
            {
                { new StringContent(product.Name), "name" },
                { new StringContent(Convert.ToBase64String(imageBytes)), "images" },
                { new StringContent(product.Brand), "brand" },
                { new StringContent(product.Description), "description" },
                { new StringContent(product.Category), "category" },
                { new StringContent(product.Size), "Size" },
                { new StringContent(product.Quantity.ToString()), "Quantity" },
                { new StringContent(product.IsInStock.ToString()), "IsInStock" },
                { new StringContent(product.Price.ToString()), "price" }
            };

            return formDataContent;
        }

        [HttpPost]
        public IActionResult UpdateProduct([FromForm] ProductModel product)
        {
            String Url = "https://localhost:44314/api/Products/UpdateProduct";
            using var httpClient = new HttpClient();
            string serailizedProduct = JsonConvert.SerializeObject(product);

            var inputMessage = new HttpRequestMessage
            {
                Content = new StringContent(serailizedProduct, Encoding.UTF8, "application/json")
            };

            inputMessage.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage message = httpClient.PutAsync(Url,
                                          inputMessage.Content).Result;

            if (!message.IsSuccessStatusCode)
                throw new ArgumentException(message.ToString());

            return RedirectToAction("Index");
        }
    }
}
