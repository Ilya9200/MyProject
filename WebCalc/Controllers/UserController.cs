using DomainModels.Models;
using DomainModels.Repository;
using System.Web.Mvc;

namespace WebCalc.Controllers
{
    [Authorize]
    public class UserController : Controller
    {
        private IUserRepository UserRepository { get; set; }

        public UserController(IUserRepository UserRepository)
        {
            this.UserRepository = UserRepository;
        }

        public ActionResult Index()
        {
            ViewBag.Users = UserRepository.GetAll();

            return View();
        }

        public ActionResult View(long id)
        {
            var user = UserRepository.Get(id);
            
            return View(user);
        }

        [HttpGet]
        public ActionResult Edit(long id)
        {
            var user = UserRepository.Get(id);
            return View(user);
        }

        [HttpPost]
        public ActionResult Edit(User user)
        {

            UserRepository.Update(user);

            return RedirectToAction("Index");
        }
    }
}