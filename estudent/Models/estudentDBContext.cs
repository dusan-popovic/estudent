namespace estudent.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class estudentDBContext : DbContext
    {
        public estudentDBContext()
            : base("name=estudentDBContext")
        {
        }

        public virtual DbSet<Ispit> Ispiti { get; set; }
        public virtual DbSet<Student> Studenti { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
