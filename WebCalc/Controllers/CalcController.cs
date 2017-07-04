using DomainModels.Models;
using DomainModels.Repository;
using ReactCalc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebCalc.Models;

namespace WebCalc.Controllers
{
    [Authorize]
    public class CalcController : Controller
    {
        private IORRepository ORRepository { get; set; }
        private IUserRepository userrep { get; set; }
        private IOperationRepository OperationRepository { get; set; }

        private Calc Calc { get; set; }

        public CalcController(IORRepository orrepository, IUserRepository userrep, IOperationRepository OperationRepository)
        {
            Calc = new Calc();
            ORRepository = orrepository;
            this.userrep = userrep;
            this.OperationRepository = OperationRepository;
        }

        public ActionResult Index()
        {
            var model = new CalcModel();
            return View(model);
        }


        [HttpPost]
        public ActionResult Index(CalcModel model)
        {
            var operation = Calc.Operations.FirstOrDefault(o => o.Name == model.Operation);
            if (operation != null)
            {
                var oper = OperationRepository.CodeInId(operation.Code);

                if (oper == null)
                {
                    ModelState.AddModelError("", "Операции с таким названием не существует");
                    return View();
                }
                var operId = oper.Id;

                var inputData = string.Join(",", model.Arguments);

                var oldResult = ORRepository.GetOldResult(operId, inputData);
                if (!double.IsNaN(oldResult))
                {
                    model.Result = oldResult;
                }
                else
                {
                    #region Вычисление
                    model.Result = operation.Execute(model.Arguments);

                    var rec = ORRepository.Create();

                    // текущего пользователя назначаем автором
                    var currUser = userrep.GetByName(User.Identity.Name);
                    rec.AuthorId = currUser.Id;

                    rec.OperationId = operId;

                    rec.ExecutionDate = DateTime.Now;
                    rec.ExecutionTime = new Random().Next(0, 100);
                    rec.InputData = inputData;
                    rec.Result = model.Result ?? Double.NaN;

                    ORRepository.Update(rec);
                    #endregion
                }
                return View(model);
            }

            return View();
        }

        public ActionResult UpdateOperations()
        {
            var operation = Calc.Operations;

            foreach (var oper in operation)
            {
                if (OperationRepository.CodeInId(oper.Code) == null)
                {
                    var NewOper = new Operation();

                    NewOper.Code = oper.Code;
                    NewOper.Name = oper.Name;
                    NewOper.Uid = Guid.NewGuid();
                    NewOper.FullName = string.Format("{0}(standart)",oper.Name); //ХАК тут надо проверять существует ли операция с таким именем

                    OperationRepository.Update(NewOper);
                }
            }
            ModelState.AddModelError("","Операции обновлены");
            return RedirectToAction("Index");
        }
    }
}