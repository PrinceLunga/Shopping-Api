﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MVCShoppingUI.Models
{
    public class ProductsModel
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public byte[] Images { get; set; }
        public string Brand { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public int Quantity { get; set; }
        public string Size { get; set; }
        public bool IsInStock { get; set; }
        public double Price { get; set; }
    }
}
