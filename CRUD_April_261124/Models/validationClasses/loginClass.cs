using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CRUD_April_261124.Models.validationClasses
{
    public class loginClass
    {
        public int Id { get; set; }
        [Required]
        public string userID { get; set; }
        [Required]
        
        public string password { get; set; }
    }
}