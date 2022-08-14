using ShoppingApi.Database;
using ShoppingApi.Models;
using ShoppingApi.Services.Interface;
using System.Collections.Generic;
using ShoppingApi.Database.DataModel;
using System.Linq;

namespace ShoppingApi.Services.Implementation
{
    public class ProductService : IProductService
    {
        private readonly ShoppingDbContext shoppingDbContext;

        public ProductService(ShoppingDbContext shoppingDbContext)
        {
            this.shoppingDbContext = shoppingDbContext;
        }
        
        //To save the product record on the db
        public string AddProduct(ProductModel model)
        {
            try
            {
                using (shoppingDbContext)
                {
                    var Product = new Product
                    {
                        Id = model.Id,
                        Brand = model.Brand,
                        Category = model.Category,
                        Description = model.Description,
                        Images = model.Images,
                        IsInStock = model.IsInStock,
                        Name = model.Name,
                        Price = model.Price,
                        Quantity = model.Quantity,
                        Size = model.Size
                    };

                    shoppingDbContext.Products.Add(Product);
                    shoppingDbContext.SaveChanges();

                    return "Product successfully added !";
                }
            }
            catch (System.Exception ex)
            {

                return ex.InnerException.ToString();
            }
           
        }

        public string DeleteProduct(int Id)
        {
            try
            {
                using (shoppingDbContext)
                {
                    var Product = shoppingDbContext.Products.Find(Id);

                    shoppingDbContext.Products.Remove(Product);
                    shoppingDbContext.SaveChanges();

                    return "Product successfully Removed !";
                }
            }
            catch (System.Exception ex)
            {

                return ex.InnerException.ToString();
            }
        }

        public ProductModel GetProductById(int Id)
        {
            try
            {
                using (shoppingDbContext)
                {
                    var Product = shoppingDbContext.Products.Where(p => p.Id == Id).Select(x => new ProductModel
                    {
                        Id = x.Id,
                        Brand = x.Brand,
                        Category = x.Category,
                        Description = x.Description,
                        Images = x.Images,
                        IsInStock = x.IsInStock,
                        Name = x.Name,
                        Price = x.Price,
                        Quantity = x.Quantity,
                        Size = x.Size
                    }).SingleOrDefault();

                    return Product;
                }
            }
            catch (System.Exception ex)
            {
                throw ex.InnerException;
            }
        }

        public List<ProductModel> GetProducts()
        {
            try
            {
                using (shoppingDbContext)
                {
                    var Product = shoppingDbContext.Products.Select(x => new ProductModel
                    {
                        Id = x.Id,
                        Brand = x.Brand,
                        Category = x.Category,
                        Description = x.Description,
                        Images = x.Images,
                        IsInStock = x.IsInStock,
                        Name = x.Name,
                        Price = x.Price,
                        Quantity = x.Quantity,
                        Size = x.Size
                    }).ToList();

                    return Product;
                }
            }
            catch (System.Exception ex)
            {
                throw ex.InnerException;
            }
        }

        public ProductModel UpdateProduct(ProductModel model)
        {
            try
            {
                using (shoppingDbContext)
                {
                    var Product = shoppingDbContext.Products.Find(model.Id);

                    Product.Images = model.Images;
                    Product.Name = model.Name;
                    Product.Price = model.Price;
                    Product.Quantity = model.Quantity;
                    Product.Size = model.Size;
                    Product.Brand = model.Brand;
                    Product.Category = model.Category;
                    Product.Description = model.Description;
                    Product.IsInStock = model.IsInStock;

                    shoppingDbContext.Products.Update(Product);
                    shoppingDbContext.SaveChanges();

                    return model;
                }
            }
            catch (System.Exception ex)
            {

                throw ex.InnerException;
            }
        }
    }
}
