using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using XMLProcessor.Server.Domain.Entities;

namespace XMLProcessor.Server.Application.Interfaces
{
    public interface IApplicationDbContext
    {
        DbSet<Node> Nodes { get; set; }
        Task<int> SaveChangesAsync();
    }
}
