namespace AdventOfCode2020.Day3
{
    using AdventOfCode2020.Properties;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class D3
    {
        private List<string> input;
        private int inputWidth;
        private long solution_Part1;
        private long solution_Part2;

        public D3()
        {
            input = new List<string>();
            ReadInput();


        }

        public void Solve()
        {
            solution_Part1 = Solve_Part1( 3, 1 );
            solution_Part2 = Solve_Part2();
            Console.WriteLine( solution_Part1 );
            Console.WriteLine( solution_Part2 );
        }

        private long Solve_Part1( int shiftRight, int shiftDown )
        {
            int count = 0;
            int pos = 0;
            for( int i = 0; i < input.Count; i += shiftDown )
            {
                var item = input[i];
                if( item[pos] == '#' ) count++;
                pos = ( pos + shiftRight ) % inputWidth;
            }
            return count;
        }

        private long Solve_Part2()
        {
            return Solve_Part1( 1, 1 ) * Solve_Part1( 3, 1 ) * Solve_Part1( 5, 1 ) * Solve_Part1( 7, 1 ) * Solve_Part1( 1, 2 );
        }

        private void ReadInput()
        {
            var s = Resources.input_day03;
            foreach( var item in s.Split( '\n' ).ToList() )
            {
                if( !string.IsNullOrEmpty( item ) )
                    input.Add( item );
            }
            inputWidth = input[0].Length;
        }
    }
}
