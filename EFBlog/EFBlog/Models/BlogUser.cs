﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EFBlog.Models
{
    [Table("Users")]
    public class BlogUser
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(20)]
        public string Username { get; set; }
    }
}
