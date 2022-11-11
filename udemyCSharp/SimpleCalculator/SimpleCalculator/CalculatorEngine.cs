using System;

namespace SimpleCalculator
{
    public class CalculatorEngine
    {
        public double Calculate(double firstNumber, double secondNumber, string operation)
        {
            double result;

            switch(operation.ToLower())
            {
                case "add":
                case "+":
                    result = firstNumber + secondNumber;
                    break;
                case "subtract":
                case "-":
                    result = firstNumber - secondNumber;
                    break ;
                case "divide":
                case "/":
                    result = firstNumber / secondNumber;
                    break;
                case "multiply":
                case "*":
                    result = firstNumber * secondNumber;
                    break;
                default:
                    throw new InvalidOperationException("What are you trying to do there skippy?");
                    break;
            }
            return result;
        }
    }
}