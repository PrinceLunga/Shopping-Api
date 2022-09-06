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
    public class CustomerServices : ICustomerService
    {
        private readonly CustomerCartDbContext customerCartDbContext;
        private readonly IMapper mapper;

        public CustomerServices(CustomerCartDbContext customerCartDbContext, IMapper mapper)
        {
            this.customerCartDbContext = customerCartDbContext;
            this.mapper = mapper;
        }


        public string AddCustomer(CustomerModel model)
        {
            using (customerCartDbContext)
            {
                var customer = mapper.Map<CustomerModel, Customer>(model);

                try
                {
                    customerCartDbContext.Customers.Add(customer);
                    customerCartDbContext.SaveChanges();

                    return "Customer added successfully !";
                }
                catch (Exception ex)
                {

                    throw ex.InnerException;
                }
            }
        }

        public string DeleteCustomer(int Id)
        {
            throw new NotImplementedException();
        }

        public CustomerModel GetCustomerById(int Id)
        {
            using (customerCartDbContext)
            {
                var GetCustomer = customerCartDbContext.Customers.Single();
                var customerList = mapper.Map<Customer, CustomerModel>(GetCustomer);
                return customerList;
            }
        }
        public List<CustomerModel> GetCustomers()
        {
            using(customerCartDbContext)
            {
                var GetCustomers = customerCartDbContext.Customers.ToList();
                var customerList = mapper.Map<List<Customer>, List<CustomerModel>>(GetCustomers);

                return customerList;
            }
        }

        public CustomerModel UpdatCustomer(CustomerModel model)
        {
            using (customerCartDbContext)
            {
                var customer = mapper.Map<CustomerModel, Customer>(model);

                customerCartDbContext.Customers.Update(customer);
                return model;
            }
        }
    }
}
