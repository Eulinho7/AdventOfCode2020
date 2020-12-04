namespace AdventOfCode2020.Day4
{
    using AdventOfCode2020.Properties;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class D4
    {
        private List<string> input;
        private int solutionPart1;
        private int solutionPart2;
        public D4()
        {
            input = new List<string>();
            ReadInput();
        }

        public void Solve()
        {
            Console.WriteLine( Solve_Part1() );
        }

        private int Solve_Part1()
        {
            int count = 0;
            foreach( var item in input )
            {
                var ls = item.Split( new[] { '\n', ' ' } ).ToList();
                if( PassportValid( ls ) ) count++;
            }
            return count;
        }

        private void ReadInput()
        {
            var s = Resources.input_day4;
            s = s.Replace( "\n\n", ";" );
            foreach( var item in s.Split( ';' ).ToList() )
            {
                if( !string.IsNullOrEmpty( item ) )
                    input.Add( item );
            }
        }

        private bool PassportValid( List<string> ls )
        {
            return ( ls.Count > 6 )
                && ( ls.Any( c => c.Contains( "byr" ) ) )
                && ( ls.Any( c => c.Contains( "iyr" ) ) )
                && ( ls.Any( c => c.Contains( "eyr" ) ) )
                && ( ls.Any( c => c.Contains( "hgt" ) ) )
                && ( ls.Any( c => c.Contains( "hcl" ) ) )
                && ( ls.Any( c => c.Contains( "ecl" ) ) )
                && ( ls.Any( c => c.Contains( "pid" ) ) );

        }
    }


}
