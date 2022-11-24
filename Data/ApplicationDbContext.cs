using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using DisasterAlleviationFoundation.Data;

namespace DisasterAlleviationFoundation.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<MoneyDonations> MoneyDonations { get; set; }
        public DbSet<Catergory> Catergories { get; set; }
        public DbSet<GoodDonations> GoodDonations { get; set; }
        public DbSet<Disasters> Disasters { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            var catergories = new List<Catergory>
            {
                new Catergory { CatergoryId = 1, Name = "Clothes", Description = "Clothing to wear", Date = DateTime.Now },
                new Catergory { CatergoryId = 2, Name = "Non‐perishable foods.", Description = "Canned food and long shelve life", Date = DateTime.Now }
            };

            builder.Entity<Catergory>()
                .HasData(catergories);

            base.OnModelCreating(builder);
        }


    }
}