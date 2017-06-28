using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReactCalc.Models
{
    public interface IDisplayOperation:IOperation
    {
        string DisplayName { get; }

        string Discription { get; }

        string Author { get; }

        bool hard { get; }
    }

}
