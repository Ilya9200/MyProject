using DomainModels.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainModels.Models;

namespace DomainModels.EntityFramework
{
   public class OperationRepository : IOperationRepository
    {
        private CalcContext context { get; set; }

        public OperationRepository()
        {
            this.context = new CalcContext();
        }

        public Operation Create()
        {
            throw new NotImplementedException();
        }

        public void Delete(Operation oper)
        {
            throw new NotImplementedException();
        }

        public Operation Get(long id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Operation> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Update(Operation oper)
        {
            context.Entry(oper).State = context.Operations.FirstOrDefault(o => o.Id == oper.Id)==null
                ? System.Data.Entity.EntityState.Added
                : System.Data.Entity.EntityState.Modified;
            context.SaveChanges();
        }
        //По коду возвращает операцию
        public Operation CodeInId(long Code)
        {
            return context.Operations.FirstOrDefault(o => o.Code==Code);
        }

    }
}
