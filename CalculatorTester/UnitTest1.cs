using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Calculator;

namespace CalculatorTester
{
    [TestClass]
    public class UnitTest1
    {
        private Calculation c;

        [TestInitialize]
        public void SetUp()
        {
            c = new Calculation(10, 5);
        }
        public TestContext TestContext { get; set; }
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV",
            @".\Data\TestData.csv", "TestData#csv", DataAccessMethod.Sequential)]
        [TestMethod]
        public void TestWithDataSource()
        {
            int a = int.Parse(TestContext.DataRow[0].ToString());
            int b = int.Parse(TestContext.DataRow[1].ToString());
            int expected = int.Parse(TestContext.DataRow[3].ToString());
            string Operation;
            Operation = TestContext.DataRow[2].ToString();
            Operation = Operation.Remove(0, 1);
            Calculation c = new Calculation(a, b); 
            int actual = c.Execute(Operation);
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void TestAddOperator()
        {
            int expected, actual;
            expected = 15;
            actual = c.Execute("+");
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void TestSubOperator()
        {
            int expected, actual;
            expected = 5;
            actual = c.Execute("-");
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void TestMulOperator()
        {
            int expected, actual;
            expected = 50;
            actual = c.Execute("*");
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void TestDivOperator()
        {
            int expected, actual;
            expected = 2;
            actual = c.Execute("/");
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        [ExpectedException(typeof(DivideByZeroException))]
        public void TestDivByZero()
        {
            c = new Calculation(10, 0);
            c.Execute("/");
        }
        [TestMethod]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV",
            @".\Data\TestPower.csv", "TestPower#csv", DataAccessMethod.Sequential)]
        public void TestPowwer()
        {
            int n = int.Parse(TestContext.DataRow[1].ToString());
            double x = double.Parse(TestContext.DataRow[0].ToString());
            double expected = double.Parse(TestContext.DataRow[2].ToString());
            double actual = Calculation.Power(x, n);
            Assert.AreEqual(expected, actual);
        }
    }
}