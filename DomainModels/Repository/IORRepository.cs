using DomainModels.Models;

namespace DomainModels.Repository
{
    public interface IORRepository : IEntityRepository<OperationResult>
    {
        double GetOldResult(long operationId, string inputData);
    }
}
