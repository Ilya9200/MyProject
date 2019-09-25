using DomainModels.Repository;
using System.Web.Mvc;
using System.Linq;

namespace WebCalc.Controllers
{
    public class OperationResultController : BaseController
    {
        public OperationResultController(IORRepository orrepository, IUserRepository UserRepository, IOperationRepository OperationRepository, ILikeRepository LikeRepository)
            : base(orrepository, UserRepository, OperationRepository, LikeRepository)
        {
        }

        public ActionResult Index()
        {
            var curUser = GetCurrentUser();

            var results = ORRepository.GetByUser(curUser);

            var likes = LikeRepository.GetByUser(curUser).Select(it => it.ResultId);  

            foreach (var result in results)
            {
                result.IsLiked = likes.Contains(result.Id);
            }

            return View(results);
        }

        [HttpPost]
        public JsonResult Like(long id)
        {
            var result = ORRepository.Get(id);
            if (result == null)
            {
                return Json(new { Success = false, Error = "Не удалось найти результат" });
            }

            // Получить текущего юзера
            var curUser = GetCurrentUser();

            var like = LikeRepository.IsFavoriteResult(curUser.Id, id);

            if (like != null)
            {
                LikeRepository.Delete(like);
                return Json(new { Success = true, Name = "like" });
            }

            // Создать лайк
            like = LikeRepository.Create();

            // Заполнить свойства
            like.UserId = curUser.Id;
            like.ResultId = result.Id;

            // Сохранить
            LikeRepository.Update(like);

            // Вернуться к списку операций
            return Json(new { Success = true, Name = "dislike" });
        }
    }
}