using XMLProcessor.Server.Domain.Entities;

namespace XMLProcessor.Server.Application.Contracts
{
    public interface IRepository<T> where T : IEntity
    {
        IUnitOfWork UnitOfWork { get; }
    }
}
