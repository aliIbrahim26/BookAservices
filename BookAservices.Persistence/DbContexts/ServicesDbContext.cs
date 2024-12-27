using BookAservices.Domain;
using Microsoft.EntityFrameworkCore;

namespace BookAservices.Persistence.DbContexts
{
    public class ServicesDbContext:DbContext
    {
        public ServicesDbContext(DbContextOptions<ServicesDbContext>options):base(options) 
        {
            
        }
        public DbSet<DifferenceData> DifferenceDatas { get; set; }
        public DbSet<Differences> Differences { get; set; }
        public DbSet<OptionsDifference> OptionsDifferences { get; set; }
        public DbSet<OptionsDifferenceData> OptionsDifferenceDatas { get; set; }
        public DbSet<Order> orders { get; set; }
        public DbSet<OrderDetails> OrderDetails { get; set; }
        public DbSet<ServiceRequest> serviceRequests { get; set; }
        public DbSet<Services> Services { get; set; }
    }
}
