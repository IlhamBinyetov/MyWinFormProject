using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace MyWinFormProject.Entities
{
    public partial class MyModel : DbContext
    {
        public MyModel()
            : base("MyDBConnecionString")
        {
        }

        public virtual DbSet<Detail> Details { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
