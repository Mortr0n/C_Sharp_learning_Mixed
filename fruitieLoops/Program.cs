using System;

namespace fruitieLoops
{
    class Program
    {
        static void Main(string[] args)
        {
            // countTo(255);
            // divisibleByonly3or5ButNotBoth(100);
            countFromOneTooAnother(1, 100);

        }

        private static void countTo(int number) 
        {
            for(int i = 0; i<=number; i++)
            {
                Console.WriteLine($"I is : {i}");
            }
        }

        private static void divisibleByonly3or5ButNotBoth(int number)
        {
            for(int i = 1; i <= number; i++)
            {
                if(i%3 == 0 && i%5 == 0 )
                {
                    Console.WriteLine("FizzBuzz");
                } else if(i%5 == 0) 
                {
                    Console.WriteLine($"Buzz");
                } else if(i%3 == 0 ) 
                {
                    Console.WriteLine($"Fizz");
                } else 
                {
                    continue;
                }

            }
        }

        private static void countFromOneTooAnother(int num1, int num2)
        {
            int i = num1;
            while(i <= num2)
            {
                Console.WriteLine($"Counting: {i}");
                i++;
            }
        }

        private static void FizzBuzz(int num1, int num2)
        {
            
        }
    }

    
}