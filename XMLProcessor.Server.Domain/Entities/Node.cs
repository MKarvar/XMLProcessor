using System.Collections.Generic;

namespace XMLProcessor.Server.Domain.Entities
{
    public class Node : BaseEntity
    {
        public string Name { get; set; }
        public string Content { get; set; }
        public virtual ICollection<ProcessResult> ProcessResults { get; set; }
    }
}
