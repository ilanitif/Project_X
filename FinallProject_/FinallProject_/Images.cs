//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace FinallProject_
{
    using System;
    using System.Collections.Generic;
    
    public partial class Images
    {
        public int Id { get; set; }
        public Nullable<int> UserId { get; set; }
        public Nullable<int> ProductId { get; set; }
        public string img { get; set; }
    
        public virtual Product Product { get; set; }
        public virtual User User { get; set; }
    }
}
