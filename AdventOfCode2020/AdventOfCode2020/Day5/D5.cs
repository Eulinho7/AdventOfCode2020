using AdventOfCode2020.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2020.Day5
{
    public class D5
    {
        private List<BoardingPass> input;
        public D5()
        {
            input = new List<BoardingPass>();
            ReadInput();
        }

        public void Solve()
        {
            Console.WriteLine( SolvePart1() );
            Console.WriteLine( SolvePart2() );
        }

        private int SolvePart1()
        {
            return input.FirstOrDefault().SeatID;
        }

        private int SolvePart2()
        {
            for( int i = 1; i < input.Count - 2; i++ )
            {
                if( ( input[i].SeatID == input[i - 1].SeatID - 2 ) )
                    return input[i].SeatID + 1;
            }
            return 0;
        }

        private void ReadInput()
        {
            var s = Resources.input_day5;
            foreach( var item in s.Split( '\n' ).ToList() )
            {
                if( !string.IsNullOrEmpty( item ) )
                    input.Add( new BoardingPass( item ) );
            }
            input = input.OrderByDescending( c => c.SeatID ).ToList();
        }

    }
}
