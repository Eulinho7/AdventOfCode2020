namespace AdventOfCode2020.Day9
{
    using AdventOfCode2020.Properties;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    public class D9
    {
        private List<long> input { get; set; }
        public D9()
        {
            input = new List<long>();
            ReadInput();
        }
        public void Solve()
        {
            int index = 0;
            long part1 = SolvePart1( ref index );
            Console.WriteLine( part1 );
            Console.WriteLine( SolvePart2( part1, index ) );
        }

        private long SolvePart1( ref int index )
        {
            for( int i = 26; i < input.Count; i++ )
            {
                if( !Check( i ) )
                {
                    index = i;
                    return input[i];
                }

            }
            return -1;
        }

        private long SolvePart2( long part1, int index )
        {
            long sum = 0;
            long smallest;
            long biggest;
            for( int i = 0; i < index - 2; i++ )
            {
                sum = input[i];
                smallest = sum;
                biggest = sum;
                for( int j = i + 1; j < index - 1; j++ )
                {
                    sum += input[j];
                    if( input[j] > biggest )
                    {
                        biggest = input[j];
                    }
                    if( input[j] < smallest )
                    {
                        smallest = input[j];
                    }
                    if( sum == part1 )
                    {
                        return smallest + biggest;
                    }
                    if( sum > part1 )
                    {
                        break;
                    }
                }
            }
            return -1;
        }

        private void ReadInput()
        {
            var s = Resources.input_day9;
            foreach( var item in s.Split( '\n' ).ToList() )
            {
                if( !string.IsNullOrEmpty( item ) )
                {
                    input.Add( long.Parse( item ) );
                }

            }
        }

        private bool Check( int index )
        {
            for( int i = index - 25; i < index; i++ )
            {
                for( int j = index - 25; j < index; j++ )
                {
                    if( i == j ) continue;
                    if( input[i] + input[j] == input[index] ) return true;
                }
            }
            return false;
        }
    }
}
