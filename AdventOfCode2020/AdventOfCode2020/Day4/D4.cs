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
        public D4()
        {
            input = new List<string>();
            ReadInput();
        }

        public void Solve()
        {
            Console.WriteLine( Solve_Part1() );
            Console.WriteLine( Solve_Part2() );
        }

        private int Solve_Part1()
        {
            int count = 0;
            foreach( var item in input )
            {
                var ls = item.Split( new[] { '\n', ' ' } ).ToList();
                if( ValidatePart1( ls ) ) count++;
            }
            return count;
        }

        private int Solve_Part2()
        {
            int count = 0;
            foreach( var item in input )
            {
                var ls = item.Split( new[] { '\n', ' ' } ).ToList();
                if( ValidatePart1( ls ) && ValidatePart2( ls ) ) count++;
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

        private bool ValidatePart1( List<string> ls )
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

        private bool ValidatePart2( List<string> ls )
        {
            foreach( var item in ls )
            {
                var s = item.Split( ':' ).ToList();
                switch( s[0] )
                {
                    case "byr":
                        var byr = Int32.Parse( s[1] );
                        if( byr < 1920 || byr > 2002 ) return false;
                        break;
                    case "iyr":
                        var iyr = Int32.Parse( s[1] );
                        if( iyr < 2010 || iyr > 2020 ) return false;
                        break;
                    case "eyr":
                        var eyr = Int32.Parse( s[1] );
                        if( eyr < 2020 || eyr > 2030 ) return false;
                        break;
                    case "hgt":
                        var unit = s[1].Substring( s[1].Length - 2 );
                        var hgt = Int32.Parse( s[1].Substring( 0, s[1].Length - 2 ) );
                        if( unit != "cm" && unit != "in" ) return false;
                        if( unit == "cm" && ( hgt < 150 || hgt > 193 ) ) return false;
                        if( unit == "in" && ( hgt < 59 || hgt > 76 ) ) return false;
                        break;
                    case "hcl":
                        if( !System.Text.RegularExpressions.Regex.IsMatch( s[1], @"#[0-9a-fA-F]{6}" ) ) return false;
                        break;
                    case "ecl":
                        if( s[1] != "amb" && s[1] != "blu" && s[1] != "brn" && s[1] != "gry" &&
                            s[1] != "grn" && s[1] != "hzl" && s[1] != "oth" ) return false;
                        break;
                    case "pid":
                        if( s[1].Length != 9 || !s[1].All( c => char.IsDigit( c ) ) ) return false;
                        break;
                    default:
                        break;
                }
            }

            return true;
        }
    }


}
