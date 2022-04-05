using System;
using System.Collections.Generic;

namespace Advent
{

    enum Direction
    {
        Forward,
        Up,
        Down,
    }

    class Move
    {
        public Direction direction;
        public int len;
        public Move(Direction in_direction, int in_len)
        {
            direction = in_direction;
            len = in_len;
        }
    }

    class Position
    {
        public int horizontal;
        public int depth;
        public Position(int in_horizontal, int in_depth)
        {
            horizontal = in_horizontal;
            depth = in_depth;
        }
    }

    class Advent2Solver
    {
        private List<Move> moves;
        private Position position;
        private string path;

        private Direction parse_direction(string str)
        {
            if (str.Equals("forward"))
                return Direction.Forward;
            if (str.Equals("up"))
                return Direction.Up;
            if (str.Equals("down"))
                return Direction.Down;
            throw new Exception("could not parse direction: " + str);
        }

        private Move parse_move(string str)
        {
            string[] pieces = str.Split(" ");

            if (pieces.Length != 2)
            {
                throw new Exception("error in input file at: " + str);
            }

            string dir_str = pieces[0];
            string len_str = pieces[1];

            Direction dir = parse_direction(dir_str);
            int len = Int16.Parse(len_str);

            return new Move(dir, len);
        }

        private void read_moves(string path)
        {
            string [] lines = System.IO.File.ReadAllLines(path);
            moves = new List<Move>();
            for(int n=0;n<lines.Length;n++)
            {
                moves.Add(parse_move(lines[n]));
            }
        }

        private void eval_moves()
        {
            position = new Position(0,0);

            for (int n=0;n<moves.Count;n++)
            {
                Move current = moves[n];

                if (current.direction == Direction.Up)
                    position.depth -= current.len;

                if (current.direction == Direction.Down)
                    position.depth += current.len;

                if (current.direction == Direction.Forward)
                    position.horizontal += current.len;
            }
        }

        public void calc()
        {
            read_moves(path);
            eval_moves();
        }

        public void print_position()
        {
            Console.WriteLine("horizontal = " + position.horizontal.ToString() + " depth = " + position.depth.ToString());
        }

        public Advent2Solver(string in_path)
        {
            path = in_path;
        }

    }

    class Program
    {
        static void Main(string[] args)
        {
            Advent2Solver solver = new Advent2Solver("input/input2.txt");
            solver.calc();
            solver.print_position();
        }
    }
}
