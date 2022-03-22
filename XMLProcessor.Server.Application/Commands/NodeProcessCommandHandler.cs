using MediatR;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;
using System.Collections.Generic;
using System;
using XMLProcessor.Server.Domain.Entities;
using XMLProcessor.Server.Application.Exceptions;
using XMLProcessor.Server.Application.Interfaces;

namespace XMLProcessor.Server.Application.Commands
{
    public class NodeProcessCommandHandler : AsyncRequestHandler<NodeProcessCommand>
    {
        private readonly IApplicationDbContext _context;
        public NodeProcessCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }
        protected override async Task<int> Handle(NodeProcessCommand command, CancellationToken cancellationToken)
        {
            try
            {
                var node = new Node();
                node.Name = command.NodeName;
                node.Content = command.Content;
                node.ProcessResults = Processor(command.Content);
                _context.Nodes.Add(node);
                await _context.SaveChangesAsync();
                return node.Id;
            }
            catch (Exception ex)
            {
                throw new XMLProcessorApplicationException("Handling NodeProcessCommand for node {command.NodeName} is failed", ex.InnerException);
            }
        }

        private ICollection<ProcessResult> Processor(string content)
        {
            return content.ToLower().Split(' ').ToList().GroupBy(w => w)
               .Where(w => w.Count() > 1)
               .Select(w => new ProcessResult() { DuplicateWord = w.Key, RepetitionCount = w.Count() })
               .ToList();
        }
    }
}
