using NUnit.Framework;
using System;

namespace Calculator.Tests
{
    public class CalculatorTests
    {
        [TestCase("10 * (4 + 6) / 2 ", "10 4 6 + * 2 / ")]
        [TestCase("2 + 1 ", "2 1 + ")]
        [TestCase("43 * (2 / (4 + 9)) / 2 ", "43 2 4 9 + / * 2 / ")]
        public void TranslatePostfixNotationTest(string expresion, string expectedPostfixExpresion)
        {
            string actualPostfixExpresion = Calculator.TranslatePostfixNotation(expresion);
            Assert.AreEqual(expectedPostfixExpresion, actualPostfixExpresion);
        }

        [TestCase("1 1 + ", 2)]
        [TestCase("10 4 6 + * 2 / ", 50)]
        [TestCase("43 2 2 2 + / * 2 / ", 10.75)]
        public void SolveExpressionTest(string postfixExpresion, double expectedResult)
        {
            double actualResult = Calculator.SolveExpression(postfixExpresion);
            Assert.AreEqual(expectedResult, actualResult);
        }
    }
}