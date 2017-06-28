using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReactCalc.Models
{
    public class SumOperation : Operation
    {
        public override long Code
        {
            get { return 1; }
        }

        public override string Name
        {
            get { return "sum"; }
        }

        public override string rusName
        {
            get { return "сумма"; }
        }

        public override string DisplayName
        {
            get { return "сумма1"; }
        }

        public override string Discription 
        {
            get { return "складывает два числа"; }
        }


        public override double Execute(double[] args)
        {
            return args.Sum();
        }
    }
}
