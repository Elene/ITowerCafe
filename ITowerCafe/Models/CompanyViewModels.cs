using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using ITowerCafe.Data;

namespace ITowerCafe.Models
{
    public class CreateCompanyViewModel
    {
        public int Id { get; set; }
        public int TypeId { get; set; }
        public int CostId { get; set; }
        [StringLength(35, MinimumLength = 5)]
        public string Name { get; set; }
        public string Description { get; set; }     
        public string LogoUrl { get; set; }
        public IEnumerable<SelectListItem> CompanyTypes { get; set; }
        public IEnumerable<SelectListItem> CompanyCostTypes { get; set; }
    }

    public class LoadCompanyViewModel
    {
        public int Id { get; set; }
        [Display(Name = "Name")]
        public string Name { get; set; }
        [Display(Name = "Description")]
        public string Description { get; set; }
        [Display(Name = "Logo")]
        public string LogoUrl { get; set; }

        public int MenuId { get; set; }

        [Display(Name = "Company Type")]
        public string Type { get; set; }

        [Display(Name = "Average Rating")]
        public double AvgRating { get; set; }

        [Display(Name = "Company Cost")]
        public string Cost { get; set; }

        [Display(Name = "Rating Count")]
        public int RatingCount { get; set; }

        [Display(Name = "Registration Date")]
        public DateTime? RegistrationDate { get; set; }

        public virtual CompanyType CompanyType { get; set; }
        public virtual CompanyCostType CompanyCostType { get; set; }

        public List<DisplayMenuItemViewModel> MenuItems { get; set; }

        public List<Comment> Comments { get; set; }
    }
}