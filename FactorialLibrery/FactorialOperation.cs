using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ReactCalc.Models;

namespace FactorialLibrery
{
    public class FactorialOperation : Operation
    {
        public override long Code
        {
            get { return 1000; }
        }

        public override string Name
        {
            get { return "factorial"; }
        }

        public override string rusName
        {
            get { return "факториал"; }
        }

        public override double Execute(double[] args)
        {
            var x = args[0];
            var count = 2d;
            var result = 1d;

            while (count <= x)
            {
                result *= count;
                count++;
            }
            return result;
        }
    }
}
