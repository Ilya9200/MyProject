using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReactCalc.Models
{
    public class PowOperation : Operation
    {
        public override long Code
        {
            get { return 2000; }
        }

        public override string Name
        {
            get { return "pow"; }
        }

        public override string rusName
        {
            get { return "степень числа"; }
        }

        public override bool hard
        {
            get { return true; }
        }

        public override double Execute(double[] args)
        {
            return Math.Pow(args[0], args[1]);
        }
    }
}
