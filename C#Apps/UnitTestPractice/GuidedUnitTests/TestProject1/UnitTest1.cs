using Microsoft.VisualStudio.TestTools.UnitTesting;
using CalculationProject;

namespace TestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestAddition()
        {
            CalculationClass cc = new CalculationClass();
            int firstNum = 4;
            int secondNum = 6;
            int expectedNum = 10;
            int actualNum = cc.Addition(firstNum, secondNum);
            Assert.AreEqual(expectedNum, actualNum);
        }

        [TestMethod]
        public void TestSubtraction()
        {
            CalculationClass cc = new CalculationClass();
            int firstNum = 10;
            int secondNum = 6;
            int expectedNum = 4;
            int actualNum = cc.Subtraction(firstNum, secondNum);
            Assert.AreEqual(expectedNum, actualNum);
        }
        [TestMethod]
        public void TestSMultiplication()
        {
            CalculationClass cc = new CalculationClass();
            int firstNum = 3;
            int secondNum = 6;
            int expectedNum = 18;
            int actualNum = cc.Multiplication(firstNum, secondNum);
            Assert.AreEqual(expectedNum, actualNum);
        }
        [TestMethod]
        public void TestDivision()
        {
            CalculationClass cc = new CalculationClass();
            int firstNum = 10;
            int secondNum = 5;
            int expectedNum = 2;
            int actualNum = cc.Division(firstNum, secondNum);
            Assert.AreEqual(expectedNum, actualNum);
        }
    }
}