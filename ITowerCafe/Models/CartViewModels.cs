using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ITowerCafe.Models
{
    public class CardViewModel
    {
        public string CardNumber { get; set; }
        public DateTime ExpirationDate { get; set; }
        public Decimal Money { get; set; }
    }
    public class CartViewModels
    {
    }
}