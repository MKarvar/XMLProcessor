
namespace XMLProcessor.Server.Domain.Entities
{
    public class ProcessResult : BaseEntity
    {
        public virtual Node Node { get; set; }
        public string DuplicateWord { get; set; }
        public int RepetitionCount { get; set; }
    }
}
