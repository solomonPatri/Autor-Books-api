using Autor_Books_Api;
using Microsoft.EntityFrameworkCore;
using Autor_Books_Api.Autors.Model;
using Autor_Books_Api.Books.Model;


namespace Autor_Books_Api.Data
{
    public class AppDbContext:DbContext
    {

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {



        }
        public virtual DbSet<Autor> Autors
        {
            get;
            set;
        }

        public virtual DbSet<Book> Books
        {

            get;
            set;

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Autor>()
                .HasMany(a => a.Books)
                .WithOne(b => b.Autor)
                .HasForeignKey(b => b.AutorId)
                .OnDelete(DeleteBehavior.Cascade);








        }















    }
}
