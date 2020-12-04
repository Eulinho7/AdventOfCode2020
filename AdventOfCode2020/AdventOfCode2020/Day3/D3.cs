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
        private int solution_Part1;

        public D3()
        {
            input = new List<string>();
            ReadInput();


        }

        public void Solve()
        {
            Solve_Part1();
            Console.WriteLine( solution_Part1 );
        }

        private void Solve_Part1()
        {
            solution_Part1 = 0;
            int pos = 0;
            foreach( var item in input )
            {
                if( item[pos] == '#' ) solution_Part1++;
                pos = ( pos + 3 ) % inputWidth;
            }
        }

        private void ReadInput()
        {
            var s = Resources.input_day3;
            foreach( var item in s.Split( '\n' ).ToList() )
            {
                if( !string.IsNullOrEmpty( item ) )
                    input.Add( item );
            }
            inputWidth = input[0].Length;
        }
    }
}
