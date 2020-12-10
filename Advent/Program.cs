using System;
using System.Collections.Generic;
using System.Linq;

namespace Advent
{
    class Program
    {
        /// <summary>
        
        /// </summary>
        public static List<int> input = new List<int>();

        public static void Main(string[] args)
        {
            ReadInput();

            Console.WriteLine("Jolt difference product: " + FindJoltageDifferences());
        }

        private static int FindJoltageDifferences()
        {
            var joltage1Difference = 0;
            var joltage3Difference = 0;
            for (int i = 0; i < input.Count; i++)
            {
                if(i == 0)
                {
                    if(input[i] == 1)
                        joltage1Difference++;
                    else if (input[i] == 3)
                        joltage3Difference++;
                }    
                else if (input[i] - input[i - 1] == 1)
                    joltage1Difference++;
                else if (input[i] - input[i - 1] == 3)
                    joltage3Difference++;
                else
                    Console.WriteLine("Unexpected joltage difference: " + input[i].ToString() + input[i - 1].ToString());
            }

            //the device's built-in adapter is always 3 higher than the highest adapter
            joltage3Difference++;

            return joltage1Difference * joltage3Difference;
        }

        private static void ReadInput()
        {
            input.AddRange(System.IO.File.ReadAllLines(@"C:/Users/ah3353/source/repos/Advent/Advent/Inputs/Input.txt")
                .Select(x=>Convert.ToInt32(x))
                .OrderBy(x=>x)
                .ToList());
        }

    }
}
