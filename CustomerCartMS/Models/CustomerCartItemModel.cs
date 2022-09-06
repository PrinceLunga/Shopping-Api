﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerCartMS.Models
{
    public class CustomerCartItemModel
    {
        [Key]
        public int CartId { get; set; }
        public int Quantity { get; set; }
        public int ProductId { get; set; }
        public string Status { get; set; }
        public Double Price { get; set; }
        public int CustomerId { get; set; }
    }
}
