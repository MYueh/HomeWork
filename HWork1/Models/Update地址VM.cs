﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HWork1.Models
{
    public class Update地址VM
    {
        public int Id { get; set; }
        [Required]
        public string 地址 { get; set; }
    }
}