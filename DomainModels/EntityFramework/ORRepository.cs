using DomainModels.Models;
using DomainModels.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModels.EntityFramework
{
    public class ORRepository : IORRepository
    {
        private CalcContext context { get; set; }

        public ORRepository()
        {
            this.context = new CalcContext();
        }

        public OperationResult Create()
        {
            return new OperationResult()
            {
                Uid = Guid.NewGuid()
            };
        }

        public void Delete(OperationResult result)
        {
            context.Entry(result).State = System.Data.Entity.EntityState.Deleted;
            context.SaveChanges();
        }

        public OperationResult Get(long id)
        {
            return context.OperationResults.FirstOrDefault(u => u.Id == id);
        }

        public IEnumerable<OperationResult> GetAll()
        {
            return context.OperationResults.ToList();
        }

        public void Update(OperationResult result)
        {
            context.Entry(result).State = result.Id == 0 
                ? System.Data.Entity.EntityState.Added
                : System.Data.Entity.EntityState.Modified;
            context.SaveChanges();
        }

        public double GetOldResult(long operationId, string inputData)
        {
            var rec = context.OperationResults.FirstOrDefault(u => u.OperationId == operationId && u.InputData == inputData);
            return rec != null ? rec.Result : double.NaN;
        }
    }
}
