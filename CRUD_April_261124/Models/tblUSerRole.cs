//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CRUD_April_261124.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class tblUSerRole
    {
        public int Id { get; set; }
        public Nullable<int> UserId { get; set; }
        public string role { get; set; }
    
        public virtual tbllogin tbllogin { get; set; }
    }
}
