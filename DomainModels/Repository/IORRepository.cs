using DomainModels.Models;
using System.Collections.Generic;

namespace DomainModels.Repository
{
    public interface IORRepository : IEntityRepository<OperationResult>
    {
        double GetOldResult(long operationId, string inputData);

        IEnumerable<OperationResult> GetByUser(User user);
    }
}
