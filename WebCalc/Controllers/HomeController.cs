using DomainModels.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebCalc.Controllers
{
    public class HomeController : Controller
    {
        private DataBasesOperations EssensesRepository { get; set; }

        public HomeController()
        {
            EssensesRepository = new DataBasesOperations();
        }

        public ActionResult Index()
        {
            ViewBag.Users = EssensesRepository.userOpers.GetAll();
            return View();
            
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}