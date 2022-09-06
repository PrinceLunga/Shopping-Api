using CustomerCartMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerCartMS.Services.Interface
{
    public interface ICustomerCartService
    {
        string AddToCustomerCart(CustomerCartItemModel model);
        List<CustomerCartItemModel> GetCustomerCartItems();
        CustomerCartItemModel GetCustomerCartItemById(int Id);
        string DeleteCustomerCartItem(int Id);
        CustomerCartItemModel UpdatCustomerCustomerCartItem(CustomerCartItemModel model);
        string Checkout(int CustomerId);
    }
}
