using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ITowerCafe.Models
{
    public class OrderViewModel
    {
        public int Id { get; set; }
        [Display (Name = "Company Name")]
        public string CompanyName { get; set; }
        public Decimal Cost { get; set; }
        [Display (Name = "Order Date")]
        public DateTime OrderDate { get; set; }
        public DateTime Status { get; set; }
    }
}