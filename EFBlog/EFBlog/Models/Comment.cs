using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EFBlog.Models
{
    public class Comment
    {
        public int Id { get; set; }
        [Required]
        public BlogUser Author { get; set; }
        [Required]
        public string Text { get; set; }
        [Required]
        public BlogPost Post { get; set; }
    }
}
