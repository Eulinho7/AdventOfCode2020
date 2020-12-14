namespace AdventOfCode2020.Day1
{
    using Properties;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class D1
    {
        private const int part1_targetSum = 2020;
        private List<int> input { get; set; }
        public int SolutionPart1 { get; set; }
        public int SolutionPart2 { get; set; }
        public D1()
        {
            input = new List<int>();
            ReadInput();
        }
        public void Solve()
        {
            if( Solve_Part1( 0, part1_targetSum ) )
            {
                Console.WriteLine( SolutionPart1 );
            }
            if( Solve_Part2() )
            {
                Console.WriteLine( SolutionPart2 );
            }
        }

        private bool Solve_Part1( int startingIndex, int target )
        {

            try
            {
                int i = startingIndex;
                int j = input.Count - 1;
                bool solved = input[i] + input[j] == target;
                while( !solved && ( i < j ) )
                {
                    if( input[i] + input[j] > target )
                        solved = MoveDown( i, ref j, target );
                    else if( input[i] + input[j] < target )
                        solved = MoveUp( i, ref j, target );
                    else
                        solved = true;
                    if( solved )
                    {
                        SolutionPart1 = input[i] * input[j];
                    }
                    i++;
                }
                return solved;
            }
            catch( Exception )
            {
                return false;
            }
        }

        private bool Solve_Part2()
        {
            int i = 0;
            int j = 1;
            bool solved = false;
            while( !solved && ( i < input.Count ) )
            {
                input = input.Where( c => ( c <= ( part1_targetSum - input[i] ) ) ).ToList();

                if( Solve_Part1( j, part1_targetSum - input[i] ) )
                {
                    SolutionPart2 = input[i] * SolutionPart1;
                    solved = true;
                }
                i++;
            }
            return solved;
        }

        private void ReadInput()
        {
            var s = Resources.input_day01;
            s = s.Replace( Environment.NewLine, " " );
            foreach( var item in s.Split( ' ' ).ToList() )
            {
                input.Add( Int32.Parse( item ) );
            }
            input.Sort();
        }

        private bool MoveUp( int i, ref int j, int targetSum )
        {
            try
            {
                while( ( input[i] + input[j] < targetSum ) && ( j < input.Count ) )
                    j++;
            }
            catch( Exception )
            {
                return false;
            }
            return input[i] + input[j] == targetSum;
        }

        private bool MoveDown( int i, ref int j, int targetSum )
        {
            try
            {
                while( ( input[i] + input[j] > targetSum ) && ( j < input.Count ) )
                    j--;
            }
            catch( Exception )
            {
                return false;
            }
            return input[i] + input[j] == targetSum;
        }

    }
}

