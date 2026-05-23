using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MovieManagementProject.Models
{
    public class Movie
    {
        public int Id { get; set; }          
        public string Title { get; set; }    
        public string Director { get; set; } 
        public int Year { get; set; }        

        
        public int CategoryId { get; set; } 
        public virtual Category Category { get; set; }  
    }
}