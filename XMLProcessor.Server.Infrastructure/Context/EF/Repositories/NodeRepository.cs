using System;
using System.Threading;
using System.Threading.Tasks;
using XMLProcessor.Server.Application.Contracts;
using XMLProcessor.Server.Domain.Entities;
using XMLProcessor.Server.Infrastructure.Context;

namespace XMLProcessor.Server.Infrastructure.Context.EF.Repositories
{
    public class NodeRepository : INodeRepository
    {
        private readonly NodeProcessorDbContext _context;
        public IUnitOfWork UnitOfWork => _context;

        public NodeRepository(NodeProcessorDbContext context) => _context = context ?? throw new ArgumentNullException(nameof(context));

        public async Task<Node> AddAsync(Node node, CancellationToken cancellationToken)
        {
            return (await _context.Nodes.AddAsync(node)).Entity;
        }
    }
}
