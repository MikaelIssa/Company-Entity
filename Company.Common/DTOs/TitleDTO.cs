﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.Common.DTOs
{
    public record TitleDTO
    {
        public int Id { get; set; }
        [MaxLength(50), Required]
        public string Role { get; set; }
    }
}
