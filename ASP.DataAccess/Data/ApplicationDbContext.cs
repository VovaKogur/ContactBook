using ASP.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ASP.DataAccess.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<Contact> Contacts { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("DefaultConnection", b => b.MigrationsAssembly("ASP.Web"));
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Contact>().HasData(new Contact
            {
                Id = 1,
                Name = "Bob",
                Surname = "Johnson",
                Email ="bobjohnson@gmail.com",
                PhoneNumber="+15555551234"
            },
               new Contact
               {
                   Id = 2,
                   Name = "Alice",
                   Surname = "Smith",
                   Email = "alicesmith@yahoo.com",
                   PhoneNumber = "+16666661234"
               },
            new Contact
            {
                Id = 3,
                Name = "Charlie",
                Surname = "Williams",
                Email = "charliewilliams@gmail.com",
                PhoneNumber = "+17777771234"
            },
            new Contact
            {
                Id = 4,
                Name = "David",
                Surname = "Jones",
                Email = "davidjones@outlook.com",
                PhoneNumber = "+18888881234"
            },
            new Contact
            {
                Id = 5,
                Name = "Emma",
                Surname = "Brown",
                Email = "emmabrown@yahoo.com",
                PhoneNumber = "+19999991234"
            });
        }
    }
}
