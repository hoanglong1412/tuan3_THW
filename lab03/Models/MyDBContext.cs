using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace lab03.Models
{
    public partial class MyDBContext : DbContext
    {
        public MyDBContext()
            : base("name=MyDBContext")
        {
        }

        public virtual DbSet<Book> Books { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>()
                .Property(e => e.Name)
                .IsFixedLength();

            modelBuilder.Entity<Book>()
                .Property(e => e.Author)
                .IsFixedLength();

            modelBuilder.Entity<Book>()
                .Property(e => e.title)
                .IsFixedLength();

            modelBuilder.Entity<Book>()
                .Property(e => e.Img)
                .IsFixedLength();
        }
    }
}
