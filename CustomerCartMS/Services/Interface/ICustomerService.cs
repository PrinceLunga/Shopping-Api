using CustomerCartMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerCartMS.Services.Interface
{
    public interface ICustomerService
    {
        string AddCustomer(CustomerModel model);
        List<CustomerModel> GetCustomers();
        CustomerModel GetCustomerById(int Id);
        string DeleteCustomer(int Id);
        CustomerModel UpdatCustomer(CustomerModel model);
    }
}
