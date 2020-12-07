using System;
using System.Collections.Generic;
using System.Linq;

namespace Advent
{
    class Program
    {
        /// <summary>
        
        /// </summary>
        public static List<List<char>> input = new List<List<char>>();

        public static void Main(string[] args)
        {
            ReadInput();

            Console.WriteLine("Total count: " + input.Sum(x => x.Count));
        }

        private static void ReadInput()
        {
            string[] lines = System.IO.File.ReadAllLines(@"C:/Users/ah3353/source/repos/Advent/Advent/Inputs/Input.txt");

            var newString = "";
            foreach (var line in lines)
            {
                if (line != "")
                    newString += line;
                else
                {
                    input.Add(newString.Distinct().ToList());
                    newString = "";
                }
            }
            input.Add(newString.Distinct().ToList());
        }
    }
}
