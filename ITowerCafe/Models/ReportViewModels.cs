using ITowerCafe.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ITowerCafe.Models
{
    //public class ReportViewModel
    //{
    //    public int Id { get; set; }
    //    [Display(Name = "Name")]
    //    public string Name { get; set; }
    //}

    public class PersonalStatisticViewModel
    {
        public int CompanyId { get; set; }
        [Display(Name = "Company Name")]
        public string CompanyName { get; set; }
        [Display(Name = "Total Cost")]
        public Decimal TotalCost { get; set; }
    }

    public class CompanyStatisticViewModel
    {
        public int CompanyId { get; set; }
        public string CompanyName { get; set; }
        public int OrderCount { get; set; }
        public Decimal TotalCost { get; set; }
    }


    public class ReportViewModel
    {
        public List<PersonalStatisticViewModel> PersonalStatistics {get; set; }

        public MenuProduct MostPopularProduct { get; set; }

        public List<CompanyStatisticViewModel> CompanyStatistics { get; set; }

    }
}