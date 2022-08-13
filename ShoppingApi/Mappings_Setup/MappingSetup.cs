using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ShoppingApi.Database.DataModel;
using ShoppingApi.Models;

namespace ShoppingApi.Mappings_Setup
{
    public class MappingSetup : Profile
    {
        public MappingSetup()
        {
            CreateMap<Product, ProductModel>();
        }
    }
}
