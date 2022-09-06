using AutoMapper;
using CustomerCartMS.Database.DataModels;
using CustomerCartMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerCartMS.MappingsConfig
{
    public class MappingsSetup : Profile
    {
        public MappingsSetup()
        {
            CreateMap<Customer, CustomerModel>();
            CreateMap<CustomerCartItem, CustomerCartItemModel>();
        }
    }
}
