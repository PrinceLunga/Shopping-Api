using AutoMapper;
using ShoppingApi.Database;
using ShoppingApi.Database.DataModel;
using ShoppingApi.Models;
using ShoppingApi.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingApi.Services.Implementation
{
    public class ProductService : IProductService
    {
        private readonly ShoppingDbContext shoppingDbContext;
        private readonly IMapper mapper;

        public ProductService(ShoppingDbContext shoppingDbContext, IMapper mapper)
        {
            this.shoppingDbContext = shoppingDbContext;
            this.mapper = mapper;
        }
        public string AddProduct(ProductModel model)
        {
            using (shoppingDbContext)
            {
                var product = mapper.Map<ProductModel, Product> (model);
                shoppingDbContext.Products.Add(product);
                shoppingDbContext.SaveChanges();
                return "Product successfully added !";
            }
        }

        public string DeleteProduct(int Id)
        {
            throw new NotImplementedException();
        }

        public ProductModel GetProductById(int Id)
        {
            throw new NotImplementedException();
        }

        public List<ProductModel> GetProducts()
        {
            using(shoppingDbContext)
            {
                var GetProducts = shoppingDbContext.Products.ToList();

                var GetProductsModel = mapper.Map<List<Product>, List<ProductModel>>(GetProducts);

                return GetProductsModel;
            }
        }

        public ProductModel UpdateProduct(int Id)
        {
            throw new NotImplementedException();
        }
    }
}
