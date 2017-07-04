using ReactCalc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalcBase.Models
{
    public class ResOperation:Operation
    {
        public override long Code
        {
            get { return 3; }
        }

        public override string Name
        {
            get { return "res"; }
        }

        public override double Execute(double[] args)
        {
            return args[0] - args[1];
        }

        public override string DisplayName
        {
            get { return "Разность"; }
        }

        public override string Description
        {
            get
            {
                return "Стандартное вычисление разности";
            }
        }

        public override string Author
        {
            get
            {
                return "ApplyInc";
            }
        }
    }
}
