using Microsoft.AspNetCore.Mvc;
using ShoppingApi.Models;
using ShoppingApi.Services.Interface;
using System.Collections.Generic;

namespace ShoppingApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService productService;

        public ProductsController(IProductService productService)
        {
            this.productService = productService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<ProductModel>> Index()
        {
            return Ok(productService.GetProducts());
        }
    }
}
