using DomainModels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModels.Repository
{
    public interface IOperationResultRepository
    {
       // void Insert(OperationResult operRes);

       // OperationResult Get(int id);

       // void Update(OperationResult operRes);

       // void Delete(OperationResult operRes);

        IEnumerable<OperationResult> GetAll();
    }
}
