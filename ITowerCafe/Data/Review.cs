//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ITowerCafe.Data
{
    using System;
    using System.Collections.Generic;
    using System.Web.Mvc;

    public partial class Review
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int RatingId { get; set; }
        public Nullable<int> CommentId { get; set; }
    
        public virtual Comment Comment { get; set; }
        public virtual Order Order { get; set; }
        public virtual Rating Rating { get; set; }

        public IEnumerable<SelectListItem> Ratings { get; set; }
        public IEnumerable<SelectListItem> CommentTypes { get; set; }
    }
}
