using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace SimpleCalculator.Test.Unit
{
    [TestClass]
    public class InputConverterTest
    {
        private readonly InputConverter _inputConverter = new SimpleCalculator.InputConverter();

        [TestMethod]
        public void ConvertsValidStringInputToDouble()
        {
            string inputNumber = "5";
            double convertedNumber = _inputConverter.ConvertInputToNumber(inputNumber);
            Assert.AreEqual(5, convertedNumber);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void FailsToConvertInvalidStringInputToDouble()
        {
            string inputNumber = "#";
            double convertedNumber = _inputConverter.ConvertInputToNumber(inputNumber);
        }
    }
}
