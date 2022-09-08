using System;

namespace multiplicationTable
{
    internal class Program
    {
        static void Main(string[] args)
        {
            makeATable(10,10);
        }


        public static int[,] makeATable(int num1, int num2)
        {
        int [,] multTable = new int[num1, num2];
        for(var i = 0; i < num1; i++){
            for(var j = 0; j < num2; j++)
            {
                multTable[i,j] = (i + 1) * (j + 1);
                Console.WriteLine(multTable[i, j]);
            }
            
        }
        return multTable;
        }
        // need code for building string table.
        
    }
}