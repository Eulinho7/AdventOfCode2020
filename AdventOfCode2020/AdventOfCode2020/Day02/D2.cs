namespace AdventOfCode2020.Day2
{
    using AdventOfCode2020.Properties;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class D2
    {
        private List<PasswordPolicy> input;
        public D2()
        {
            input = new List<PasswordPolicy>();
            ReadInput();
            Console.WriteLine( input.Count( c => c.IsValid() ) );
            Console.WriteLine( input.Count( c => c.IsValidPart2() ) );
        }

        private void ReadInput()
        {
            var s = Resources.input_day02;
            s = s.Replace( Environment.NewLine, "\n" );
            foreach( var item in s.Split( '\n' ).ToList() )
            {
                if( !string.IsNullOrEmpty( item ) )
                {
                    var p = new PasswordPolicy();
                    var policyStringList = item.Split( ':' );
                    p.Password = policyStringList[1].Trim();
                    policyStringList[0] = policyStringList[0].Replace( '-', ' ' );
                    var policyItems = policyStringList[0].Split( ' ' ).ToList();
                    p.Policy.MinOccurrences = Int32.Parse( policyItems[0] );
                    p.Policy.MaxOccurrences = Int32.Parse( policyItems[1] );
                    p.Policy.Character = policyItems[2][0];
                    input.Add( p );
                }

            }

        }
    }
}
