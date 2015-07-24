using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HWork1.Models
{
    public class Update姓名VM
    {
        public int Id { get; set; }
        [Required]
        public string 姓名 { get; set; }
    }
}