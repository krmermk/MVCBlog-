using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCBlog.Models.ORM.Entity
{
    public class Category:BaseEntity
    {
        [Required]
        [StringLength(30)]
        public string Name { get; set; }

        [StringLength(300)]
        public string Description { get; set; }

        public virtual List<BlogPost> BlogPosts { get; set; }
    }
}