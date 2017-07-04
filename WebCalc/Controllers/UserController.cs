using DomainModels.Models;
using DomainModels.Repository;
using System.Web.Mvc;

namespace WebCalc.Controllers
{
    public class UserController : Controller
    {
        private IUserRepository UserRepository { get; set; }

        public UserController()
        {
            UserRepository = new DomainModels.EntityFramework.UserRepository();
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
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            var user = UserRepository.Get(id);
            if (user != null)
            {
                return View(user);
            }
            return HttpNotFound();
        }

        [HttpPost]
        public ActionResult Edit(User user)
        {
            if (user.Login != null && user.Password != null)
                UserRepository.Update(user);
            else
                return HttpNotFound();

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(User user)
        {
            if (user.Login != null&&user.Password!=null)
                UserRepository.Create(user);
            else
                return HttpNotFound();
        
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Delete(long? id)
        {
            var user = UserRepository.Get(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            var user = UserRepository.Get(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            UserRepository.Delete(user);
            return RedirectToAction("Index");
        }
    }
}