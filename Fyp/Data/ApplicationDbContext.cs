using Fyp.Models;
using Microsoft.EntityFrameworkCore;

namespace Fyp.Data
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
        {
                
        }
        public DbSet<Kyc> KycDetails {  get; set; }
    }
}
