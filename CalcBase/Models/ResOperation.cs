using ReactCalc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReactCalc
{
    public class ResOperation : Operation
    {
        public override long Code
        {
            get { return 5; }
        }

        public override string Name
        {
            get { return "res"; }
        }

        public override string rusName
        {
            get { return "разность"; }
        }

        public override double Execute(double[] args)
        {
            return args[0] - args[1];
        }
    }
}
