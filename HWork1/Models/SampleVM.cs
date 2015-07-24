using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HWork1.Models
{
    public class SampleVM     //Sampel ViewModel
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Title { get; set; }
    }
}