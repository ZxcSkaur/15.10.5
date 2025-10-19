using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace WindowsFormsApp1.ModelEF
{
    public partial class ModelEF : DbContext
    {
        public ModelEF()
            : base("name=Model11")
        {
        }

        public virtual DbSet<Roles> Roles { get; set; }
        public virtual DbSet<Users> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Roles>()
                .HasMany(e => e.Users)
                .WithRequired(e => e.Roles)
                .HasForeignKey(e => e.Role_Name)
                .WillCascadeOnDelete(false);
        }
    }
}
