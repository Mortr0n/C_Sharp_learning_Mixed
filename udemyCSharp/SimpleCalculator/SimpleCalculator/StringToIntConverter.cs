using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleCalculator
{
    internal class StringToIntConverter
    {
        public static int convert(string input)
        {
            try
            {
                int convertedNumber;
                bool convertedSuccessfully = int.TryParse(input, out convertedNumber);
                if(!convertedSuccessfully)
                {
                    throw new Exception("Exception with converting to int");
                }
                return convertedNumber;
            } catch (Exception ex)
            {
                throw;
            } 
            
        }
    }
}
