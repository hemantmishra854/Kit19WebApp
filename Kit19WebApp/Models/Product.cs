using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Kit19WebApp.Models
{
    public class Product
    {
        public int ProductId { get; set; }
        //[Required]
        public string ProductName { get; set; }
        //[Required]
        public string Size { get; set; }
        //[Required]
        public int? Price { get; set; }
        //[Required]
        public DateTime? MfgDate { get; set; }
        //[Required]
        public string Category { get; set; }
}
}