using ReactCalc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DevineLibrery
{
    public class DevineOperation : Operation
    {
        public override long Code
        {
            get { return 3000; }
        }

        public override string Name
        {
            get { return "devine"; }
        }

        public override string rusName
        {
            get { return "частное"; }
        }

        public override double Execute(double[] args)
        {
            return args[1] / args[2];
        }
    }
}
