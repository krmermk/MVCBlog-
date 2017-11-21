using MVCBlog.Models.ORM.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace MVCBlog.Models.ORM.Context
{
    public class BlogContext:DbContext
    {
        public BlogContext()
        { 
            //Database bağlantı cümlesi
            Database.Connection.ConnectionString = "Server=.;Database=Blog;Trusted_Connection=True";
        }

        //Aşağıdaki kod satırı database'de tablolarının sonuna s takısı eklemeyi engeller.
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

        public DbSet<AdminUser> AdminUsers{ get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<BlogPost> Blogposts  { get; set; }
        public DbSet<SiteMenu> SiteMenus { get; set; }
    }
}