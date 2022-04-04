using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;
using XMLProcessor.Server.Application.Contracts;
using XMLProcessor.Server.Domain.Entities;

namespace XMLProcessor.Server.Infrastructure.Context.EF
{
    public class NodeProcessorDbContext : DbContext, IUnitOfWork
    {
        public NodeProcessorDbContext(DbContextOptions<NodeProcessorDbContext> options)
            : base(options)
        {
        }
        public DbSet<Node> Nodes { get; set; }

        public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken)) =>
            await base.SaveChangesAsync();
    }

}
