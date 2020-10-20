using BasicMvcCoreBugTracker.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace BasicMvcCoreBugTracker.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
            public DbSet<Severity> Severities { get; set; }
            public DbSet<BasicMvcCoreBugTracker.Models.Status> Status { get; set; }
            public DbSet<BasicMvcCoreBugTracker.Models.Bug> Bug { get; set; }
    }
}
