using System.Threading;
using System.Threading.Tasks;
using XMLProcessor.Server.Domain.Entities;

namespace XMLProcessor.Server.Application.Contracts
{
    public interface INodeRepository :IRepository<Node>
    {
        Task<Node> AddAsync(Node node, CancellationToken cancellationToken);
    }
}
