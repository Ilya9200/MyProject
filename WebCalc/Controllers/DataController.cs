using DomainModels.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebCalc.Controllers
{
    public class DataController : Controller
    {
        private DataBasesOperations EssensesRepository { get; set; }
 
        public DataController()
        {
            EssensesRepository = new DataBasesOperations();
        }
        public ActionResult Index()
        {
            ViewBag.Users = EssensesRepository.userOpers.GetAll();
            ViewBag.Opers = EssensesRepository.operOpers.GetAll();
            ViewBag.OperRes = EssensesRepository.operRes.GetAll();
            ViewBag.UsrFavRes = EssensesRepository.usrFevRes.GetAll();
            return View();
        }

        [HttpPost]
        public ActionResult Authentificate(List<string> names)
        {
            return View();
        }
    }
}