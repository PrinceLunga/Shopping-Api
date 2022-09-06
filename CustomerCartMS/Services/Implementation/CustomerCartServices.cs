using AutoMapper;
using CustomerCartMS.Database;
using CustomerCartMS.Database.DataModels;
using CustomerCartMS.Models;
using CustomerCartMS.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerCartMS.Services.Implementation
{
    public class CustomerCartServices : ICustomerCartService
    {
        private readonly CustomerCartDbContext customerCartDbContext;
        private readonly IMapper mapper;

        public CustomerCartServices(CustomerCartDbContext customerCartDbContext, IMapper mapper)
        {
            this.customerCartDbContext = customerCartDbContext;
            this.mapper = mapper;
        }
        public string AddToCustomerCart(CustomerCartItemModel model)
        {
            using (customerCartDbContext)
            {
                var customerCartItem = mapper.Map<CustomerCartItemModel, CustomerCartItem>(model);

                try
                {
                    customerCartDbContext.CustomerCartItems.Add(customerCartItem);
                    customerCartDbContext.SaveChanges();

                    return "Customer added successfully !";
                }
                catch (Exception ex)
                {

                    throw ex.InnerException;
                }
            }
        }

        public string Checkout(int CustomerId)
        {
            using (customerCartDbContext)
            {
                var GetCustomerCartItem = customerCartDbContext.CustomerCartItems.Where(c => c.CustomerId == CustomerId).Single();
                var customerCartItem = mapper.Map<CustomerCartItem, CustomerCartItemModel>(GetCustomerCartItem);

                customerCartDbContext.SaveChanges();
                return "Successfully Checkout";
            }
        }

        public string DeleteCustomerCartItem(int Id)
        {
            throw new NotImplementedException();
        }

        public CustomerCartItemModel GetCustomerCartItemById(int Id)
        {
            using (customerCartDbContext)
            {
                var GetCustomerCartItem = customerCartDbContext.CustomerCartItems.Where( c => c.CustomerId == Id).Single();
                var customerCartItem = mapper.Map<CustomerCartItem, CustomerCartItemModel>(GetCustomerCartItem);
                return customerCartItem;
            }
        }

        public List<CustomerCartItemModel> GetCustomerCartItems()
        {
            using (customerCartDbContext)
            {
                var GetCustomerCartItems = customerCartDbContext.CustomerCartItems.ToList();
                var allCustomerCartItems = mapper.Map<List<CustomerCartItem>, List<CustomerCartItemModel>>(GetCustomerCartItems);

                return allCustomerCartItems;
            }
        }

        public CustomerCartItemModel UpdatCustomerCustomerCartItem(CustomerCartItemModel model)
        {
            using (customerCartDbContext)
            {
                var customerCartItem = mapper.Map<CustomerCartItemModel, CustomerCartItem>(model);

                customerCartDbContext.CustomerCartItems.Update(customerCartItem);
                return model;
            }
        }
    }
}
