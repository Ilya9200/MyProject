using DomainModels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModels.Repository
{
    public interface IOperationRepository
    {
        void Insert(Operation oper);

        Operation Get(int id);

        void Update(Operation oper);

        void Delete(Operation oper);

        IEnumerable<Operation> GetAll();
    }
}
