using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleCalculator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                InputConverter inputConverter = new InputConverter();
                CalculatorEngine calculatorEngine = new CalculatorEngine();

                double firstNumber = inputConverter.ConvertInputToNumber(Console.ReadLine());
                double secondNumber = inputConverter.ConvertInputToNumber(Console.ReadLine());
                string operation = Console.ReadLine();

                double result = calculatorEngine.Calculate(firstNumber, secondNumber, operation);

                Console.WriteLine(result);
            }
            catch (Exception ex)
            {
                // Normally would want to log this message
                Console.WriteLine(ex.Message);
            }
            
            Console.ReadLine();
        }
    }
}
