
using MediatR;

namespace XMLProcessor.Server.Application.Commands
{
    public class NodeProcessCommand : IRequest
    {
        public string NodeName { get; set; }
        public string Content { get; set; }

    }
}
