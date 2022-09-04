using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShoppingApi.Models;
using ShoppingApi.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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

        [HttpPost]
        [AcceptVerbs("POST")]
        public ActionResult AddProduct([FromForm] ProductModel model)
        {
            if (model != null)
            {
                return Ok(productService.AddProduct(model));
            }
            else
            {
                return NotFound();
            }


        }
        [HttpGet]
        public ActionResult<IEnumerable<ProductModel>> GetProducts()
        {
            return Ok(productService.GetProducts());
        }

        [HttpGet("{id}")]
        public ActionResult<IEnumerable<ProductModel>> GetProducts(int id)
        {
            if (id >= 1)
            {
                return Ok(productService.GetProductById(id));
            }
            else
            {
                return NotFound();
            }
           
        }

        [HttpPut("{id}")]
        public ActionResult<IEnumerable<ProductModel>> UpdateProducts(int id)
        {
            if (id >= 1)
            {
                var Product = productService.GetProductById(id);

                if(Product == null)
                {
                    return NotFound();
                }
                else
                {
                    return Ok(productService.UpdateProduct(Product));
                }
            }
            else
            {
                return NotFound();
            }

        }

        [HttpDelete("{id}")]
        public ActionResult DeleteProduct(int id)
        {
            if(id > 0)
            {
               return Ok(productService.DeleteProduct(id));
            }
            else
            {
                return NotFound();
            }
           
        }
    }
}
