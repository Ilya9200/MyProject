using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ReactCalc.Models;


namespace TestCalc
{
    [TestClass]
    public class CalcTest
    {
        [TestMethod]
        public void TestPow()
        {
            var op = new ReactCalc.Models.PowOperation();
            Assert.AreEqual(op.Execute(new double[] { 4,2 }), 16);

            // Assert.AreEqual(x, 3);
            //Assert.AreEqual(calc.Sum(0, 0), 0);
            //  Assert.AreEqual(calc.Sum(-1, 2), 1);
            // Assert.AreEqual(calc.Sum(3, 3), 6);
        }



    }
}
