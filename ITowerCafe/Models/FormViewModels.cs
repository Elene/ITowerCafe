using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace ITowerCafe.Models
{
    public class FormViewModel
    {
        public int FormId { get; set; }
        [Display(Name = "Name")]
        public string FormName { get; set; }
    }

    public class SingleFormViewModel
    {
        public int Id { get; set; }
        [Display(Name = "Name")]
        public string Name { get; set; }
    }

}