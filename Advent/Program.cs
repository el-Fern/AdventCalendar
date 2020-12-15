using System;
using System.Collections.Generic;
using System.Linq;

namespace Advent
{
    class Program
    {
        /// <summary>
        ///--- Day 11: Seating System ---
        ///Your plane lands with plenty of time to spare.The final leg of your journey is a ferry that goes directly to the tropical island where you can finally start your vacation.As you reach the waiting area to board the ferry, you realize you're so early, nobody else has even arrived yet!
        ///
        ///By modeling the process people use to choose(or abandon) their seat in the waiting area, you're pretty sure you can predict the best place to sit. You make a quick map of the seat layout (your puzzle input).
        ///
        ///The seat layout fits neatly on a grid.Each position is either floor (.), an empty seat(L), or an occupied seat(#). For example, the initial seat layout might look like this:
        ///
        ///L.LL.LL.LL
        ///LLLLLLL.LL
        ///L.L.L..L..
        ///LLLL.LL.LL
        ///L.LL.LL.LL
        ///L.LLLLL.LL
        ///..L.L.....
        ///LLLLLLLLLL
        ///L.LLLLLL.L
        ///L.LLLLL.LL
        ///Now, you just need to model the people who will be arriving shortly. Fortunately, people are entirely predictable and always follow a simple set of rules. All decisions are based on the number of occupied seats adjacent to a given seat (one of the eight positions immediately up, down, left, right, or diagonal from the seat). The following rules are applied to every seat simultaneously:
        ///
        ///If a seat is empty(L) and there are no occupied seats adjacent to it, the seat becomes occupied.
        ///If a seat is occupied (#) and four or more seats adjacent to it are also occupied, the seat becomes empty.
        ///Otherwise, the seat's state does not change.
        ///Floor (.) never changes; seats don't move, and nobody sits on the floor.
        ///
        ///After one round of these rules, every seat in the example layout becomes occupied:
        ///
        ///#.##.##.##
        ///#######.##
        ///#.#.#..#..
        ///####.##.##
        ///#.##.##.##
        ///#.#####.##
        ///..#.#.....
        ///##########
        ///#.######.#
        ///#.#####.##
        ///After a second round, the seats with four or more occupied adjacent seats become empty again:
        ///
        ///#.LL.L#.##
        ///#LLLLLL.L#
        ///L.L.L..L..
        ///#LLL.LL.L#
        ///#.LL.LL.LL
        ///#.LLLL#.##
        ///..L.L.....
        ///#LLLLLLLL#
        ///#.LLLLLL.L
        ///#.#LLLL.##
        ///This process continues for three more rounds:
        ///
        ///#.##.L#.##
        ///#L###LL.L#
        ///L.#.#..#..
        ///#L##.##.L#
        ///#.##.LL.LL
        ///#.###L#.##
        ///..#.#.....
        ///#L######L#
        ///#.LL###L.L
        ///#.#L###.##
        ///#.#L.L#.##
        ///#LLL#LL.L#
        ///L.L.L..#..
        ///#LLL.##.L#
        ///#.LL.LL.LL
        ///#.LL#L#.##
        ///..L.L.....
        ///#L#LLLL#L#
        ///#.LLLLLL.L
        ///#.#L#L#.##
        ///#.#L.L#.##
        ///#LLL#LL.L#
        ///L.#.L..#..
        ///#L##.##.L#
        ///#.#L.LL.LL
        ///#.#L#L#.##
        ///..L.L.....
        ///#L#L##L#L#
        ///#.LLLLLL.L
        ///#.#L#L#.##
        ///At this point, something interesting happens: the chaos stabilizes and further applications of these rules cause no seats to change state! Once people stop moving around, you count 37 occupied seats.
        ///
        ///Simulate your seating area by applying the seating rules repeatedly until no seats change state.How many seats end up occupied?
        /// </summary>
        public static List<List<char>> input = new List<List<char>>();

        public static void Main(string[] args)
        {
            ReadInput();

            var lastSeatingChart = new List<List<char>>();
            //while (lastSeatingChart != input)
            //while did not fire off, so just running 1000x since that will suffice
            for(int count = 0; count < 1000; count++)
            { 
                lastSeatingChart = new List<List<char>>();
                foreach (var i in input)
                {
                    var lastSeatingRow = new List<char>();
                    foreach (var y in i)
                        lastSeatingRow.Add(y);
                    lastSeatingChart.Add(lastSeatingRow);
                }
                PopulateSeatingChart();
            }

            var populatedSeatCount = 0;
            foreach (var row in input)
                populatedSeatCount += row.Where(x => x == '#').Count();

            Console.WriteLine("Seats populated: " + populatedSeatCount);

        }

        private static void PopulateSeatingChart()
        {
            var newChart = new List<List<char>>();

            for (int row = 0; row < input.Count; row++)
            {
                var newRow = new List<char>();
                for (int column = 0; column < input[row].Count; column++)
                {
                    var adjacentCount = 0;

                    for (int adjacentRow = -1; adjacentRow <= 1; adjacentRow++)
                    {
                        for (int adjacentColumn = -1; adjacentColumn <= 1; adjacentColumn++)
                        {
                            if (!(row == 0 && adjacentRow == -1)
                                && !(row == input.Count - 1 && adjacentRow == 1)
                                && !(column == 0 && adjacentColumn == -1)
                                && !(column == input[row].Count - 1 && adjacentColumn == 1)
                                && !(adjacentColumn == 0 && adjacentRow == 0))
                            {
                                if (input[row + adjacentRow][column + adjacentColumn] == '#')
                                    adjacentCount++;
                            }
                        }
                    }
                    if (adjacentCount == 0 && input[row][column] == 'L')
                        newRow.Add('#');
                    else if (input[row][column] == '#' && adjacentCount >= 4)
                        newRow.Add('L');
                    else
                        newRow.Add(input[row][column]);
                }
                newChart.Add(newRow);
            }

            input = newChart;
        }

        private static void ReadInput()
        {
            var lines = System.IO.File.ReadAllLines(@"C:/Users/ah3353/source/repos/Advent/Advent/Inputs/Input.txt");
            foreach (var line in lines)
            {
                input.Add(line.ToCharArray().ToList());
            }
        }
    }
}
