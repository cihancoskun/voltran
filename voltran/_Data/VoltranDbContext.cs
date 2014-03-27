using System.Data.Entity;

using Voltran.Web.Data.Entities;

namespace Voltran.Web.Services.Data
{
    public class VoltranDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<City> Cities { get; set; } 
        public DbSet<ParentCompany> ParentCompanies { get; set; }
        public DbSet<District> Districts { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<ImagesOfCompany> ImagesOfCompanies { get; set; }
        public DbSet<Feedback> Feedbacks { get; set; }
         
        public VoltranDbContext(string connectionStringOrName)
            : base(connectionStringOrName)
        {
            Database.SetInitializer(new VoltranDbInitializer());
        }

        public VoltranDbContext()
            : this("Name=VoltranDbContext")
        { } 
    }
}
