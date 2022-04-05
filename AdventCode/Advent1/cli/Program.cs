using System;
using System.Collections.Generic;

namespace Advent
{

    class Advent1Solver
    {

        static List<int> read_ints(string path)
        {
            string [] int_strings = System.IO.File.ReadAllLines(path);

            List<int> ints = new List<int>();

            for (int n=0; n < int_strings.Length; n++)
            {
                short parsed;
                string str = int_strings[n];
                bool ok = Int16.TryParse(str, out parsed);

                if (!ok)
                {
                    throw new Exception("could not parse value: " + str);
                }

                ints.Add(parsed);
            }

            return ints;
        }

        static int calc_higher(List<int> ints)
        {
            int higher = 0;

            for (int n = 1; n < ints.Count; n++)
            {
                if (ints[n] > ints[n-1])
                    higher++;
            }

            return higher;
        }

        public static int calc(string path)
        {
            return calc_higher(read_ints(path));
        }

    }

    class Program
    {
        static void Main(string[] args)
        {
            int higher = Advent1Solver.calc("input/input1.txt");
            Console.WriteLine("higher = " + higher.ToString());
        }
    }
}
