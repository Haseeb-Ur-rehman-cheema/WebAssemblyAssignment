using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using WebAssemblyAssignment.Shared;

namespace WebAssemblyAssignment.Server
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Freelancer> Freelancers { get; set; }
        public DbSet<ServiceRequest> ServiceRequests { get; set; }
    }

}
