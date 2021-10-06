using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace MyProject4.Models.ViewModel
{
    public class PeopleViewModel
    {
        public int Id { get; set; }
        [DisplayName("Person's Name")]
        public string Name { get; set; }
        [DisplayName("Person's Age")]
        public int? Age { get; set; }
    }
}