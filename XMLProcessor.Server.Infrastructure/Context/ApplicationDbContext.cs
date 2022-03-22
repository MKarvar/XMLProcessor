using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using XMLProcessor.Server.Application.Interfaces;
using XMLProcessor.Server.Domain.Entities;

namespace XMLProcessor.Server.Infrastructure.Context
{
    public class ApplicationDbContext : DbContext, IApplicationDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Node> Nodes { get; set; }
        public async Task<int> SaveChangesAsync()
        {
            return await base.SaveChangesAsync();
        }
    }
}
