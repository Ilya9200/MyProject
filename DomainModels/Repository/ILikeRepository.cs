using DomainModels.Models;
using System.Collections.Generic;

namespace DomainModels.Repository
{
    public interface ILikeRepository : IEntityRepository<UserFavoriteResult>
    {
        UserFavoriteResult IsFavoriteResult(long userId, long resultId);

        IEnumerable<UserFavoriteResult> GetByUser(User user);
    }
}
