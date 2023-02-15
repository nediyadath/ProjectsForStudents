using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MVCExample.Models
{
    public class Category
    {
        public int id { get; set; }
        public string name { get; set; }
    }

    public class Product
    {
        public int id { get; set; }
        public string name { get; set; }
        public int price { get; set; }
        public string description { get; set; }
        [ForeignKey("cid")]
        public int categoryId { get; set; }
        public Category cid { get; set; }
    }

    public class EcomContext: DbContext
    {
        public DbSet<Category> categories { get; set; }
        public DbSet<Product> products { get; set; }
    }
}