using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerCartMS.Models
{
    public class CustomerModel
    {
        [Key]
        public int CustomerId { get; set; }
        public string Fullnames { get; set; }
        public string EmailAddress { get; set; }
        public string ContactNumber { get; set; }
        public string HomeAddress { get; set; }
        public DateTime DOB { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }
        public DateTime DateDeleted { get; set; }
    }
}
