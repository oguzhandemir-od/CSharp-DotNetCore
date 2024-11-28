using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MovieManagementProject.Models
{
    public class Category
    {
        public int Id { get; set; }
        [Display(Name = "Category")]
        public string Name { get; set; } 

        
        public virtual ICollection<Movie> Movies { get; set; }
    }
}