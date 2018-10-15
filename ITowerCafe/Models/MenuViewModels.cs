using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ITowerCafe.Models
{
    public class CreateMenuItemViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        [Display(Name = "Preparation Time (In Minutes)")]
        public int PreparationTime { get; set; }
        public int CategoryId { get; set; }
        public int ProductCodeId { get; set; }
        public IEnumerable<SelectListItem> Categories { get; set; }
        public IEnumerable<SelectListItem> Products { get; set; }
    }

    public class DisplayMenuItemViewModel
    {
        public int Id { get; set; }
        [Display(Name = "Name")]
        public string Name { get; set; }
        public decimal Price { get; set; }
        [Display(Name = "Preparation Time (In Minutes)")]
        public int PreparationTime { get; set; }
        public string Category { get; set; }
        [Display(Name = "Product Code")]
        public string ProductCode { get; set; }
    }
}