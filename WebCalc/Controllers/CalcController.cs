using DomainModels.Repository;
using ReactCalc;
using ReactCalc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebCalc.Models;

namespace WebCalc.Controllers
{
    [Authorize]
    public class CalcController : BaseController
    {
        

        private Calc Calc { get; set; }

        public CalcController(IORRepository orrepository, IUserRepository UserRepository, IOperationRepository OperationRepository, ILikeRepository LikeRepository)
            : base(orrepository, UserRepository, OperationRepository, LikeRepository)
        {
            Calc = new Calc();
        }

        public ActionResult Index()
        {
            var model = new CalcModel();
            model.OperationList = Calc.Operations.Select(o => new SelectListItem() { Text = $"{o.Name}", Value = $"{o.Name}" });
            return View(model);
        }

        [HttpPost]
        public ActionResult Index(CalcModel model)
        {
            model.OperationList = Calc.Operations.Select(o => new SelectListItem() { Text = $"{o.Name}", Value = $"{o.Name}", Selected = model.Operation == o.Name});
            var operation = Calc.Operations.FirstOrDefault(o => o.Name == model.Operation);
            var dbOper = OperationRepository.GetByName(operation.Name);

            if (operation != null)
            {
                var operId = dbOper.Id;
                var inputData = string.Join(",", model.Arguments);

                var oldResult = ORRepository.GetOldResult(operId, inputData);
                if (!double.IsNaN(oldResult)&&!model.CalcOldRes)
                {
                    model.Result = oldResult;
                }
                else
                {
                    model.Result = operation.Execute(model.Arguments);

                    var rec = ORRepository.Create();

                    // текущего пользователя назначаем автором
                    var currUser = UserRepository.GetByName(User.Identity.Name);
                    rec.AuthorId = currUser.Id;

                    rec.OperationId = operId;

                    rec.ExecutionDate = DateTime.Now;
                    rec.ExecutionTime = new Random().Next(0, 100);
                    rec.InputData = inputData;
                    rec.Result = model.Result ?? Double.NaN;

                    ORRepository.Update(rec);
                }
                return View(model);
            }

            return View();
        }
    }
}