using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MVCBlog.Models.ORM.Entity
{
    public class BlogPost:BaseEntity
    {
        [Required]
        [StringLength(50)]
        public string Title { get; set; }

        [Required]
        public string Content { get; set; }
                
        public int CategoryID { get; set; }

        [ForeignKey("CategoryID")]
        public virtual Category Categories { get; set; }
    }
}