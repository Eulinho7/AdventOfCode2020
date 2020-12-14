namespace AdventOfCode2020.Day6
{
    using AdventOfCode2020.Properties;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class D6
    {
        private List<string> input;

        public D6()
        {
            input = new List<string>();
            ReadInput();
        }

        public void Solve()
        {
            Console.WriteLine( SolvePart1() );
            Console.WriteLine( SolvePart2() );
        }

        private int SolvePart1()
        {
            int res = 0;
            foreach( var item in input )
            {
                int count = 0;
                for( char c = 'a'; c <= 'z'; c++ )
                {
                    if( item.Contains( c ) )
                        count++;
                }
                res += count;

            }
            return res;
        }

        private int SolvePart2()
        {
            int res = 0;
            foreach( var item in input )
            {
                var ls = item.Split( '\n' ).ToList();

                ls = ls.OrderBy( c => c.Length ).ToList();
                ls = ls.Where( c => !string.IsNullOrEmpty( c ) ).ToList();

                int count = 0;
                foreach( char c in ls[0] )
                {
                    if( ls.All( x => x.Contains( c ) ) )
                        count++;
                }
                res += count;
            }
            return res;
        }

        private void ReadInput()
        {
            var s = Resources.input_day06;
            s = s.Replace( "\r\n", "\n" ).Replace( "\n\n", ";" );
            foreach( var item in s.Split( ';' ).ToList() )
            {
                input.Add( item );
            }
        }
    }
}
