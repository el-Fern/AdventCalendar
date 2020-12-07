using System;
using System.Collections.Generic;

namespace Advent
{
    class Program
    {
        /// <summary>
        
        /// </summary>
        public static List<string> input = new List<string>();

        public static void Main(string[] args)
        {
            ReadInput();

        }

        private static void ReadInput()
        {
            input.AddRange(System.IO.File.ReadAllLines(@"C:/Users/ah3353/source/repos/Advent/Advent/Inputs/Input.txt"));
        }
    }
}
