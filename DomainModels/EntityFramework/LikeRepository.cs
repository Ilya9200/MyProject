using DomainModels.Models;
using DomainModels.Repository;
using System.Collections.Generic;
using System.Linq;

namespace DomainModels.EntityFramework
{
    public class LikeRepository : ILikeRepository
    {
        private CalcContext context { get; set; }

        public LikeRepository()
        {
            this.context = new CalcContext();
        }

        public UserFavoriteResult Create()
        {
            return new UserFavoriteResult();
        }

        public void Delete(UserFavoriteResult result)
        {
            context.Entry(result).State = System.Data.Entity.EntityState.Deleted;
            context.SaveChanges();
        }

        public UserFavoriteResult Get(long id)
        {
            return context.UserFavoriteResults.FirstOrDefault(u => u.Id == id);
        }

        public IEnumerable<UserFavoriteResult> GetAll()
        {
            return context.UserFavoriteResults.ToList();
        }

        public void Update(UserFavoriteResult result)
        {
            context.Entry(result).State = result.Id == 0 
                ? System.Data.Entity.EntityState.Added
                : System.Data.Entity.EntityState.Modified;
            context.SaveChanges();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="resultId"></param>
        /// <returns></returns>
        public UserFavoriteResult IsFavoriteResult(long userId, long resultId)
        {
            var userResults = context.UserFavoriteResults.Where(or => or.UserId == userId);

            return userResults.FirstOrDefault(or => or.ResultId == resultId);
        }

        public IEnumerable<UserFavoriteResult> GetByUser(User user)
        {
            if (user == null)
                return new UserFavoriteResult[0];

            return context.UserFavoriteResults.Where(or=>or.UserId==user.Id).ToList();
        }
    }
}
