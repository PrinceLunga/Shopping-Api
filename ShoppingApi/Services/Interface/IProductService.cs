using ShoppingApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingApi.Services.Interface
{
    public interface IProductService
    {
        string AddProduct(ProductModel model);
        List<ProductModel> GetProducts();
        ProductModel GetProductById(int Id);
        string DeleteProduct(int Id);
        ProductModel UpdateProduct(int Id);
    }
}
