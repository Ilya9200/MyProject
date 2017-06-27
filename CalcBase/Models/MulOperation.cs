using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ReactCalc.Models;

namespace ReactCalc.Models
{
    public class MulOperation : Operation
    {
        public override long Code
        {
            get { return 4; }
        }

        public override string Name
        {
            get { return "mul"; }
        }

        public override string rusName
        {
            get { return "произведение"; }
        }

        public override double Execute(double[] args)
        {
            return args[0] * args[1];
        }
    }
}
