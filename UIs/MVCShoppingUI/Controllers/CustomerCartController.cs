using Microsoft.AspNetCore.Mvc;
using MVCShoppingUI.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace MVCShoppingUI.Controllers
{
    public class CustomerCartController : Controller
    {
        public async Task<IActionResult> Index()
        {
            String Url = "";
            var CustomerCartItems = new List<CustomerCartItemModel>();
            using(var httpClient = new HttpClient())
            {
                using(var response = await httpClient.GetAsync(Url))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    CustomerCartItems = JsonConvert.DeserializeObject<List<CustomerCartItemModel>>(apiResponse);
                }

            }
            return View();
        }

        public ViewResult CustomerCart() => View();

        [HttpPost]
        public async Task<IActionResult> CustomerCart(CustomerCartItemModel model)
        {
            CustomerCartItemModel customerCartItem;

            customerCartItem = new CustomerCartItemModel();
            String Url = "";

            try
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(model),
                    Encoding.UTF8,
                    "application/json");

                using var httpClient = new HttpClient();
                using var response = await httpClient.PostAsync(Url, content);
                string apiResponse = await response.Content.ReadAsStringAsync();
                customerCartItem = JsonConvert.DeserializeObject<CustomerCartItemModel>(apiResponse);
            }
            catch (Exception)
            {
                throw;
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
