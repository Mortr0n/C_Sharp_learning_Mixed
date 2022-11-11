﻿using System;

namespace SimpleCalculator
{
    public class InputConverter
    {
        public double ConvertInputToNumber(string input)
        {
            double convertedNumber;
            if(!double.TryParse(input, out convertedNumber))
            {
                throw new ArgumentException("Expected a numeric value");
            }
            return convertedNumber;
        }
    }
}