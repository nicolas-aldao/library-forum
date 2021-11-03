using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MyProject4.Models.ViewModel
{
    public class PeopleViewModel
    {
        public int Id { get; set; }
        [DisplayName("Person's Name")]
        [Required]
        [StringLength(30, ErrorMessage = "Do not enter more than 30 characters")]
        [MinLength(2, ErrorMessage = "Minimum characters are 2")]
        public string Name { get; set; }
        
        [DisplayName("Person's Age")]
        [Required] // después borrar
        public int? Age { get; set; }
    }
}