using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace EntityHW.Models
{
    public partial class ProductModel : DbContext
    {
        public ProductModel()
            : base("name=ProductsModel")
        {
        }

        public virtual DbSet<ProductTable> ProductTable { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
