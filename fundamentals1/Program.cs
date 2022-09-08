using System;

namespace fundamentals1
{
    public class Program
    {
        static void Main(string[] args)
        {
            // countTo(1, 255);
            // countToDivBy3or5(1, 100);
            // fizzBuzz(2,90);
            countWithWhile(5, 76);
            string place = "Coding Dojo";
            Console.WriteLine($"Hello {place}");
            Console.WriteLine(args);
        }


        private static void countTo(int num1, int num2)
        {
            for(int i = num1; i <= num2; i++) 
            {
                Console.WriteLine($"i is {i}");
            }
        }

        private static async void countToDivBy3or5(int num1, int num2)
        {
            for(int i = num1; i <= num2; i++)
            {
                if(i % 3 == 0 && i % 5 == 0)
                {
                    continue;
                } 
                else if(i % 3 == 0)
                {
                    Console.WriteLine($"{i}");
                }
                else if(i % 5 == 0)
                {
                    Console.WriteLine($"{i}");
                } else 
                {
                    continue;
                }
            }
        }


        private static void fizzBuzz(int num1, int num2)
        {
            for(int i = num1; i <= num2; i++)
            {
                if(i % 3 == 0 && i % 5 == 0)
                {
                    Console.WriteLine("FizzBuzz");
                } 
                else if(i % 3 == 0)
                {
                    Console.WriteLine($"Fizz");
                }
                else if(i % 5 == 0)
                {
                    Console.WriteLine($"Buzz");
                } else 
                {
                    continue;
                }
            }
        }

        private static void countWithWhile(int num1, int num2) 
        {
            int i = num1;
            while(i <= num2)
            {
                Console.WriteLine($"The number is {i}");
                i++;
            }
        }

    }
}